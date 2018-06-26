using System;
using System.Collections.Generic;
using DataAcess.Dao;
using Entities_POJO;
using POJO;

namespace DataAcess.Mapper
{
    public class AppMessageMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "id";
        private const string DB_COL_TEXT = "descripsion";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_Message_PR" };
            var c = (Message)entity;
            operation.AddVarcharParam(DB_COL_TEXT, c.descripsion);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_Message_PR" };
            var c = (Message)entity;
            operation.AddIntParam(DB_COL_ID, c.id);
            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_Message_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_Message_PR" };
            var c = (Message)entity;
            operation.AddIntParam(DB_COL_ID, c.id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_Message_PR" };
            var c = (Message)entity;
            operation.AddIntParam(DB_COL_ID, c.id);
            operation.AddVarcharParam(DB_COL_ID, c.descripsion);
            return operation;
        }
    
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var appMessage = BuildObject(row);
                lstResults.Add(appMessage);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var appMessage = new Message
            {
                id= GetIntValue(row, DB_COL_ID),
                descripsion= GetStringValue(row, DB_COL_TEXT)
            };

            return appMessage;
        }
    }
}