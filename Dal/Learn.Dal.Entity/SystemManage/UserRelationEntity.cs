using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace Learn.Dal.Entity.BaseManage
{

    /// <summary>
    /// 
    /// </summary>
    public class UserRelationEntity:BaseEntity
    {
        

        /// <summary>
        /// 
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int  sort_code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String description { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public int category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String object_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean is_default { get; set; }

    }
}