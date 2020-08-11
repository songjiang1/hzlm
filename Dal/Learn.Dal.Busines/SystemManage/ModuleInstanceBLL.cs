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
    public class ModuleInstanceBLL 
    {
        private ModuleInstanceService service = new ModuleInstanceService(); 

        #region 获取数据
      
        public async Task<TData<ModuleInstanceEntity>> GetEntity(string id)
        {
            TData<ModuleInstanceEntity> obj = new TData<ModuleInstanceEntity>();
            obj.data = await service.GetBaseEntity(id);  
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData<List<ModuleInstanceEntity>>> GetList(string moduleId)
        {
            TData<List<ModuleInstanceEntity>> obj = new TData<List<ModuleInstanceEntity>>();
            var exp = LinqExtensions.True<ModuleButtonEntity>();
            if (string.IsNullOrWhiteSpace(moduleId))
            {
                exp = exp.And(t => t.module_id.Contains(moduleId));
            }
            var list= await service.GetBaseList(exp);
            obj.data = list;
            obj.code = HttpCodeEnum.OK; 
            return obj;
        }
        
        public async Task<TData<List<ModuleInstanceEntity>>> GetPageList(string where, Pagination pagination)
        {
            Expression<Func<ModuleInstanceEntity, bool>> expression = x=>true;
            TData<List<ModuleInstanceEntity>> obj = new TData<List<ModuleInstanceEntity>>();
            var list = await service.GetBasePageList(expression, pagination);
            obj.data = list;
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> Update(ModuleInstanceEntity entity)
        {
            TData obj = new TData();
            await service.BaseUpdate(entity); 
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Insert(ModuleInstanceEntity entity)
        {
            TData obj = new TData();
            await service.BaseInsert(entity);
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Delete(string keyValue)
        {
            TData obj = new TData();
            await service.BaseDeleteEntity(keyValue);
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
