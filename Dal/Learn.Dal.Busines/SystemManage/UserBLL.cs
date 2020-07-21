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
            obj.code = HttpCodeEnum.OK;
            return obj;
        }

        public async Task<TData<UserEntity>> CheckLogin(string userName, string password, int platform=1)
        {
            TData<UserEntity> obj = new TData<UserEntity>();
            if (userName.IsEmpty())
            { 
                obj.code = HttpCodeEnum.Login_AccountEmpty;
                return obj;
            }
            if (password.IsEmpty())
            {
                obj.code = HttpCodeEnum.Login_AccountPasswordEmpty;
                return obj;
            }
            UserEntity user = await userService.CheckLogin(userName);
            if (user != null)
            {
                if (!user.is_look)
                {
                    obj.code = HttpCodeEnum.Login_AccountLocking; 
                }
                else
                {
                    if (!user.is_enabled)
                    {
                        string dbPassword = Md5Helper.MD5(DESEncrypt.Encrypt(password.ToLower(), user.secret_key).ToLower(), 32).ToLower();
                        if (user.user_password == dbPassword)
                        {
                            user.logon_count = user.logon_count.ParseToInt() + 1;
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
                            obj.data = user;
                            obj.code = HttpCodeEnum.OK;
                        }
                        else
                        {
                            obj.code = HttpCodeEnum.Login_AccountPasswordError;
                        }
                    }
                    else
                    {
                        obj.code = HttpCodeEnum.Login_AccountDisable;
                    }
                }
               
            }
            else
            {
                obj.code = HttpCodeEnum.Login_AccountNotExist;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> UpdateUser(UserEntity entity)
        {
            TData obj = new TData();
            await userService.UpdateUser(entity);

            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
