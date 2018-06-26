using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Crud;
using POJO;

namespace CenfoGrangaApp
{
    class AnimalManagement
    {
        private AnimalesCrudFactory crudFactory;

        public AnimalManagement()
        {
            crudFactory = new AnimalesCrudFactory();
        }

        public void Create(Animal animal)
        {
            var crudAnimal = new AnimalesCrudFactory();
            crudAnimal.Create(animal);

        }
        public void Update(Animal animal)
        {
            var crudAnimal = new AnimalesCrudFactory();
            crudAnimal.Update(animal);
        }
        public List<Animal> RetrieveAll()
        {
            return crudFactory.RetrieveAll<Animal>();
        }
        public List<Animal> RetrieveByName(Animal animal)
        {
            return crudFactory.RetrieveName<Animal>(animal);
        }
        public Animal RetrieveById(Animal animal)
        {
            return crudFactory.Retrieve<Animal>(animal);
        }

    }
}
