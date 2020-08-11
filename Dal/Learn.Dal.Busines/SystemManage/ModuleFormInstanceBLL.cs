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
    public class ModuleFormInstanceBLL
    {
        private ModuleFormInstanceService service = new ModuleFormInstanceService(); 

        #region 获取数据
      
        public async Task<TData<ModuleFormInstanceEntity>> GetEntity(string id)
        {
            TData<ModuleFormInstanceEntity> obj = new TData<ModuleFormInstanceEntity>();
            obj.data = await service.GetBaseEntity(id);  
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData<List<ModuleFormInstanceEntity>>> GetList()
        {
            TData<List<ModuleFormInstanceEntity>> obj = new TData<List<ModuleFormInstanceEntity>>();
            var list= await service.GetBaseList();
            obj.data = list;
            obj.code = HttpCodeEnum.OK; 
            return obj;
        }
        
        public async Task<TData<List<ModuleFormInstanceEntity>>> GetPageList(string where, Pagination pagination)
        {
            Expression<Func<ModuleFormInstanceEntity, bool>> expression = x=>true;
            TData<List<ModuleFormInstanceEntity>> obj = new TData<List<ModuleFormInstanceEntity>>();
            var list = await service.GetBasePageList(expression, pagination);
            obj.data = list;
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData> Update(ModuleFormInstanceEntity entity)
        {
            TData obj = new TData();
            await service.BaseUpdate(entity); 
            obj.code = HttpCodeEnum.OK;
            return obj;
        }
        public async Task<TData> Insert(ModuleFormInstanceEntity entity)
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
