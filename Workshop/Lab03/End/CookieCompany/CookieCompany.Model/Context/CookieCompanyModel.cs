namespace CookieCompany.Model.Context
{
    using System.Data.Entity;
    using System.Threading.Tasks;

    public partial class CookieCompanyModel : DbContext, ICookieCompanyModel
    {
        public CookieCompanyModel()
            : base("name=CookieCompanyModel")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Invent> Invent { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Invent)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }

        Task ICookieCompanyModel.SaveChangesAsync() => SaveChangesAsync();

    }
}
