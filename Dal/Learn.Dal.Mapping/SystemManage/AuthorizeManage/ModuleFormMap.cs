

using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary>
    /// 描 述：系统表单
    /// </summary>
    public class ModuleFormMap : EntityTypeConfiguration<ModuleFormEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleFormEntity>().ToTable("sys_module_form").HasKey(_ => _.id);
        }
    }
}
