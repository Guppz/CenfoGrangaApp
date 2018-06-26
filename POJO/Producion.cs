using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POJO
{
    public class Producion : BaseEntity
    {
        public int id { get; set; }
        public int id_animal { get; set; }
        public string tipoProducto { get; set; }
        public DateTime fechaProducion { get; set; }
        public double cantidad { get; set; }
        public String medida { get; set; }
        public double cenfoDollar { get; set; }

        public override string ToString()
        {
            return "Prod: Id: " + id + ", Id Animal: " + id_animal + ", Tipo: " + tipoProducto + ", Fecha: " + fechaProducion + 
           ", Cantidad: " + cantidad+" "+ medida + ", cenfoDollar: " + cenfoDollar;
        }
    }
}
