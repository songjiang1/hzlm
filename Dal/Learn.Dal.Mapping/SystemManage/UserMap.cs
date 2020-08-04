
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary>
    /// 描 述：用户
    /// </summary>
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("sys_user").HasKey(_ => _.id);
        }
    }
}
