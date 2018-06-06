namespace CookieCompany.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invent")]
    public partial class Invent
    {
        public int Id { get; set; }

        [Display(Name = "Fecha de inventario")]
        public DateTime Date { get; set; }
        [Display(Name = "Cantidad de Inventario")]
        public int Quantity { get; set; }
        [Display(Name = "Producto")]
        public int ProductId { get; set; }
       
        public virtual Product Product { get; set; }
    }
}
