using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ViewModels
{
    public class vmAuto
    {
        public int Id { get; set; }
        public string NombreAuto { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public string NombreMarca { get; set; }

    }
}
