using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LifeEnterpot.Core.Models
{
    [Table("app_layout_main")]
    public class AppLayoutMain
    {

        public AppLayoutMain()
        {
            LayoutName = string.Empty;
            CreateId = string.Empty;
            ModifyId = string.Empty;
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("channel_id")]
        public Guid ChannelId { get; set; }

        [Column("section_id")]
        public Guid SectionId { get; set; }

        [Column("layout_name")]
        public string LayoutName { get; set; }

        [Column("create_id")]
        public string CreateId { get; set; }

        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        [Column("start_time")]
        public DateTime StartTime { get; set; }

        [Column("end_time")]
        public DateTime EndTime { get; set; }

        [Column("action_guid")]
        public Guid ActionGuid { get; set; }

        [Column("modify_time")]
        public DateTime? ModifyTime { get; set; }

        [Column("modify_id")]
        public string ModifyId { get; set; }

        [Column("main_id")]
        public int MainId { get; set; }
    }
    
}
