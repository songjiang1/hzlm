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

namespace Learn.Web.Controllers
{
    /// <summary>
    /// 基础控制器，用来记录访问日志
    /// </summary>
    public class BaseController : Controller
    {
        //public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();

        //    string action = context.RouteData.Values["Action"].ParseToString();
        //    OperatorInfo user = await Operator.Instance.Current();

        //    //if (GlobalContext.SystemConfig.Demo)
        //    //{
        //    //    if (context.HttpContext.Request.Method.ToUpper() == "POST")
        //    //    {
        //    //        if (action.ToUpper() != "Login".ToUpper() && action.ToUpper() != "CodePreviewJson".ToUpper())
        //    //        {
        //    //            TData obj = new TData();
        //    //            obj.msg = "演示模式，不允许操作";
        //    //            context.Result = new CustomJsonResult { Value = obj };
        //    //            return;
        //    //        }
        //    //    }
        //    //}

        //    var resultContext = await next();

        //    sw.Stop();
        //    string ip = NetHelper.Ip;
        //    LogEntity operateEntity = new LogEntity();
        //    var areaName = context.RouteData.DataTokens["area"] + "/";
        //    var controllerName = context.RouteData.Values["controller"] + "/";
        //    string currentUrl = "/" + areaName + controllerName + action;

        //    if (action.ParseToString().ToLower() != "GetServerJson".ToLower() && action.ParseToString().ToLower() != "Error".ToLower())
        //    {
        //        #region 获取请求参数
        //        switch (context.HttpContext.Request.Method.ToUpper())
        //        {
        //            case "GET":
        //                operateEntity.execute_param = context.HttpContext.Request.QueryString.Value.ParseToString();
        //                break;

        //            case "POST":
        //                Dictionary<string, string> param = new Dictionary<string, string>();
        //                foreach (var item in context.ActionDescriptor.Parameters)
        //                {
        //                    var itemType = item.ParameterType;
        //                    if (itemType.IsClass && itemType.Name != "String")
        //                    {
        //                        PropertyInfo[] infos = itemType.GetProperties();
        //                        foreach (PropertyInfo info in infos)
        //                        {
        //                            if (info.CanRead)
        //                            {
        //                                var propertyValue = context.HttpContext.Request.Form[info.Name];
        //                                if (!param.ContainsKey(info.Name))
        //                                {
        //                                    if (!string.IsNullOrEmpty(propertyValue))
        //                                    {
        //                                        param.Add(info.Name, propertyValue);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                if (param.Count > 0)
        //                {
        //                    operateEntity.execute_url += context.HttpContext.Request.QueryString.Value.ParseToString();
        //                    operateEntity.execute_param = TextHelper.GetSubString(JsonConvert.SerializeObject(param), 8000);
        //                }
        //                else
        //                {
        //                    operateEntity.execute_param = context.HttpContext.Request.QueryString.Value.ParseToString();
        //                }
        //                break;
        //        }
        //        #endregion

        //        #region 异常获取
        //        StringBuilder sbException = new StringBuilder();
        //        if (resultContext.Exception != null)
        //        {
        //            Exception exception = resultContext.Exception;
        //            sbException.AppendLine(exception.Message);
        //            while (exception.InnerException != null)
        //            {
        //                sbException.AppendLine(exception.InnerException.Message);
        //                exception = exception.InnerException;
        //            }
        //            sbException.AppendLine(resultContext.Exception.StackTrace);
        //            //operateEntity.LogStatus = OperateStatusEnum.Fail.ParseToInt();
        //        }
        //        else
        //        {
        //            //operateEntity.LogStatus = OperateStatusEnum.Success.ParseToInt();
        //        }
        //        #endregion

        //        #region 日志实体                  
        //        //if (user != null)
        //        //{
        //        //    operateEntity.BaseCreatorId = user.UserId;
        //        //}

        //        //operateEntity.ExecuteTime = sw.ElapsedMilliseconds.ParseToInt();
        //        //operateEntity.IpAddress = ip;
        //        //operateEntity.ExecuteUrl = currentUrl.Replace("//", "/");
        //        //operateEntity.ExecuteResult = TextHelper.GetSubString(sbException.ToString(), 4000);
        //        #endregion

        //        //Action taskAction = async () =>
        //        //{
        //        //    // 让底层不用获取HttpContext
        //        //    operateEntity.BaseCreatorId = operateEntity.BaseCreatorId ?? 0;

        //        //    // 耗时的任务异步完成
        //        //    //operateEntity.IpLocation = IpLocationHelper.GetIpLocation(ip);
        //        //    //await new LogOperateBLL().SaveForm(operateEntity);
        //        //};
        //        //AsyncTaskHelper.StartTask(taskAction);
        //    }
        //}

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    base.OnActionExecuted(context);
        //}

        
       
        #region action 返回
        

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            TData obj = new TData();
            obj.code = HttpCodeEnum.OK;
            obj.msg = message;
            return Json(obj);
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(HttpCodeEnum code)
        {
            TData obj = new TData();
            obj.code = code;
            obj.msg = code.ParseToEnumDescribe();
            return Json(obj);
        } 
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data)
        {

            TData obj = new TData();
            obj.code = HttpCodeEnum.OK;
            obj.msg = message; 
            return Json(obj);
        }
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(HttpCodeEnum code, string msg = "")
        {
            TData obj = new TData();
            obj.code = code;
            obj.msg = string.IsNullOrWhiteSpace(msg) ? msg.ParseToEnumDescribe() : msg;
            return Json(obj);
        } 
        #endregion


    }

    //public class CustomJsonResult : JsonResult
    //{
    //    public CustomJsonResult() : base(string.Empty)
    //    { }

    //    public override void ExecuteResult(ActionContext context)
    //    {
    //        this.ContentType = "text/json;charset=utf-8;";

    //        JsonSerializerSettings jsonSerizlizerSetting = new JsonSerializerSettings();
    //        jsonSerizlizerSetting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

    //        string json = JsonConvert.SerializeObject(Value, Formatting.None, jsonSerizlizerSetting);
    //        Value = json;
    //        base.ExecuteResult(context);
    //    }

    //    public override Task ExecuteResultAsync(ActionContext context)
    //    {
    //        this.ContentType = "text/json;charset=utf-8;"; 
    //        JsonSerializerSettings jsonSerizlizerSetting = new JsonSerializerSettings();
    //        jsonSerizlizerSetting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
    //        string json = JsonConvert.SerializeObject(Value, Formatting.None, jsonSerizlizerSetting);
    //        Value = json.ToJObject();
    //        return base.ExecuteResultAsync(context);
    //    }
    //}
}