using System.ComponentModel.DataAnnotations;

namespace CookieCompany.Model.Fluent
{
    public class SignOn
    {
        [Required(ErrorMessage = "el usuario es requerido")]
        public string username { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
