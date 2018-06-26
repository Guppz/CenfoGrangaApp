using System;
using System.Collections.Generic;
using System.Text;

namespace POJO
{
    public class Animal : BaseEntity
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string categoria { get; set; }
        public int edad { get; set; }
        public string AlimentoFavorito { get; set; }

        public override string ToString()
        {
            return "Animal: " + nombre + " " + fechaNacimiento + " " + categoria + " " + edad + " " + AlimentoFavorito;
        }
    }
}
