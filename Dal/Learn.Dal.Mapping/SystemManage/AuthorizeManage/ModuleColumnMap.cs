

using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary> 
    /// 描 述：系统视图
    /// </summary>
    public class ModuleColumnMap : EntityTypeConfiguration<ModuleColumnEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleColumnEntity>().ToTable("sys_module_column").HasKey(_ => _.id);
            //一对多
            modelBuilder.Entity<ModuleColumnEntity>().HasOne(p => p.moduleEntity).WithMany(b => b.moduleColumns).HasForeignKey(p => p.module_id);

        }
    }
}
