using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json; 
using System.Diagnostics; 
using System.Reflection;
using System.Text;
using Learn.Util.Extension;
using Learn.Util;
using Learn.Util.Model;
using Learn.Web.Code;
using Learn.Util.Enum;
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Entity.SystemManage;
using Learn.Web.Code.Model;

namespace Learn.Web.Controllers
{
    /// <summary>
    /// 枚举 ，获取枚举信息
    /// </summary>
    public class EnumController : Controller
    {


        #region 获取数据
        [HttpGet]
        public async Task<IActionResult> GetListJson(string enumName)
        {
            TData<List<ModuleButtonEnumModel>> obj = new TData<List<ModuleButtonEnumModel>>();
            if (string.IsNullOrWhiteSpace(enumName)) {
                obj.code = HttpCodeEnum.ParameteNotEmpty;
                obj.msg = HttpCodeEnum.ParameteNotEmpty.ParseToEnumDescribe();
                return Json(obj);
            }
            try
            {
               var  list =  EnumHelper.EnumStringToList(enumName);
                
                obj.code = HttpCodeEnum.OK;
                obj.msg = HttpCodeEnum.OK.ParseToEnumDescribe();
                obj.data = list.Select(x=> {
                    ModuleButtonEnumModel model = new ModuleButtonEnumModel();
                    model.id = x.value;
                    model.name = x.desction;
                    model.code = x.text;
                    return model;
                }).ToList();
                return Json(obj);
            }
            catch (System.Exception ex)
            {
                obj.code = HttpCodeEnum.SystemError;
                obj.msg = HttpCodeEnum.SystemError.ParseToEnumDescribe();
                return Json(obj);
            }
        }
        #endregion 


    }


}