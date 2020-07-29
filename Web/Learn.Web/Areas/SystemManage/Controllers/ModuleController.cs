using Learn.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Learn.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class ModuleController : BaseController
    {
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
    }
}
