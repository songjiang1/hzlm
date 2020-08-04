

using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping
{
    /// <summary> 
    /// 描 述：系统按钮
    /// </summary>
    public class ModuleInstanceMap : EntityTypeConfiguration<ModuleInstanceEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleInstanceEntity>().ToTable("sys_module_instance").HasKey(_ => _.id); 
        }
    }
}
