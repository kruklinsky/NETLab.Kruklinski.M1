using App_Code.Domain.Model.Membership;
using System.Data.Entity;

namespace App_Code.Domain
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("EFDbConnection") { }

        #region Membership
        public virtual DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}