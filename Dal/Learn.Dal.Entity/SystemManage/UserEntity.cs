using Learn.Dal.Entity;
using Learn.Util.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace Learn.Dal.Entity.BaseManage
{
    /// <summary>
    /// 
    /// </summary>
    ///  
    public class UserEntity: BaseEntity
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
        public string code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string user_account { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string user_password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string secret_key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string real_name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nick_name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string head_icon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string simple_spelling { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string full_spelling { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? birthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool is_delete { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string qq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string wechat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string manager_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string organize_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string department_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string role_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string duty_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool user_online { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string open_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? single_flag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool is_enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool is_look { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool check_online { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? allow_start_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? allow_end_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? lock_start_date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? lock_end_date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? first_visit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? last_visit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? logon_count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int  usource { get; set; }
         
    }
}