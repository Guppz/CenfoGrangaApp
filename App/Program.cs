using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POJO;

namespace CenfoGrangaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String fecha = "2015-01-01";
            Animal animal = new Animal();
            animal.nombre = "Lara";
            animal.fechaNacimiento = Convert.ToDateTime(fecha);
            animal.categoria = 1;
            animal.AlimentoFavorito = "Pasto";
            Console.WriteLine(animal.fechaNacimiento);
            Console.ReadKey();
        }
    }
}
