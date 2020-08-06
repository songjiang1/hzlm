 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 1.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    ///  
    public class ModuleEntity : BaseEntity
    {
        #region 实体成员 
        /// <summary>
        /// 父级主键
        /// </summary>
        public string parente_id { set; get; }
        /// <summary>
        /// 编号
        /// </summary>
        public string  code { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string  name { set; get; }
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { set; get; }
        /// <summary>
        /// 导航地址
        /// </summary>
        public string url_address { set; get; }
        /// <summary>
        /// 导航目标
        /// </summary>
        public string target { set; get; }
        /// <summary>
        /// 菜单选项
        /// </summary>
        public bool is_menu { set; get; }  
        /// <summary>
        /// 菜单选项
        /// </summary>
        public bool is_enabled { set; get; }
        
        /// <summary>
        /// 排序码
        /// </summary>
        public int  sort_code { set; get; }
       
        /// <summary>
        /// 备注
        /// </summary>
        public string description { set; get; }
         
        public ICollection<ModuleButtonEntity> moduleButtons { set; get; } 
        public ICollection<ModuleColumnEntity> moduleColumns { set; get; } 
        public ICollection<ModuleFormEntity> moduleForms { set; get; } 
        public ICollection<ModuleInstanceEntity> moduleInstances { set; get; } 
        #endregion


    }
}
