
using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary>
    /// 描 述：系统功能
    /// </summary>
    public class ModuleMap : EntityTypeConfiguration<ModuleEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleEntity>().ToTable("sys_module").HasKey(_ => _.id);
        }
    }
}
