
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Entity.SystemManage;
using Microsoft.EntityFrameworkCore;

namespace Learn.Dal.Mapping.SystemManage
{
    /// <summary>
    ///  机构
    /// </summary>
    public class OrganizeMap : EntityTypeConfiguration<OrganizeEntity>
    {
        public override void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizeEntity>().ToTable("sys_organize").HasKey(_ => _.id);
        }
    }
}
