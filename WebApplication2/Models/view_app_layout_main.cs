using System;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeEnterpot.Core.Models
{ 
    [Table("view_app_layout_main")]
    public class ViewAppLayoutMain
    {

        public ViewAppLayoutMain()
        {
            Memo = string.Empty;
            LayoutName = string.Empty;
            CreateId = string.Empty;

        }
		[Column("id")]
		public int Id { get; set; }

		[Column("channel_id")]
		public Guid ChannelId { get; set; }

		[Column("type")]
		public int Type { get; set; }

		[Column("status")]
		public int Status { get; set; }

		[Column("memo")]
		public string Memo { get; set; }

		[Column("layout_name")]
		public string LayoutName { get; set; }

		[Column("start_time")]
		public DateTime StartTime { get; set; }

		[Column("end_time")]
		public DateTime EndTime { get; set; }

		[Column("create_id")]
		public string CreateId { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; }

		[Column("action_guid")]
		public Guid ActionGuid { get; set; }

		[Column("main_id")]
		public int MainId { get; set; }




}
}
