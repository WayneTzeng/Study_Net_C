 using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LifeEnterpot.Core.Models
{
    [Table("app_layout_product")]
    public class AppLayoutProduct
    {
        public AppLayoutProduct()
        {

        }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("action_guid")]
        public Guid ActionGuid { get; set; }

        [Column("bid")]
        public Guid Bid { get; set; }

        [Column("latest")]
        public int Latest { get; set; }

        [Column("sort")]
        public int Sort { get; set; }

        [Column("deal_name")]
        public string DealName { get; set; }





    }
}
