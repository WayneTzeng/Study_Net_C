using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeEnterpot.Core.Models
{
	[Table("view_product_version")]
	public class ViewProductVersion
	{
		public ViewProductVersion()
		{
			ProductName = string.Empty;
			SubTitle = string.Empty;
			ImagePath = string.Empty;
			SuppilerProductId = string.Empty;
			Promotion = string.Empty;
			PaymentRestrict = 0;
		}

		[Column("id")]
		public int Id { get; set; }

		[Column("product_pvid")]
		public int ProductPvid { get; set; }

		[Key]
		[Column("pvid")]
		public int Pvid { get; set; }

		[Column("product_id")]
		public int ProductId { get; set; }

		[Column("bid")]
		public Guid Bid { get; set; }

		[Column("is_main")]
		public bool IsMain { get; set; }

		[Column("channel_id")]
		public Guid ChannelId { get; set; }

		[Column("product_name")]
		public string ProductName { get; set; }

		[Column("sub_title")]
		public string SubTitle { get; set; }

		[Column("image_path")]
		public string ImagePath { get; set; }

		[Column("price")]
		public decimal Price { get; set; }

		[Column("original_price")]
		public decimal OriginalPrice { get; set; }

		[Column("is_sold_out")]
		public bool IsSoldOut { get; set; }

		[Column("delivery_type")]
		public int DeliveryType { get; set; }

		[Column("cost")]
		public decimal Cost { get; set; }

		[Column("deal_start_time")]
		public DateTime DealStartTime { get; set; }

		[Column("deal_end_time")]
		public DateTime DealEndTime { get; set; }

		[Column("is_chosen")]
		public bool IsChosen { get; set; }

		[Column("offline")]
		public bool? Offline { get; set; }
		[Column("sys_offline")]
		public bool SysOffline { get; set; }

		[Column("suppiler_id")]
		public int SuppilerId { get; set; }

		[Column("suppiler_product_id")]
		public string SuppilerProductId { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; }

		[Column("is_group_coupon")]
		public bool IsGroupCoupon { get; set; }

		[Column("coupon_type")]
		public int? CouponType { get; set; }

		[Column("sale_multiple_base")]
		public int SaleMultipleBase { get; set; }

		[Column("payment_restrict")]
		public int PaymentRestrict { get; set; }

		[Column("promotion")]
		public string Promotion { get; set; }
	}
}
