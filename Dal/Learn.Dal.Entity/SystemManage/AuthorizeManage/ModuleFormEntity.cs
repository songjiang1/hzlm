 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2016.04.14 09:16
    /// 描 述：系统表单
    /// </summary>
    [Table("sys_module_form")]
    public class ModuleFormEntity:BaseEntity
    {
        #region 实体成员 

        [ForeignKey("sys_module")]
        /// <summary>
        /// 功能主键
        /// </summary>
        public string module_id { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        public string code { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string  name { set; get; }
        /// <summary>
        /// 表单控件Json
        /// </summary>
        public string form_json { set; get; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int  sort_code { set; get; } 
        /// <summary>
        /// 备注
        /// </summary>
        public string description { set; get; } 
        public virtual ModuleEntity moduleEntity { get; set; }
        #endregion


    }
}
