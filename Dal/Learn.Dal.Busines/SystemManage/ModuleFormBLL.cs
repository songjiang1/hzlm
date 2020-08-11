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
    public class ModuleFormBLL
    {
        private ModuleFormService service = new ModuleFormService(); 

        #region 获取数据
      
        public async Task<TData<ModuleFormEntity>> GetEntity(string id)
        {
            TData<ModuleFormEntity> obj = new TData<ModuleFormEntity>();
            obj.data = await service.GetBaseEntity(id);  
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData<List<ModuleFormEntity>>> GetList(string moduleId)
        {
            TData<List<ModuleFormEntity>> obj = new TData<List<ModuleFormEntity>>();
            var exp = LinqExtensions.True<ModuleFormEntity>();
            if (string.IsNullOrWhiteSpace(moduleId))
            {
                exp = exp.And(t => t.module_id.Contains(moduleId));
            }
            var list= await service.GetBaseList(exp);
            obj.data = list;
            obj.code = HttpCodeEnum.OK; 
            return obj;
        }
        
        public async Task<TData<List<ModuleFormEntity>>> GetPageList(string where, Pagination pagination)
        {
            Expression<Func<ModuleFormEntity, bool>> expression = x=>true;
            TData<List<ModuleFormEntity>> obj = new TData<List<ModuleFormEntity>>();
            var list = await service.GetBasePageList(expression, pagination);
            obj.data = list;
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> Update(ModuleFormEntity entity)
        {
            TData obj = new TData();
            await service.BaseUpdate(entity); 
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Insert(ModuleFormEntity entity)
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
