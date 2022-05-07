using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Auto
    {
        public int Id { get; set; }
        [ForeignKey("Marca")]
        public int IdMarca { get; set; }
        public string NombreAuto { get; set; }
        public int Annio { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public Marca Marca { get; set; }
    }
}
