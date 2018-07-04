using System.Threading.Tasks;

namespace CookieCompany.Model.Context
{
    public partial class CookieCompanyDBEntities : ICookieCompanyModel
    {
        Task ICookieCompanyModel.SaveChangesAsync()
        {
            return this.SaveChangesAsync();
        }
    }
}
