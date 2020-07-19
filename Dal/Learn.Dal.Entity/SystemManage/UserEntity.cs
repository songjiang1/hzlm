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
    [Table("sys_user")]
    public class UserEntity: BaseEntity
    {
         
        /// <summary>
        /// 
        /// </summary>
        public int sort_code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String description { get; set; }
         

        /// <summary>
        /// 
        /// </summary>
        public System.String code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String user_account { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String user_password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String secret_key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String real_name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String nick_name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String head_icon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String simple_spelling { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String full_spelling { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? birthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool is_delete { get; set; }

        
        /// <summary>
        /// 
        /// </summary>
        public System.String telephone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String qq { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String wechat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String msn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String manager_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String organize_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String department_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String role_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String duty_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? user_online { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String open_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? single_flag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? is_enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Boolean? check_online { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? allow_start_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? allow_end_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? lock_start_date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? lock_end_date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? first_visit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? last_visit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32? logon_count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int  usource { get; set; }
         
    }
}