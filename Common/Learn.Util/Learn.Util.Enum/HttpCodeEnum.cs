using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Util.Enum
{
    
    public enum HttpCodeEnum
    {
        //命名规范：系统通用操作除外，其他的按照 模块或类型_名称，如：登录_用户被限制登录 命名为“ Login_AccountLimitLogin”
        #region 系统通用操作  
        [Description("请求成功")]
         OK = 200,  
        [Description("查询成功")]
        LookSuccess = 211,
        [Description("添加成功")]
        InsertSuccess = 212,
        [Description("添加错误")]
        InsertError = 213,
        [Description("更新成功")]
        UpdateSuccess = 214,
        [Description("更新成功")]
        UpdateError = 215,
        [Description("删除成功")]
        DeleteSuccess = 216,
        [Description("删除成功")]
        DeleteError = 217,
        [Description("验证码为空")]
        VerificationCodeEmpty = 218,
        [Description("验证码错误")]
        VerificationCodeError = 219,

        #region 通用验证

        [Description("手机格式不正确,请输入正确的手机号码")]
        MobileFormatError = 300, 
        [Description("邮箱格式不正确,请输入正确的邮箱")]
        EmailFormatError = 300,
        #endregion

        #endregion

        #region 登录 
        [Description("用户不存在")]
        Login_AccountNotExist = 2302,
        [Description("密码错误，请重新输入")]
        Login_AccountPasswordError = 2303,
        [Description("用户已被锁定，请联系管理员")]
        Login_AccountLocking = 2304,
        [Description("用户已被禁用，请联系管理员")]
        Login_AccountDisable = 2305,
        [Description("用户已被限制登录，请联系管理员")]
        Login_AccountLimitLogin = 2306, 
        [Description("登录成功")]
        Login_Success = 2307,
        #endregion

        #region 退出 
        [Description("已退出登录")]
        OutLogin_Success = 2400,
        #endregion

        #region 注册 
        [Description("注册成功")]
        Register_Success = 2500,
        #endregion

        #region 验证-数据上的验证
        #endregion 
    }
}
