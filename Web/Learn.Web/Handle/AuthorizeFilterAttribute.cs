using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Util.Enum;
using Learn.Util.Extension;
using Learn.Util.Model;
using Learn.Web.Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 

namespace Learn.Web.Controllers
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        private LoginMode CustomMode;
        public AuthorizeFilterAttribute() { }

        public AuthorizeFilterAttribute(LoginMode loginMode= LoginMode.Ignore, string authorize=null)
        {
            this.Authorize = authorize;
        }

        /// <summary>
        /// 指定权限方式 如指定用户，角色等
        /// </summary>
        public string Authorize { get; set; }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool hasPermission = false;

            OperatorInfo user = await Operator.Instance.Current();
            if (user == null)
            {
                #region 没有登录
                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    TData obj = new TData();
                    obj.code = HttpCodeEnum.LoginInvalid;
                    obj.msg = "抱歉，没有登录或登录已超时";
                    context.Result = new JsonResult (obj);
                    return;
                }
                else
                {
                    context.Result = new RedirectResult("~/Login/Index");
                    return;
                }
                #endregion
            }
            else
            { // 系统用户拥有所有权限
                if (user.IsSystem)
                {
                    hasPermission = true;
                }
                // 权限判断
                if (!string.IsNullOrEmpty(Authorize))
                {  
                }
                else
                {
                    hasPermission = true;
                }
                if (hasPermission)
                {
                    var resultContext = await next();
                }
            }

        }
    }
}
