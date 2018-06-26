using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POJO;
using DataAcess.Mapper;
using DataAcess.Dao;
namespace DataAcess.Crud
{
    public class AnimalesCrudFactory : CrudFactory
    {

        AnimalesMapper mapper;

        public AnimalesCrudFactory() : base()
        {
            mapper = new AnimalesMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var animal = (Animal)entity;
            var sqlOperation = mapper.GetCreateStatement(animal);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }





        public override List<T> RetrieveAll<T>()
        {
            var lstAnimales = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAnimales.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAnimales;
        }

 

        public List<T> RetrieveName<T>(Animal animal)
        {
            var lstAnimales = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementName(animal));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAnimales.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

      
            return lstAnimales;
        }

        public override void Update(BaseEntity entity)
        {
            var animal = (Animal)entity;
            var sqlOperation = mapper.GetUpdateStatement(animal);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}

