using Learn.Dal.Busines.SystemManage;
using Learn.Dal.Entity.SystemManage;
using Learn.Util.Model;
using Learn.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class ModuleController : BaseController
    {
        private ModuleBLL moduleBLL = new ModuleBLL();
        private ModuleButtonBLL  moduleButtonBLL = new ModuleButtonBLL();
        private ModuleColumnBLL moduleColumnBLL = new ModuleColumnBLL();
        private ModuleFormBLL  moduleFormBLL = new ModuleFormBLL();
        private ModuleFormInstanceBLL  moduleFormInstanceBLL = new ModuleFormInstanceBLL();
        private ModuleInstanceBLL moduleInstanceBLL = new ModuleInstanceBLL();
        #region 视图
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        public async Task<IActionResult> GetListJson()
        {
            try
            {

                TData<List<ModuleEntity>> obj = await moduleBLL.GetList();
                //var a1 = obj.data[0].moduleButtons;
                return Json(obj);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 按钮
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetModuelButtonListJson(string moduleId)
        {
            try
            {
                TData<List<ModuleButtonEntity>> obj = await moduleButtonBLL.GetList(moduleId);
                //var a1 = obj.data[0].moduleButtons;
                return Json(obj);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 视图-列
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetModuelColumnListJson(string moduleId)
        {
            try
            {

                TData<List<ModuleColumnEntity>> obj = await moduleColumnBLL.GetList(moduleId);
                //var a1 = obj.data[0].moduleButtons;
                return Json(obj);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 表单
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetModuelFormListJson(string moduleId)
        {
            try
            {

                TData<List<ModuleFormEntity>> obj = await moduleFormBLL.GetList(moduleId);
                //var a1 = obj.data[0].moduleButtons;
                return Json(obj);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetModuelInstanceListJson(string moduleId)
        {
            try
            {

                TData<List<ModuleInstanceEntity>> obj = await moduleInstanceBLL.GetList(moduleId);
                //var a1 = obj.data[0].moduleButtons;
                return Json(obj);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
        #endregion 

        #region 提交数据

        #endregion
    }
}
