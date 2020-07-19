using Learn.Dal.Service.SystemManage;
using Learn.Util;
using Learn.Util.Enum;
using Learn.Util.Extension;
using Learn.Util.Model;
using Learn.Dal.Entity.BaseManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Learn.Dal.Busines.SystemManage
{
    public class UserBLL 
    {
        private UserService userService = new UserService(); 

        #region 获取数据
      

        

        public async Task<TData<UserEntity>> GetEntity(string id)
        {
            TData<UserEntity> obj = new TData<UserEntity>();
            obj.data = await userService.GetBaseEntity(id);  
            obj.code = RequestTypeEnum.Success;
            return obj;
        }

        public async Task<TData<UserEntity>> CheckLogin(string userName, string password, int platform=1)
        {
            TData<UserEntity> obj = new TData<UserEntity>();
            obj.code = RequestTypeEnum.Error;
            if (userName.IsEmpty() || password.IsEmpty())
            {
                obj.msg = "用户名或密码不能为空";
                return obj;
            }
            UserEntity user = await userService.CheckLogin(userName);
            if (user != null)
            {
                if (user.is_enabled == false)
                {
                    string dbPassword = Md5Helper.MD5(DESEncrypt.Encrypt(password.ToLower(), user.secret_key).ToLower(), 32).ToLower();
                    if (user.user_password == dbPassword)
                    {
                        user.logon_count= user.logon_count.ParseToInt()+1;
                        user.user_online = true; 
                        user.last_visit = DateTime.Now;  
                        
                         

                        switch (platform)
                        {
                            case (int)PlatformEnum.Web:
                                if (GlobalContext.SystemConfig.LoginMultiple)
                                {
                                    #region 多次登录用同一个token
                                    if (string.IsNullOrEmpty(user.token))
                                    {
                                        user.token = Md5Helper.GetGuid();
                                    }
                                    #endregion
                                }
                                else
                                {
                                    user.token = Md5Helper.GetGuid();
                                }
                                break;

                            case (int)PlatformEnum.WebApi:
                                user.token = Md5Helper.GetGuid();
                                break;
                        }
                        //await GetUserBelong(user);

                        obj.data = user;
                        obj.msg = "登录成功";
                        obj.code = RequestTypeEnum.Success;
                    }
                    else
                    {
                        obj.msg = "密码不正确，请重新输入";
                    }
                }
                else
                {
                    obj.msg = "账号被禁用，请联系管理员";
                }
            }
            else
            {
                obj.msg = "账号不存在，请重新输入";
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> UpdateUser(UserEntity entity)
        {
            TData obj = new TData();
            await userService.UpdateUser(entity);

            obj.code = RequestTypeEnum.Success;
            return obj;
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
