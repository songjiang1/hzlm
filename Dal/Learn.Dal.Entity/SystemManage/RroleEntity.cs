using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace Learn.Dal.Entity.BaseManage
{
    [Table("sys_role")]
    /// <summary>
    /// 
    /// </summary>
    public class RroleEntity: BaseEntity
    {

         

        /// <summary>
        /// 
        /// </summary>
        public  int sort_code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String description { get; set; }
         

        /// <summary>
        /// 
        /// </summary>
        public System.String organize_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean is_public { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean is_enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? overdue_ime { get; set; }


    }
}