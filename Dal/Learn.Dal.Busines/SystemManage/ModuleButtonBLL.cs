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
    public class ModuleButtonBLL 
    {
        private ModuleButtonService service = new ModuleButtonService(); 

        #region 获取数据
      
        public async Task<TData<ModuleButtonEntity>> GetEntity(string id)
        {
            TData<ModuleButtonEntity> obj = new TData<ModuleButtonEntity>();
            obj.data = await service.GetBaseEntity(id);  
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData<List<ModuleButtonEntity>>> GetList(string moduleId)
        { 
            TData<List<ModuleButtonEntity>> obj = new TData<List<ModuleButtonEntity>>();
            var exp = LinqExtensions.True<ModuleButtonEntity>();
            if (string.IsNullOrWhiteSpace(moduleId))
            {
                exp = exp.And(t => t.module_id.Contains(moduleId));
            }
            var list= await service.GetBaseList();
            obj.data = list;
            obj.code = HttpCodeEnum.OK; 
            return obj;
        }
        
        public async Task<TData<List<ModuleButtonEntity>>> GetPageList(string where, Pagination pagination)
        {
            Expression<Func<ModuleButtonEntity, bool>> expression = x=>true;
            TData<List<ModuleButtonEntity>> obj = new TData<List<ModuleButtonEntity>>();
            var list = await service.GetBasePageList(expression, pagination);
            obj.data = list;
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> Update(ModuleButtonEntity entity)
        {
            TData obj = new TData();
            await service.BaseUpdate(entity); 
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Insert(ModuleButtonEntity entity)
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
