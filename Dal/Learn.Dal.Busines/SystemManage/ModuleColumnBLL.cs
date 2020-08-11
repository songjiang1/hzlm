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
    public class ModuleColumnBLL
    {
        private ModuleColumnService moduleColumnService = new ModuleColumnService(); 

        #region 获取数据
      
        public async Task<TData<ModuleColumnEntity>> GetEntity(string id)
        {
            TData<ModuleColumnEntity> obj = new TData<ModuleColumnEntity>();
            obj.data = await moduleColumnService.GetBaseEntity(id);  
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData<List<ModuleColumnEntity>>> GetList(string moduleId)
        {
            TData<List<ModuleColumnEntity>> obj = new TData<List<ModuleColumnEntity>>();
            var exp= LinqExtensions.True<ModuleColumnEntity>();
            if (string.IsNullOrWhiteSpace(moduleId)) {
                exp = exp.And(t => t.module_id.Contains(moduleId));
            }
            var list= await moduleColumnService.GetBaseList(exp);
            obj.data = list;
            obj.code = HttpCodeEnum.OK; 
            return obj;
        }
        
        public async Task<TData<List<ModuleColumnEntity>>> GetPageList(string where, Pagination pagination)
        {
            Expression<Func<ModuleColumnEntity, bool>> expression = x=>true;
            TData<List<ModuleColumnEntity>> obj = new TData<List<ModuleColumnEntity>>();
            var list = await moduleColumnService.GetBasePageList(expression, pagination);
            obj.data = list;
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> Update(ModuleColumnEntity entity)
        {
            TData obj = new TData();
            await moduleColumnService.BaseUpdate(entity); 
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Insert(ModuleColumnEntity entity)
        {
            TData obj = new TData();
            await moduleColumnService.BaseInsert(entity);
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Delete(string keyValue)
        {
            TData obj = new TData();
            await moduleColumnService.BaseDeleteEntity(keyValue);
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 私有方法

        #endregion
    }
}
