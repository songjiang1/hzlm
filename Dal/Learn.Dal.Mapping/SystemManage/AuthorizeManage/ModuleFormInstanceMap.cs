

using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary> 
    /// 描 述：系统表单
    /// </summary>
    public class ModuleFormInstanceMap : EntityTypeConfiguration<ModuleFormInstanceEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleFormInstanceEntity>().ToTable("sys_module_forminstance").HasKey(_ => _.id);
        }
    }
}
