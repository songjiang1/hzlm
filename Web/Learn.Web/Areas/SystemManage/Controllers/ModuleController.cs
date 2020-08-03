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
            TData<List<ModuleEntity>> obj = await moduleBLL.GetList();
            var a1 = obj.data[0].moduleButtons;
            return Json(obj);
        }
        #endregion 

        #region 提交数据

        #endregion
    }
}
