using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data; 
namespace Learn.Dal.Entity.BaseManage
{ 
    /// <summary>
    /// 
    /// </summary>
    public class OrganizeEntity:BaseEntity
    {
      
        /// <summary>
        /// 机构分类
        /// </summary>
        public int? ctegory { get ; set ; }

       
        /// <summary>
        /// 父级主键
        /// </summary>
        public string parent_id { get ; set ; }

       
        /// <summary>
        /// 机构外文
        /// </summary>
        public string code { get ; set ; }

       
        /// <summary>
        /// 机构中文
        /// </summary>
        public string  name { get ; set ; }
 
        /// <summary>
        /// 机构全拼
        /// </summary>
        public string full_spelling { get ; set ; }

       
        /// <summary>
        /// 机构性质
        /// </summary>
        public string nature { get ; set ; }
         
        /// <summary>
        /// 联系电话
        /// </summary>
        public string  phone { get ; set ; }
         
        /// <summary>
        /// 邮编
        /// </summary>
        public string postal_code { get ; set ; }

       
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string email { get ; set ; }

       
        /// <summary>
        /// 负责人主键
        /// </summary>
        public string manager_id { get ; set ; }
           
        /// <summary>
        /// 省主键
        /// </summary>
        public string province_id { get ; set ; }

       
        /// <summary>
        /// 市主键
        /// </summary>
        public string city_id { get ; set ; }

       
        /// <summary>
        /// 县/区主键
        /// </summary>
        public string county_id { get ; set ; }

       
        /// <summary>
        /// 详细地址
        /// </summary>
        public string address { get ; set ; }

       
        /// <summary>
        /// 机构官方
        /// </summary>
        public string web_address { get ; set ; }

       
        /// <summary>
        /// 成立时间
        /// </summary>
        public DateTime? founded_time { get ; set ; }

       
        /// <summary>
        /// 经营范围
        /// </summary>
        public string business_scope { get ; set ; }

       
         
       
        /// <summary>
        /// 排序码
        /// </summary>
        public int  sort_code { get ; set ; } 
        
        /// <summary>
        /// 备注
        /// </summary>
        public string description { get ; set ; } 
    }
}