
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary>
    /// 描 述：用户角色关系
    /// </summary>
    public class UserRelationMap : EntityTypeConfiguration<UserRelationEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRelationEntity>().ToTable("sys_user_relation").HasKey(_ => _.id);
        }
    }
}
