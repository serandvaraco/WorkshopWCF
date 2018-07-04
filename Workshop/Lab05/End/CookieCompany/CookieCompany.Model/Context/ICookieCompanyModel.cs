using System.Data.Entity;
using System.Threading.Tasks;

namespace CookieCompany.Model.Context
{
    public interface ICookieCompanyModel
    {
        DbSet<Invent> Invent { get; set; }
        DbSet<Product> Product { get; set; }
        Task SaveChangesAsync();
    }
}