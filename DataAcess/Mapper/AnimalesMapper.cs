using DataAcess.Dao;
using POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class AnimalesMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "id";
        private const string DB_COL_ID_Animales = "Id_animal";
        private const string DB_COL_NOMBRE = "Nombre";
        private const string DB_COL_FECHA_NACIMIENTO = "Fecha_de_nacimiento";
        private const string DB_COL_CATEGORIA = "categoria";
        private const string DB_COL_EDAD = "edad";
        private const string DB_COL_ALIMENTO_FAVORITO = "Alimento_favorito";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "[dbo].[CRE_ANIMALES_PR]" };
            var c = (Animal)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre);
            operation.AddDateParam(DB_COL_FECHA_NACIMIENTO, c.fechaNacimiento);
            operation.AddVarcharParam(DB_COL_CATEGORIA, c.categoria);
            operation.AddVarcharParam(DB_COL_ALIMENTO_FAVORITO, c.AlimentoFavorito);
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ONE_Animales_PR" };

            var c = (Animal)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }

        public SqlOperation GetRetriveStatementName(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "[RET_ALL_Animales_Nombres_PR]" };

            var c = (Animal)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_Animales_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UP_ANIMALES_PR" };
            var c = (Animal)entity;
            operation.AddIntParam(DB_COL_ID_Animales, c.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.nombre);
            operation.AddDateParam(DB_COL_FECHA_NACIMIENTO, c.fechaNacimiento);
            operation.AddVarcharParam(DB_COL_CATEGORIA, c.categoria);
            operation.AddVarcharParam(DB_COL_ALIMENTO_FAVORITO, c.AlimentoFavorito);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var animal = BuildObject(row);
                lstResults.Add(animal);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
        
            var animal = new Animal
            {
                Id = GetIntValue(row, DB_COL_ID),
                nombre = GetStringValue(row, DB_COL_NOMBRE),
                fechaNacimiento = GetDateValue(row, DB_COL_FECHA_NACIMIENTO),
                categoria = GetStringValue(row, DB_COL_CATEGORIA),
                edad = GetIntValue(row, DB_COL_EDAD),
                AlimentoFavorito = GetStringValue(row, DB_COL_ALIMENTO_FAVORITO),
            };

            return animal;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
