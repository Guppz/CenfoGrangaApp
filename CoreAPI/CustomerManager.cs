
using DataAcess.Crud;
using POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CustomerManager : BaseManager
    {
        private AnimalesCrudFactory crudAnimal;

        public CustomerManager()
        {
            crudAnimal = new AnimalesCrudFactory();
        }

        public void Create(Animal an)
        {
            try
            {
                var c = crudAnimal.Retrieve<Animal>(an);

                if (c != null)
                {
                    //Customer already exist
                    throw new BussinessException(3);
                }
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Animal> RetrieveAll()
        {
            return crudAnimal.RetrieveAll<Animal>();
        }

        public Animal RetrieveById(Animal an)
        {
            return crudAnimal.Retrieve<Animal>(an);
        }

        internal void Update(Animal an)
        {
            crudAnimal.Update(an);
        }

        internal void Delete(Animal an)
        {
            crudAnimal.Delete(an);
        }
    }
}
