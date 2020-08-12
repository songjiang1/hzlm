

using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping
{
    /// <summary> 
    /// 描 述：系统按钮
    /// </summary>
    public class ModuleButtonMap : EntityTypeConfiguration<ModuleButtonEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleButtonEntity>().ToTable("sys_module_button").HasKey(_ => _.id);
            // 关系配置 
            modelBuilder.Entity<ModuleButtonEntity>().HasOne(p => p.moduleEntity).WithMany(b =>b.moduleButtons).HasForeignKey(p => p.module_id);
        }
    }
}
