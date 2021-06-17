using LifeEnterpot.Core.Kernel;
using LifeEnterpot.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace LifeEnterpot.Core.DbContenxts
{
    public class CommonDbContext : DbContext
    {
        private static ILoggerFactory loggerFactory;
        static CommonDbContext()
        {
            //loggerFactory = new EntityFrameworkSqlLoggerFactory();
            //loggerFactory.AddProvider(new EntityFrameworkSqlLoggerProvider());
        }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        string connStr = Ioc.GetConfig().ConnectionString;
        //        optionsBuilder.UseSqlServer(connStr);

        //        optionsBuilder.UseLoggerFactory(loggerFactory);
        //        base.OnConfiguring(optionsBuilder);
        //    }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        base.OnModelCreating(modelBuilder);
        //        // Adding the code below tells DB "NumericId is an AlternateKey and don't update".
        //        modelBuilder.Entity<CouponCodeMain>().Property(p => p.CouponId)
        //            .UseSqlServerIdentityColumn();
        //        modelBuilder.Entity<CouponCodeMain>().Property(p => p.CouponId)
        //            .Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        //        modelBuilder.Entity<ViewCustomerServiceOutsideLog>().HasKey(x => x.Id);
        //        modelBuilder.Entity<ViewProductDeal>().HasKey(p => new { p.Pvid, p.ChannelId });
        //        modelBuilder.Entity<ViewCategoryDependency>().HasKey(p => new { p.ParentId, p.CategoryId });
        //        modelBuilder.Entity<ViewProductContent>().HasKey(x => x.Id);
        //        modelBuilder.Entity<ViewProductCategoryByChannel>().HasKey(p => new { p.Pvid, p.Cid, p.ChannelId });
        //        modelBuilder.Entity<ViewOrderRedemption>().HasKey(x => x.Id);
        //        modelBuilder.Entity<ViewOrderDelivery>().HasKey(x => x.Id);
        //        modelBuilder.Entity<ViewAppLayoutMain>().HasKey(x => x.Id);
        //        modelBuilder.Entity<ViewOrderChannel>().HasKey(x => x.OrderId);
        //        modelBuilder.Entity<ViewProductSales>().HasKey(x => x.OrderNumber);
        //        modelBuilder.Entity<ViewOrderReturn>().HasKey(x => x.Id);
        //        modelBuilder.Entity<ViewMgmGiftRedemption>().HasKey(x => x.Id);
        //        //modelBuilder.Entity<ViewOrderRedemptionWithoutCustomerService>().HasKey(x => x.Id);
        //    }

        //    public DbSet<OauthClient> OauthClientSet { get; set; }
        //    public DbSet<OauthClientPermission> OauthClientPermissionSet { get; set; }
        //    public DbSet<OauthClientUser> OauthClientUserSet { get; set; }
        //    public DbSet<OauthToken> OauthTokenSet { get; set; }

        //    public DbSet<OauthTokenPermission> OauthTokenPermissionSet { get; set; }


        //    public DbSet<SystemData> SystemDataSet { get; set; }

        //    public DbSet<SystemFunctionSection> SystemFunctionSectionSet { get; set; }
        //    public DbSet<SystemFunction> SystemFunctionSet { get; set; }
        //    public DbSet<Role> RoleSet { get; set; }

        //    public DbSet<Permission> PermissionSet { get; set; }
        //    public DbSet<MaintainerPermission> MaintainerPermissionSet { get; set; }

        //    public DbSet<Maintainer> MaintainerSet { get; set; }
        //    public DbSet<MaintainerChannel> MaintainerChannelSet { get; set; }
        //    public DbSet<MaintainerModule> MaintainerModuleSet { get; set; }
        //    public DbSet<Channel> ChannelSet { get; set; }
        //    public DbSet<MaintainerRole> MaintainerRoleSet { get; set; }

        //    public DbSet<MaintainerAuthToken> MaintainerAuthTokenSet { get; set; }

        //    public DbSet<WhiteList> WhiteListSet { get; set; }
        //    public DbSet<CouponCodeMain> CouponCodeMainSet { get; set; }
        //    public DbSet<CouponCodeDetail> CouponCodeDetailSet { get; set; }


        //    public DbSet<CouponCodeBudget> CouponCodeBudgetSet { get; set; }
        //    public DbSet<CouponCodeBlack> CouponCodeBlackSet { get; set; }
        //    public DbSet<ChangeLog> ChangeLogSet { get; set; }
        //    public DbSet<ViewProductCategory> ViewProductCategorySet { get; set; }
        //    public DbSet<ViewCategoryDependency> ViewCategoryDependencySet { get; set; }
        //    public DbSet<ViewProductCategoryByChannel> ViewProductCategoryByChannelSet { get; set; }
        //    public DbSet<Member> MemberSet { get; set; }
        //    public DbSet<ViewCouponCodeDetail> ViewCouponCodeDetailSet { get; set; }
        //    public DbSet<ThemeCurationMain> ThemeCurationMainSet { get; set; }
        //    public DbSet<ThemeCurationCategory> ThemeCurationCategoeySet { get; set; }
        //    public DbSet<ThemeCurationProduct> ThemeCurationProductSet { get; set; }

        //    public DbSet<ThemeCurationMainProposal> ThemeCurationMainProposalSet { get; set; }
        //    public DbSet<ThemeCurationCategoryProposal> ThemeCurationCategoeyProposalSet { get; set; }
        //    public DbSet<ThemeCurationProductProposal> ThemeCurationProductProposalSet { get; set; }

        //    public DbSet<Category> CategorySet { get; set; }

        //    public DbSet<CategoryDependency> CategoryDependencySet { get; set; }
        //    public DbSet<Sku> SkuSet { get; set; }
        //    public DbSet<SkuOption> SkuOptionSet { get; set; }
        //    public DbSet<SkuOptionValue> SkuOptionValueSet { get; set; }
        //    public DbSet<ProductItem> ProductItemSet { get; set; }

        //    public DbSet<HomepageAction> HomepageActionSet { get; set; }
        //    public DbSet<HomepageBlock> HomepageBlockSet { get; set; }
        //    public DbSet<ViewHomepageBlock> ViewHomepageBlockSet { get; set; }

        //    public DbSet<TransactionidLog> TransactionidLogSet { get; set; }
        //    public DbSet<Restriction> RestrictionSet { get; set; }
        //    public DbSet<CustomizeWordingSettings> CustomizeWordingSettingsSet { get; set; }


        //    #region 商品相關

        //    public DbSet<ChannelProduct> ChannelProductSet { get; set; }
        //    public DbSet<Product> ProductSet { get; set; }
        //    public DbSet<ProductCategory> ProductCategorySet { get; set; }
        //    public DbSet<ProductContent> ProductContentSet { get; set; }
        //    public DbSet<ProductStore> ProductStoreSet { get; set; }
        //    public DbSet<StoreAdjustQuantity> StoreAdjustQuantitySet { get; set; }
        //    public DbSet<Item> ItemSet { get; set; }
        //    public DbSet<ItemAdjustQuantity> ItemAdjustQuantitySet { get; set; }
        //    public DbSet<ProductTag> ProductTagSet { get; set; }
        //    public DbSet<ProductVersion> ProductVersionSet { get; set; }
        //    public DbSet<ViewProductVersion> ViewProductVersionSet { get; set; }
        //    public DbSet<ProductVariation> ProductVariationSet { get; set; }
        //    public DbSet<ViewProductVariationItem> ViewProductVariationItemSet { get; set; }
        //    public DbSet<ViewProductDeal> ViewProductDealsSet { get; set; }
        //    public DbSet<ViewProductContent> ViewProductContentSet { get; set; }
        //    public DbSet<WeeklyHot> WeeklyHotSet { get; set; }

        //    public DbSet<ViewOrderProductItem> ViewOrderProductItemSet { get; set; }
        //    public DbSet<ViewProductSales> ViewProductSalesSet { get; set; }
        //    #endregion

        //    #region Order
        //    public DbSet<Order> OrderSet { get; set; }
        //    public DbSet<OrderItem> OrderItemSet { get; set; }
        //    public DbSet<MemberAddres> MemberAddressSet { get; set; }
        //    public DbSet<Addres> AddressSet { get; set; }
        //    public DbSet<OrderRedemptionCode> OrderRedemptionCodeSet { get; set; }
        //    public DbSet<OrderProductDelivery> OrderProductDeliverySet { get; set; }
        //    public DbSet<OrderProductDeliveryLog> OrderProductDeliveryLogSet { get; set; }
        //    public DbSet<OrderShip> OrderShipSet { get; set; }
        //    public DbSet<ShipCompany> ShipCompanySet { get; set; }
        //    public DbSet<ViewOrderRedemption> ViewOrderRedemptionSet { get; set; }
        //    public DbSet<ViewOrderDelivery> ViewOrderDeliverySet { get; set; }
        //    public DbSet<ViewOrderChannel> ViewOrderChannelSet { get; set; }
        //    public DbSet<ViewOrderReturn> ViewOrderReturnSet { get; set; }
        //    public DbSet<ViewOrderShip> ViewOrderShipSet { get; set; }
        //    public DbSet<ViewMgmGiftRedemption> ViewMgmGiftRedemptionSet { get; set; }
        //    public DbSet<ViewOrderRedemptionWithoutCustomerService> ViewOrderRedemptionWithoutCustomerServiceSet { get; set; }
        //    #endregion

        //    #region Payment
        //    public DbSet<PaymentTransaction> PaymentTransactionSet { get; set; }
        //    public DbSet<PaymentTransactionNote> PaymentTransactionNoteSet { get; set; }
        //    public DbSet<OrderPayment> OrderPaymentSet { get; set; }


        //    #endregion

        //    #region
        //    public DbSet<CreditcardBank> CreditcardBankSet { get; set; }
        //    public DbSet<CreditcardBankInfo> CreditcardBankInfoSet { get; set; }

        //    #endregion

        //    #region 發票相關

        //    public DbSet<EinvoiceMain> EinvoiceMainSet { get; set; }
        //    public DbSet<EinvoiceSerial> EinvoiceSerialSet { get; set; }
        //    public DbSet<EinvoiceChangeLog> EinvoiceChangeLogSet { get; set; }

        //    #endregion  

        //    public DbSet<CustomerServiceMain> CustomerServiceMainSet { get; set; }
        //    public DbSet<CustomerServiceOutsideLog> CustomerServiceOutsideLogSet { get; set; }
        //    public DbSet<CustomerServiceCategory> CustomerServiceCategorySet { get; set; }
        //    public DbSet<Faq2> Faq2Set { get; set; }
        //    public DbSet<ViewCustomerServiceOutsideLog> ViewCustomerServiceOutsideLogSet { get; set; }

        //    /// <summary>
        //    /// 物流公司
        //    /// </summary>
        //    public DbSet<LogisticsCompany> LogisticsCompanySet { get; set; }
        //    public DbSet<SerialNumber> SerialNumberSet { get; set; }
        //    public DbSet<OrderUserMemoList> OrderUserMemoListSet { get; set; }
        //    public DbSet<TempSession> TempSessionSet { get; set; }

        //    public DbSet<ReturnForm> ReturnFormSet { get; set; }

        //    public DbSet<MobileAuthCheck> MobileAuthCheckSet { get; set; }

        //    public DbSet<AuditLog> AuditLogSet { get; set; }

        //    #region APP首頁版面
        //    public DbSet<AppLayoutAction> AppLayoutActionSet { get; set; }
        //    public DbSet<AppLayoutChannel> AppLayoutChannelSet { get; set; }
        //    public DbSet<AppLayoutCuration> AppLayoutCurationSet { get; set; }
        //    public DbSet<AppLayoutMain> AppLayoutMainSet { get; set; }
        //    public DbSet<AppLayoutArticle> AppLayoutArticleSet { get; set; }
        //    public DbSet<AppLayoutProduct> AppLayoutProductSet { get; set; }
        //    public DbSet<AppLayoutSection> AppLayoutSectionSet { get; set; }
        //    public DbSet<ViewAppLayoutMain> ViewAppLayoutMainSet { get; set; }
        //    #endregion

        //    #region MailLogHistory
        //    public DbSet<MailLogHistory> MailLogHistorySet { get; set; }
        //    #endregion

        //    public DbSet<Building> BuildingSet { get; set; }
        //    public DbSet<SyncProductList> SyncProductListSet { get; set; }
        //    public DbSet<SyncPayeasyProduct> SyncPayeasyProductSet { get; set; }

        //    public DbSet<CreditcardOtp> CreditcardOtpSet { get; set; }
        //    public DbSet<FamilyStoreInfo> FamilyStoreInfoSet { get; set; }
        //    public DbSet<BankInfo> BankInfoSet { get; set; }
        //    public DbSet<CtAtmRefund> CtAtmRefundSet { get; set; }
        //    public DbSet<CtAtmP1log> CtAtmP1logSet { get; set; }
        //    public DbSet<CtAtmR1log> CtAtmR1logSet { get; set; }
        //    public DbSet<UserTracking> UserTrackingSet { get; set; }
        //    public DbSet<ReportLog> ReportLogSet { get; set; }
        //    public DbSet<CustomerServiceReportData> CustomerServiceReportDataSet { get; set; }
        //    public DbSet<MgmGift> MgmGiftSet { get; set; }
        //    public DbSet<MgmGiftLog> MgmGiftLogSet { get; set; }
        //}
    }
    public static class DbContextExtensions
    {
        public static T ExecuteScalarAsync<T>(this DbContext context, string rawSql,
          params Tuple<string, DbType, object>[] parameters)
        {
            var conn = context.Database.GetDbConnection();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = rawSql;

                if (parameters != null)
                {
                    foreach (var p in parameters)
                    {
                        var parameter = cmd.CreateParameter();
                        parameter.ParameterName = p.Item1;
                        parameter.DbType = p.Item2;
                        parameter.Value = p.Item3;

                        cmd.Parameters.Add(parameter);
                    }
                }
                conn.Open();

                object obj = cmd.ExecuteScalar();
                if (obj == null)
                {
                    return default(T);
                }
                return (T)obj;
            }
        }
    }
}
