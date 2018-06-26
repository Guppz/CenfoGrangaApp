using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Crud;
using POJO;

namespace CenfoGrangaApp
{
    class ProducionManagement
    {
        private ProducionCrudFactory crudFactory;

        public ProducionManagement()
        {
            crudFactory = new ProducionCrudFactory();
        }

        public void Create(Producion prod)
        {
            var crudAnimal = new ProducionCrudFactory();
            crudAnimal.Create(prod);

        }
        public void Update(Producion prod)
        {
            var crudAnimal = new ProducionCrudFactory();
            crudAnimal.Update(prod);
        }
        public List<Producion> RetrieveAll()
        {
            return crudFactory.RetrieveAll<Producion>();
        }
        public List<Producion> RetrieveType(Producion prod)
        {
            return crudFactory.RetrieveType<Producion>(prod);
        }
        public List<Producion> RetrieveDate(DateTime fi , DateTime ff)
        {
            return crudFactory.RetrieveDate<Producion>(fi,ff);
        }
        public List<Producion> RetrieveDateAndType(DateTime fi, DateTime ff, Producion prod)
        {
            return crudFactory.RetrieveDateAndType<Producion>(prod,fi, ff);
        }

        public Producion RetrieveById(Producion animal)
        {
            return crudFactory.Retrieve<Producion>(animal);
        }



    }
}
