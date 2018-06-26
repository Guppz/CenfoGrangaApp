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
        static AnimalManagement am = new AnimalManagement();
        static ProducionManagement pm = new ProducionManagement();
        public static void Main(string[] args)
        {
            try
            {
                menu();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
        static public void menu()
        {
            Console.WriteLine("La granja cenfotec lleno de animales");
            Console.WriteLine("1.Cambiar infromacion de algun animal o su produccion");
            Console.WriteLine("2.Buscar por Nombre");
            Console.WriteLine("3.Buscar por tipo de producto");
            Console.WriteLine("4.Busca  por fecha de producion");
            Console.WriteLine("5.Busca  por fecha de producion y tipo");
            Console.WriteLine("6.Salir");
            int menuOp = Convert.ToInt32(Console.ReadLine());
            switch (menuOp)
            {
                case 1:
                    Update();
                    break;
                case 2:BuscarNombre();
                    break;
                case 3:BuscarTipo();
                    break;
                case 4:BuscarFecha();
                    break;
                case 5:BuscarFechaYTipo();
                    break;
                case 6:Environment.Exit(0);
                    break;
            }
        }

        static public void Update()
        {
            Console.WriteLine("Quiere cambiar aniaml o su producion");
            Console.WriteLine("Precione 1 para animal o 2 para producion");
            int menuOp = Convert.ToInt32(Console.ReadLine());
            switch (menuOp)
            {
                case 1:
                    UpdateAnimal();
                    break;
                case 2:
                    UpdateProducion();
                    break;
            }

            }



            static public void UpdateAnimal()
        {
            bool salir = true;
            Animal animal = new Animal();
            List<Animal> listaAnimales = am.RetrieveAll();
            imprimirAnimal(listaAnimales);
            Console.WriteLine("Digite el id del Animal que quiere cambiar su info");
            int id = Convert.ToInt16(Console.ReadLine());
            animal.Id = id;
            animal = am.RetrieveById(animal);
            do
            {
                Console.WriteLine("Que quiere cambiar");
                Console.WriteLine("1.Nombre");
                Console.WriteLine("2.Categoria");
                Console.WriteLine("3.Fecha de nacimiento");
                Console.WriteLine("4.Alimento Favorito");
                Console.WriteLine("5.Salir");

                int menuOp = Convert.ToInt32(Console.ReadLine());
                switch (menuOp)
                {
                    case 1:
                        Console.WriteLine("Nuevo nombre");
                        animal.nombre = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Nueva tipo de animal Vaca ,Gallina o Cerdo");
                        animal.categoria = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Nueva Fecha de nacimiento");
                        animal.fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Nueva Alimento Favorito");
                        animal.AlimentoFavorito = Console.ReadLine();
                        break;
                    case 5:
                        salir = false;
                        break;

                }

            } while (salir == true);
            am.Update(animal);
            menu();
        }

        static public void UpdateProducion()
        {
            bool salir = true;
            Producion producion = new Producion();
            List<Producion> listaProd = pm.RetrieveAll();
            imprimirProd(listaProd);
            Console.WriteLine("Id de la producion que va cambiar");
            int id = Convert.ToInt16(Console.ReadLine());
            producion.id = id;
            producion = pm.RetrieveById(producion);
            do
            {
                Console.WriteLine("Producion");
                Console.WriteLine("1.Tipo de producto");
                Console.WriteLine("2.Fecha de producion");
                Console.WriteLine("3.Cantidad producida");
                Console.WriteLine("4.Medida");
                Console.WriteLine("5.Cenfo Dollar");
                Console.WriteLine("6.Salir");
                int menuOp = Convert.ToInt32(Console.ReadLine());
                switch (menuOp)
                {
                    case 1:
                        Console.WriteLine("Nueva Tipo de producto");
                        producion.tipoProducto = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Nueva Fecha de producion");
                        producion.fechaProducion = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Nueva Cantidad producida");
                        producion.cantidad = Convert.ToDouble(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Nueva Medida");
                        producion.medida = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Nueva Ganacia");
                        producion.cenfoDollar = Convert.ToDouble(Console.ReadLine());
                        break;
                    case 6:
                        salir = false;
                        break;
                }
            } while (salir == true);
            pm.Update(producion);
            menu();
        }


        static void BuscarNombre()
        {
            Animal animal = new Animal();
            Console.WriteLine("Nombre que quiere buscar");
            animal.nombre = Console.ReadLine();
            List<Animal> ListaAnimal= am.RetrieveByName(animal);
            imprimirAnimal(ListaAnimal);
            menu();
        }
        static void BuscarTipo()
        {
            Producion animal = new Producion();
            Console.WriteLine("Que tipo de producto quiere buscar");
            animal.tipoProducto = Console.ReadLine();
            List<Producion> ListaAnimal = pm.RetrieveType(animal);
            imprimirProd(ListaAnimal);
            menu();
        }

        static void BuscarFecha()
        {
            Producion prod = new Producion();
            Console.WriteLine("Fechas de incio");
            DateTime fechaInicio = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Fechas de Final");
            DateTime fechaFinal = Convert.ToDateTime(Console.ReadLine());
            List<Producion> ListaAnimal = pm.RetrieveDate(fechaInicio, fechaFinal);
            imprimirProd(ListaAnimal);
            menu();
        }
        static void BuscarFechaYTipo()
        {
            Producion prod = new Producion();
            Console.WriteLine("Fechas de incio");
            DateTime fechaInicio = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Fechas de Final");
            DateTime fechaFinal = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Tipo de producto");
            prod.tipoProducto = Console.ReadLine();
            List<Producion> ListaAnimal = pm.RetrieveDateAndType(fechaInicio, fechaFinal, prod);
            imprimirProd(ListaAnimal);
            menu();
        }

        static void imprimirAnimal(List<Animal>lista) {
            foreach (Animal animales in lista)
            {
                Console.WriteLine(animales.ToString());
            }

        }
        static void imprimirProd(List<Producion> lista)
        {
            foreach (Producion prod in lista)
            {
                Console.WriteLine(prod.ToString());
            }

        }


    }
}


