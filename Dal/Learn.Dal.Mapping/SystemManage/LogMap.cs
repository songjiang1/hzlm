
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary>
    /// 描 述： 日志
    /// </summary>
    public class LogMap : EntityTypeConfiguration<LogEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEntity>().ToTable("sys_log").HasKey(_ => _.id);
        }
    }
}
