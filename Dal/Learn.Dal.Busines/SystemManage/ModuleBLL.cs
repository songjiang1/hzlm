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
using Learn.Dal.Entity.SystemManage;
using System.Linq.Expressions;
using Learn.Dal.Model;

namespace Learn.Dal.Busines.SystemManage
{
    public class ModuleBLL 
    {
        private ModuleService moduleService = new ModuleService(); 

        #region 获取数据
      
        public async Task<TData<ModuleEntity>> GetEntity(string id)
        {
            TData<ModuleEntity> obj = new TData<ModuleEntity>();
            obj.data = await moduleService.GetBaseEntity(id);  
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData<List<ModuleEntity>>> GetList()
        {
            TData<List<ModuleEntity>> obj = new TData<List<ModuleEntity>>();
            var list= await moduleService.GetBaseList();
            obj.data = list;
            obj.code = HttpCodeEnum.OK; 
            return obj;
        }
        
        public async Task<TData<List<ModuleEntity>>> GetPageList(string where, Pagination pagination)
        {
            Expression<Func<ModuleEntity, bool>> expression = x=>true;
            TData<List<ModuleEntity>> obj = new TData<List<ModuleEntity>>();
            var list = await moduleService.GetBasePageList(expression, pagination);
            obj.data = list;
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> Update(ModuleEntity entity)
        {
            TData obj = new TData();
            await moduleService.BaseUpdate(entity); 
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Insert(ModuleEntity entity)
        {
            TData obj = new TData();
            await moduleService.BaseInsert(entity);
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Delete(string keyValue)
        {
            TData obj = new TData();
            await moduleService.BaseDeleteEntity(keyValue);
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
