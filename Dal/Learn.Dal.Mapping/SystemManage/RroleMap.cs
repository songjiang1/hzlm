
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary>
    /// 描 述：角色
    /// </summary>
    public class RroleMap : EntityTypeConfiguration<RroleEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RroleEntity>().ToTable("sys_role").HasKey(_ => _.id);
        }
    }
}
