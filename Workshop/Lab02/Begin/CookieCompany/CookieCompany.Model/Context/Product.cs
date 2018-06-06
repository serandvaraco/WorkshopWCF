namespace CookieCompany.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Invent = new HashSet<Invent>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre de producto")]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Subir Fotografía")]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invent> Invent { get; set; }
    }
}
