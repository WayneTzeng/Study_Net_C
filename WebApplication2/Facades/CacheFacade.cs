using LifeEnterpot.Core.Enums;
using LifeEnterpot.Core.Kernel;
using LifeEnterpot.Core.Models;
using LifeEnterpot.Core.Providers;
//using LifeEnterpot.Core.Template;
//using LifeEnterpot.Core.Template.ViewModel;
//using LifeEnterpot.Core.Utilities.TemplateHelper;
//using LifeEnterpot.Core.Utilities;
using log4net;
//using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net.Mime;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace LifeEnterpot.Core.Facades
{
    public class CacheFacade
    {
        private static ILog logger = LogManager.GetLogger(typeof(CacheFacade));
        protected class CacheData<T>
        {
            public static CacheData<T> Create(T t)
            {
                return new CacheData<T>
                {
                    CreateTime = DateTime.Now,
                    Data = t
                };
            }

            public T Data { get; set; }
            public DateTime CreateTime { get; set; }

            public override string ToString()
            {
                return string.Format("{0:yyyy/MM/dd HH:mm:ss} - {1}", DateTime.Now, typeof(T));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static ConcurrentDictionary<string, object> updateLocks = new ConcurrentDictionary<string, object>();

        private static ConcurrentDictionary<string, ConcurrentBag<string>> groupCacheKeys =
            new ConcurrentDictionary<string, ConcurrentBag<string>>();


        /// <summary>
        /// 取得緩存資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key) where T : class, new()
        {
            CacheDataStatus dataStatus;
            T result = Get<T>(key, out dataStatus);
            return result;
        }

        /// <summary>
        /// 取得緩存資料
        /// 但 dataStatus 為 Expired，此時呼叫端應該進行非同步更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="dataStatus"></param>
        /// <returns></returns>
        public static T Get<T>(object key, out CacheDataStatus dataStatus) where T : class, new()
        {
            string innerKey = GetCacheKey<T>(key);
            string spareKey = GetSpareKey<T>(key);
            object obj;
            CacheData<T> result = null;
            if (Ioc.GetCache().TryGetValue(innerKey, out obj))
            {
                result = (CacheData<T>)obj;
            }
            if (result != null)
            {
                dataStatus = CacheDataStatus.OK;
                return result.Data;
            }
            if (Ioc.GetCache().TryGetValue(spareKey, out obj))
            {
                result = (CacheData<T>)obj;
            }
            if (result != null)
            {
                dataStatus = CacheDataStatus.Expired;
                return result.Data;
            }
            dataStatus = CacheDataStatus.None;
            return null;
        }

        /// <summary>
        /// 緩存時間為 TimeSpan 加上 extendExpireMinutes
        /// extendExpireMinutes 時間範圍內取資料，仍會回傳資料，
        /// 但 dataStatus 為 Expired，此時呼叫端應該進行非同步更新
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <param name="extendExpireMinutes"></param>
        /// <param name="groupName"></param>
        public static void Set<T>(object key, T value, TimeSpan ts, int extendExpireMinutes = 0, string groupName = "")
            where T : class, new()
        {
            string cacheKey = GetCacheKey<T>(key);
            string spareKey = GetSpareKey<T>(key);

            if (groupCacheKeys.ContainsKey(groupName) == false)
            {
                groupCacheKeys.TryAdd(groupName, new ConcurrentBag<string>());
            }
            groupCacheKeys[groupName].Add(cacheKey);
            groupCacheKeys[groupName].Add(spareKey);
            Ioc.GetCache().Set(cacheKey, CacheData<T>.Create(value), new DateTimeOffset(DateTime.Now.Add(ts)));
            if (extendExpireMinutes > 0)
            {
                Ioc.GetCache().Set(spareKey, CacheData<T>.Create(value),
                    new DateTimeOffset(DateTime.Now.Add(ts).AddMinutes(extendExpireMinutes)));
            }
            //logger.DebugFormat("MemoryCache: Set Cache<{0}> key={1}, {2}", typeof(T).Name, cacheKey, spareKey);
        }

        /// <summary>
        /// 緩存時間為 minutes 加上 extendExpireMinutes
        /// extendExpireMinutes 時間範圍內取資料，仍會回傳資料，
        /// 但 dataStatus 為 Expired，此時呼叫端應該進行非同步更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="minutes"></param>
        /// <param name="extendExpireMinutes"></param>
        /// <param name="groupName"></param>
        public static void Set<T>(object key, T value, int minutes, int extendExpireMinutes = 0, string groupName = "")
                   where T : class, new()
        {
            Set(key, value, TimeSpan.FromMinutes(minutes), extendExpireMinutes, groupName);
        }

        private static TaskFactory taskFactory = new TaskFactory();
        /// <summary>
        /// 非同步更新快取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="expireMinutes"></param>
        /// <param name="extendExpireMinutes"></param>
        /// <param name="groupName"></param>
        public static void SetAsync<T>(object key, Func<T> func, int expireMinutes, int extendExpireMinutes, string groupName = "")
            where T : class, new()
        {
            string innerKey = GetCacheKey<T>(key);
            if (updateLocks.ContainsKey(innerKey) == false)
            {
                updateLocks.TryAdd(innerKey, new object());
            }

            taskFactory.StartNew(delegate
            {
                lock (updateLocks[innerKey])
                {
                    CacheDataStatus dataStatus;
                    Get<T>(key, out dataStatus);
                    //資料沒過期，也就不用更新
                    if (dataStatus == CacheDataStatus.OK)
                    {
                        return;
                    }
                    T value = func();
                    Set(key, value, expireMinutes, extendExpireMinutes, groupName);
                }
            });
        }

        public static void RemoveByGroup(string groupName)
        {
            ConcurrentBag<string> keys;
            groupCacheKeys.TryRemove(groupName, out keys);
            if (keys == null || keys.Count == 0)
            {
                return;
            }
            foreach (string key in keys)
            {
                Remove(key);
            }
        }

        public static void Remove(Type type, object key)
        {
            string cacheKey = GetCacheKey(type, key);
            string spareKey = GetSpareKey(type, key);

            Ioc.GetCache().Remove(cacheKey);
            Ioc.GetCache().Remove(spareKey);

            //logger.DebugFormat("MemoryCache: Remove Cache<{0}> key={1}, {2}", type.Name, cacheKey, spareKey);
        }

        public static void Remove<T>(object key)
        {
            string cacheKey = GetCacheKey<T>(key);
            string spareKey = GetSpareKey<T>(key);

            Ioc.GetCache().Remove(cacheKey);
            Ioc.GetCache().Remove(spareKey);

            //logger.DebugFormat("MemoryCache: Remove Cache<{0}> key={1}, {2}", typeof(T).Name, cacheKey, spareKey);
        }

        public static void Remove(string key)
        {
            Ioc.GetCache().Remove(key);
        }

        private static string GetCacheKey<T>(object key)
        {
            return GetCacheKey(typeof(T), key);
        }
        private static string GetSpareKey<T>(object key)
        {
            return GetSpareKey(typeof(T), key);
        }
        private static string GetCacheKey(Type type, object key)
        {
            return string.Format("{0}.{1}", type.FullName, key);
        }
        private static string GetSpareKey(Type type, object key)
        {
            return string.Format("{0}.{1}.spareVersion", type.FullName, key);
        }
    }

}
