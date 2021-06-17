using System;
using System.Collections.Generic;
using LifeEnterpot.Core.Enums;
using LifeEnterpot.Core.ModelCustom;
using LifeEnterpot.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeEnterpot.Core.Providers
{
    public interface IProductProvider
    {
        //List<ViewProductVersion> ViewProductVersionGet(ProductVersionListModel para, bool isNew);
        //ViewProductVersion ViewProductVersionGet(Guid channelId, Guid bid);
        //ViewProductVersion ViewProductVersionGet(Guid channelId, string suppilerProductId);
        //ViewProductVersion ViewProductVersionGet(Guid bid);
        //List<ViewProductVersion> ViewProductVersionListGet(Guid channelId, List<Guid> bids);
        //ViewProductVariationItem ViewProductVariationItemGetByPVarId(int PVarId);
        //List<ViewProductVariationItem> GetViewProductVariationItemByBid(Guid bid);
        //List<ChannelProduct> ChannelProducListGet(List<int> ids);
        //List<ChannelProduct> ChannelProducListGet(Guid bid);
        //bool ChannelProductSet(List<ChannelProduct> list, bool online, EntityState entityState);
        //bool ChannelProductSet(List<ChannelProduct> list, EntityState entityState);
        //bool ChannelProductSetSysOffline(List<ChannelProduct> list);
        //List<ChannelProduct> ChannelProducGetByZeroStock();
        //Product GetProduct(string supplierProductId, SourceSupplier supplier);
        List<ViewProductDeal> ViewProductDealsAll();
        List<ViewProductDeal> ViewProductDealsGetAll();
        List<ViewProductDeal> ViewProductDealsByChannelId(Guid channelId);
        List<ViewProductDeal> ViewProductDealsByChannelIdWithDealTime(Guid channelId);
        List<ViewProductDeal> ViewProductDealsGet(Guid channelId, List<Guid> bids);
        List<ViewProductDeal> ViewProductDealsGetRandom(Guid channelId, List<Guid> bids, int deliveryType, int num);
        //List<ViewCategoryDependency> GetViewCategoryDependency();
        //Product ProductGet(Guid bid);
        //List<string> ProductGetAllSuppilerProductId(SourceSupplier sourceSupplier);
        //List<Guid> ProductGetAllBidBySupplier(SourceSupplier sourceSupplier);
        //List<Product> ProductGetbySuppilerProductId(SourceSupplier sourceSupplier, string bid);
        //Product GetProduct(int bid);
        //bool ProductSet(Product product, EntityState entityState);
        //bool ProductVersionSet(ProductVersion productVersion, EntityState entityState);
        //bool ProductVariationDelete(List<ProductVariation> productVariations);
        //List<CouponTypeModel> GetCouponTypeByProductVersion();
        //ProductVersion ProductVersionGet(int pvid);
        //List<ProductVariation> ProductVariationsGetByProductId(int pid);
        //ProductVariation ProductVariationsGet(int id);
        //ProductVersion ProductVersionGetByProductId(int pid);
        //List<Sku> SkuGetByNames(List<string> name);
        //Sku SkuGet(int id);
        //void SkuDelete(Sku sku);
        //List<SkuOption> SkuOptionGet(int skuId);
        //void SkuOptionDelete(SkuOption skuOption);
        //List<SkuOptionValue> SkuOptionValueGet(int skuOptionId);
        //void SkuOptionValueDelete(SkuOptionValue skuOptionValue);
        //SkuOptionValue SkuOptionValueGetByVarId(int varId);
        //List<ProductItem> ProductItemsGetByProductVariationId(int pvId);
        //List<ProductItem> ProductItemsGetByProductVariationId(List<int> pvIds);
        //void ProductVariationDelete(ProductVariation pv);
        //void ProductVariationSet(ProductVariation pv, EntityState entityState);
        //void UpdtaeProductSoldNum(Guid bid, int quantity);
        //ProductStore ProductStoreGet(int pid, Guid storeGuid);
        //void ProductStoreDelete(List<ProductStore> productStores);
        //void ProductTagDelete(int pid, string tagName);
        //void ProductTagDeleteAll(int pid);
        //void ProductTagSet(ProductTag tag, EntityState entityState);
        //List<ProductTag> ProductTagGet(int pid);
        //List<ProductStore> ProductStoreGet(int pid);
        ///// <summary>
        ///// 可購買的分店
        ///// </summary>
        ///// <param name="pid"></param>
        ///// <returns></returns>
        //List<ProductStore> GetBuyableProductStores(Guid bid);
        ///// <summary>
        ///// 可進行消費的分店(顯示在說明)
        ///// </summary>
        ///// <param name="pid"></param>
        ///// <returns></returns>
        //List<ProductStore> GetDisplayProductStores(int pid);
        //FamilyStoreInfo GetFamilyStoreInfo(string storeCode);
        //void InsertOrUpdateFamiStore(FamilyStoreInfo familyStoreInfo);
        //void ItemSet(Item item, EntityState state);
        //bool ItemSet(List<Item> list, EntityState entityState);
        //Item ItemGetById(int itemId);
        //void ItemAdjustQuantitySet(ItemAdjustQuantity adjust, EntityState state);
        //bool ItemAdjustQuantitySet(List<ItemAdjustQuantity> list, EntityState entityState);
        //void ProductStoreSet(ProductStore store, EntityState state);
        //void StoreAdjustQuantitySet(StoreAdjustQuantity adjust, EntityState state);
        //ProductItem ProductItemGet(int itemId);
        //void ProductItemDelete(ProductItem item);
        //ProductVersion ProductVersionGet(int productId, int version);
        //List<OrderProductCategory> ProductCategoriesGet(int productId);
        //List<ProductCategory> ProductCategoriesGetByProductId(int productId);
        //void ProductCategorySet(ProductCategory productCategory, EntityState entityState);
        //void ProductCategoryDelete(int pid, int cid);
        //ProductContent ProductContentGetByProductId(int productId);
        //void ProductContentSet(ProductContent productContent, EntityState entityState);
        //TempSession TempSessionGet(string sessionId, string name);
        //void TempSessionDelete(int id);
        //void TempSessionSet(TempSession ts);
        //ViewProductContent ViewProductContentGet(Guid bid);
        //List<WeeklyHot> WeeklyHotGet(Guid channelGuid, DateTime date);
        //bool SaveWeeklyHot(List<WeeklyHot> salesCharts);
        //bool DeleteWeeklyHot(DateTime date);
        //List<string> SyncProductListGet(SourceSupplier sourceSupplier);
        //List<ChannelProduct> GetExpiredProductList(SourceSupplier sourceSupplier);
        //void SaveSyncProductList(SyncProductList input);
        //void DeleteAllSyncProductList();
        //List<ViewProductSales> ProductSalesGetByCreateTime(DateTime startTime, DateTime endTime);
        //List<SyncPayeasyProduct> SyncPayeasyProductGetAll(int task);
        //List<SyncPayeasyProduct> SyncPayeasyProductGetOptions();
        //SyncPayeasyProduct SyncPayeasyProductGet(string supplierProductId);
        //void AddSyncPayeasyProduct(string suppilerProductId, string content);
        //void UpdateSyncPayeasyProduct(string suppilerProductId, DateTime startTime);
        //List<OrderRedemptionCode> GetEmptyCustomRedemptionCode();
        //void SyncPayeasyProductSet(SyncPayeasyProduct syncPayeasyProduct);
    }
}
