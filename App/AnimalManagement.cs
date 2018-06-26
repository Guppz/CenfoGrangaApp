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
            var crudCustomer = new AnimalesCrudFactory();
            crudCustomer.Create(animal);

        }
    }
}
