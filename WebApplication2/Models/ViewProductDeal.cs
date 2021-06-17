using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeEnterpot.Core.Models
{
	[Table("view_product_deals")]
	public class ViewProductDeal
	{
		public ViewProductDeal()
		{
			ProductName = string.Empty;
			SubTitle = string.Empty;
			ImagePath = string.Empty;
			Categories = string.Empty;
			Dealtags = string.Empty;
			Promotion = string.Empty;
			PaymentRestrict = 0;
		}

		[Column("pvid")]
		public int Pvid { get; set; }

		[Column("channel_id")]
		public Guid ChannelId { get; set; }

		[Column("bid")]
		public Guid Bid { get; set; }

		[Column("product_name")]
		public string ProductName { get; set; }

		[Column("sub_title")]
		public string SubTitle { get; set; }

		[Column("image_path")]
		public string ImagePath { get; set; }

		[Column("sold_num")]
		public int SoldNum { get; set; }

		[Column("price")]
		public decimal Price { get; set; }

		[Column("original_price")]
		public decimal OriginalPrice { get; set; }

		[Column("on_top")]
		public bool OnTop { get; set; }

		[Column("offline")]
		public bool? Offline { get; set; }

		[Column("is_chosen")]
		public bool IsChosen { get; set; }

		[Column("is_main")]
		public bool IsMain { get; set; }

		[Column("delivery_type")]
		public int DeliveryType { get; set; }

		[Column("behavior_type")]
		public int BehaviorType { get; set; }

		[Column("is_sold_out")]
		public bool IsSoldOut { get; set; }

		[Column("deal_start_time")]
		public DateTime DealStartTime { get; set; }

		[Column("deal_end_time")]
		public DateTime DealEndTime { get; set; }

		[Column("seq")]
		public int Seq { get; set; }

		[Column("version")]
		public int Version { get; set; }

		[Column("is_group_coupon")]
		public bool IsGroupCoupon { get; set; }

		[Column("coupon_type")]
		public int? CouponType { get; set; }

		[Column("sale_multiple_base")]
		public int SaleMultipleBase { get; set; }

		[Column("categories")]
		public string Categories { get; set; }

		[Column("dealTags")]
		public string Dealtags { get; set; }

		[Column("description")]
		public string Description { get; set; }

		[Column("payment_restrict")]
		public int PaymentRestrict { get; set; }

		[Column("promotion")]
		public string Promotion { get; set; }

		[Column("hot_top_sort")]
		public int? HotTopSort { get; set; }

		[Column("channel_product_id")]
		public int ChannelProductId { get; set; }
	}
}
