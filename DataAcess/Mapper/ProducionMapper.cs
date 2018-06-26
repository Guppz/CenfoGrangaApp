using DataAcess.Dao;
using POJO;
using System;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ProducionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_ID = "id";
        private const string DB_COL_ID_Animales = "id_animal";
        private const string DB_COL_TIPO_PRODUCTO = "tipo";
        private const string DB_COL_FECHA_PRODUCION = "Fecha_produccion";
        private const string DB_COL_CANTIDAD = "cantidad";
        private const string DB_COL_MEDIDA = "medida";
        private const string DB_COL_CENFO_DOLLAR = "cenfo_Dollar";
        private const string DB_COL_Fecha_inicio = "FechaInicio";
        private const string DB_COL_Fecha_Final = "FechaFinal";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "[dbo].[CRE_PRODUCCIOM_PR]" };
            var c = (Producion)entity;
            operation.AddIntParam(DB_COL_TIPO_PRODUCTO, c.id_animal);
            operation.AddVarcharParam(DB_COL_TIPO_PRODUCTO, c.tipoProducto);
            operation.AddDateParam(DB_COL_FECHA_PRODUCION, c.fechaProducion);
            operation.AddDoubleParam(DB_COL_CANTIDAD, c.cantidad);
            operation.AddVarcharParam(DB_COL_MEDIDA, c.medida);
            operation.AddDoubleParam(DB_COL_CENFO_DOLLAR, c.cenfoDollar);
            return operation;
        }

        public SqlOperation GetRetriveStatementType(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_Animales_Tipo_PR" };
            var c = (Producion)entity;
            operation.AddVarcharParam(DB_COL_TIPO_PRODUCTO, c.tipoProducto);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_One_producion_PR" };

            var c = (Producion)entity;
            operation.AddIntParam(DB_COL_ID, c.id);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_producion_PR" };
            return operation;
        }


        public SqlOperation GetRetriveStatementDate(DateTime fechaInicion , DateTime fechaFinal)
        {
            var operation = new SqlOperation { ProcedureName = "RET_Fecha_Animales_PR" };
            operation.AddDateParam(DB_COL_Fecha_inicio, fechaInicion);
            operation.AddDateParam(DB_COL_Fecha_Final, fechaFinal);
            return operation;
        }

        public SqlOperation GetRetriveStatementDatAndType(BaseEntity entity, DateTime fechaInicion, DateTime fechaFinal)
        {
            var c = (Producion)entity;
            var operation = new SqlOperation { ProcedureName = "[RET_Fecha_Animales_Tipo_PR]" };
            operation.AddVarcharParam(DB_COL_TIPO_PRODUCTO, c.tipoProducto);
            operation.AddDateParam(DB_COL_Fecha_inicio, fechaInicion);
            operation.AddDateParam(DB_COL_Fecha_Final, fechaFinal);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UP_PRODUCCIOM_PR" };
            var c = (Producion)entity;
            operation.AddIntParam(DB_COL_ID, c.id);
            operation.AddIntParam(DB_COL_ID_Animales, c.id_animal);
            operation.AddVarcharParam(DB_COL_TIPO_PRODUCTO, c.tipoProducto);
            operation.AddDateParam(DB_COL_FECHA_PRODUCION, c.fechaProducion);
            operation.AddDoubleParam(DB_COL_CANTIDAD, c.cantidad);
            operation.AddVarcharParam(DB_COL_MEDIDA, c.medida);
            operation.AddDoubleParam(DB_COL_CENFO_DOLLAR, c.cenfoDollar);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var producion = BuildObject(row);
                lstResults.Add(producion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
        
            var producion = new Producion
            {
                id = GetIntValue(row, DB_COL_ID),
                id_animal = GetIntValue(row, DB_COL_ID_Animales),
                tipoProducto = GetStringValue(row, DB_COL_TIPO_PRODUCTO),
                fechaProducion = GetDateValue(row, DB_COL_FECHA_PRODUCION),
                cantidad = GetDoubleValue(row, DB_COL_CANTIDAD),
                medida = GetStringValue(row, DB_COL_MEDIDA),
                cenfoDollar = GetDoubleValue(row, DB_COL_CENFO_DOLLAR)
            };
            return producion;
        }


        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
