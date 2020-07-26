using Learn.Dal.Busines.SystemManage;
using Learn.Util;
using Learn.Util.Enum;
using Learn.Util.Model;
using Microsoft.AspNetCore.Mvc;
using Learn.Dal.Entity.BaseManage;
using System;
using System.Threading.Tasks;
using Learn.Web.Code;
using Learn.Util.Extension;

namespace Learn.Web.Controllers
{ 
    public class HomeController : BaseController
    {
         //this.ControllerContext.RouteData.Values["Action"].ParseToString();
        private UserBLL userBLL = new UserBLL();
        private LogBLL  logBLL = new LogBLL();
        #region MyRegion 视图
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminDesktop()
        {
            return View();
        }
        public IActionResult AdminDefault()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            LogEntity logEntity = new LogEntity
            {
                category = OperationTypeEnum.Login,
                operate_type_name = ((int)OperationTypeEnum.Login).ToString(),
                operate_type = EnumHelper.GetDescription(OperationTypeEnum.Login),
                operate_account = userName, 
                operate_time = DateTime.Now, 
                module_name = GlobalContext.Configuration.GetSection("SystemConfig:SoftName").Value
            };
            try
            {
                TData<UserEntity> userObj = await userBLL.CheckLogin(userName, password, (int)PlatformEnum.Web);
                if (userObj.code == HttpCodeEnum.OK)
                {
                    await new UserBLL().UpdateUser(userObj.data);
                    await Operator.Instance.AddCurrent(userObj.data.token);
                }
                Action taskAction = async () =>
                { 
                    logEntity.execute_result = HttpCodeEnum.Login_Success;
                    logEntity.execute_resultJson = HttpCodeEnum.Login_Success.ParseToEnumDescribe();

                    // 让底层不用获取HttpContext  
                    await  logBLL.WriteLog(logEntity);
                }; 
                AsyncTaskHelper.StartTask(taskAction);  
                return Success(userObj.msg);
            }
            catch (Exception ex)
            {
                return Error(HttpCodeEnum.InterfaceError);
            }
            
        }
        #endregion
    }
}