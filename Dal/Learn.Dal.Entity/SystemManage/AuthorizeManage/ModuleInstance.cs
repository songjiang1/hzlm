using Learn.Util.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 
    /// </summary>
    public class ModuleInstance : BaseEntity
    {
       
         

        /// <summary>
        /// 
        /// </summary>
        public int sort_code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }

        

        /// <summary>
        /// 
        /// </summary>
        public string module_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string url_address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int access_level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int is_enabled { get; set; }
    }
}