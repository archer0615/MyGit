using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace ROG_BackStage.Helpers
{
    public class BaseOrmHelper
    {
        #region 範例
        //public int ProcessVaildationCheckVerifycode(string email, string verifyCode)
        //{
        //    int pkey = 0;
        //    parameters.Clear();
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(SQL_ProcessVaildationCheckVerifycode);
        //        parameters.Add(new SqlParameter("Email", email));
        //        parameters.Add(new SqlParameter("VerifyCode", verifyCode));
        //        var dt = this.oMSSQLHelper.ExecuteQuery(GDPR_ConnStr, sb.ToString(), CommandType.Text, parameters);
        //        if (dt.Rows.Count > 0)
        //        {
        //            pkey = Convert.ToInt32(dt.Rows[0]["id"]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return pkey;
        //}
        //public bool ProcessVaildationUpdateVerifyCodeFlag(int pkey)
        //{
        //    bool result = false;
        //    conditions.Clear();
        //    parameters.Clear();
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        parameters.Add(new SqlParameter("verifyFlag", "1"));
        //        parameters.Add(new SqlParameter("VaildateDate", DateTime.Now));
        //        conditions.Add(new SqlParameter("id", pkey));
        //        var resultInt = this.UpdateWithConnectstring(GDPR_ConnStr, "GDPR_VerifyEmail", parameters, conditions);
        //        if (resultInt > 0)
        //        {
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}
        //public int InsertGDPRIssuesReturnKey(SqlTransaction oSqlTransaction, GDPR_issuesModel item)
        //{
        //    var issues_Id = 0;
        //    parameters.Clear();
        //    try
        //    {
        //        parameters.Add(new SqlParameter("platform_id", item.Platform_id));
        //        parameters.Add(new SqlParameter("sn", item.Sn ?? ""));
        //        parameters.Add(new SqlParameter("email", item.Email));
        //        parameters.Add(new SqlParameter("cusid", item.Cus_Id ?? ""));
        //        parameters.Add(new SqlParameter("login", item.Login ?? ""));
        //        parameters.Add(new SqlParameter("type", item.Type));
        //        parameters.Add(new SqlParameter("range", item.Range ?? ""));

        //        issues_Id = this.InsertWithReturnKey(oSqlTransaction, "GDPR_issues", parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return issues_Id;
        //}
        //public List<GetApplyItemsItem> GetAllApplyItems()
        //{
        //    List<GetApplyItemsItem> results = new List<GetApplyItemsItem>();
        //    parameters.Clear();
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(SQL_GetAllApplyItems);
        //        var dt = this.oMSSQLHelper.ExecuteQuery(GDPR_ConnStr, sb.ToString(), CommandType.Text, parameters);
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                results.Add((GetApplyItemsItem)this.ConvertDataRow(typeof(GetApplyItemsItem), dr));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return results;
        //}
        //public GetApplyItemsItem GetDefaultProductClassInfo()
        //{
        //    GetApplyItemsItem result = new GetApplyItemsItem();
        //    parameters.Clear();
        //    try
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        sb.Append(SQL_GetDefaultProductClassInfo);
        //        var dt = this.oMSSQLHelper.ExecuteQuery(GDPR_ConnStr, sb.ToString(), CommandType.Text, parameters);
        //        if (dt.Rows.Count > 0)
        //        {
        //            result = (GetApplyItemsItem)this.ConvertDataRow(typeof(GetApplyItemsItem), dt.Rows[0]);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}
        #endregion

        protected List<SqlParameter> parameters { get; set; }
        protected List<SqlParameter> conditions { get; set; }
        protected MSSQLHelper oMSSQLHelper { get; set; }
        public BaseOrmHelper()
        {
            parameters = new List<SqlParameter>();
            conditions = new List<SqlParameter>();
            oMSSQLHelper = new MSSQLHelper();
        }
        #region For MSSQLHelper

        protected bool Insert(string connectstring, string TableName, List<SqlParameter> parameters)
        {
            int rows = this.InsertWithConnectstring(connectstring, TableName, parameters);

            return rows > 0 ? true : false;
        }

        protected int InsertWithConnectstring(string connectstring, string TableName, List<SqlParameter> parameters)
        {
            int rows = 0;

            if (parameters.Count > 0)
            {
                string sql = this.GetInsertSQL(TableName, parameters);

                rows = oMSSQLHelper.ExecuteNonQuery(connectstring, sql, CommandType.Text, parameters);

            }

            parameters.Clear();

            return rows;
        }

        protected int InsertWithReturnKey(string connectstring, string TableName, List<SqlParameter> parameters)
        {
            if (parameters.Count == 0)
            {
                return 0;
            }

            string sql = this.GetInsertSQL(TableName, parameters);

            int seq = oMSSQLHelper.ExecuteWithReturnKey(connectstring, sql, CommandType.Text, parameters);
            parameters.Clear();

            return seq;
        }

        protected bool Update(string connectstring, string TableName, List<SqlParameter> parameters, List<SqlParameter> conditions)
        {
            int rows = this.UpdateWithConnectstring(connectstring, TableName, parameters, conditions);

            return rows > 0 ? true : false;
        }

        protected int UpdateWithConnectstring(string connectstring, string TableName, List<SqlParameter> parameters, List<SqlParameter> conditions)
        {
            int rows = 0;

            if (parameters.Count > 0)
            {
                string sql = this.GetUpdateSQL(TableName, parameters, conditions);

                rows = oMSSQLHelper.ExecuteNonQuery(connectstring, sql, CommandType.Text, parameters);
            }

            parameters.Clear();
            conditions.Clear();

            return rows;
        }

        private string GetInsertSQL(string TableName, List<SqlParameter> parameters)
        {
            string sql = string.Empty;

            StringBuilder Columns = new StringBuilder();
            StringBuilder Values = new StringBuilder();

            for (int i = parameters.Count - 1; i >= 0; i--)
            {
                if (parameters[i].Value != null)
                {
                    Columns.Append(parameters[i].ParameterName + ",");
                    Values.Append("@" + parameters[i].ParameterName + ",");
                }
                else
                {
                    parameters.Remove(parameters[i]);
                }
            }

            Columns.Remove(Columns.Length - 1, 1);
            Values.Remove(Values.Length - 1, 1);

            sql = string.Format("INSERT INTO {0}({1}) VALUES({2})", TableName, Columns, Values);

            return sql;
        }

        private string GetUpdateSQL(string TableName, List<SqlParameter> parameters, List<SqlParameter> conditions)
        {
            string sql = string.Empty;

            StringBuilder Columns = new StringBuilder();
            StringBuilder Conditions = new StringBuilder();

            for (int i = parameters.Count - 1; i >= 0; i--)
            {
                if (parameters[i].Value == null)
                {
                    parameters.Remove(parameters[i]);
                    continue;
                }

                // for skip int write to database  
                if (parameters[i].Value.GetType() == typeof(int) && (int)parameters[i].Value == -1)
                {
                    parameters.Remove(parameters[i]);
                    continue;
                }

                // for skip datetime write to database  
                if (parameters[i].Value.GetType() == typeof(DateTime) && (DateTime)parameters[i].Value == DateTime.MaxValue)
                {
                    parameters.Remove(parameters[i]);
                    continue;
                }

                Columns.Append(parameters[i].ParameterName + "=@" + parameters[i].ParameterName + ",");

                if (parameters[i].Value.GetType() == typeof(DateTime) && (DateTime)parameters[i].Value == DateTime.MinValue)
                {
                    parameters[i].Value = DBNull.Value;
                }
            }

            foreach (var condition in conditions)
            {
                if (condition.Value != null)
                {
                    Conditions.Append(" AND " + condition.ParameterName + "=@Con_" + condition.ParameterName);
                    parameters.Add(new SqlParameter("Con_" + condition.ParameterName, condition.Value));
                }
            }
            Columns.Remove(Columns.Length - 1, 1);

            sql = string.Format("UPDATE {0} SET {1} WHERE 1 = 1 {2}", TableName, Columns, Conditions);

            return sql;
        }
        #endregion

        #region for transaction
        protected bool Insert(SqlTransaction oSqlTransaction, string TableName, List<SqlParameter> parameters)
        {
            if (parameters.Count == 0)
            {
                return false;
            }

            string sql = this.GetInsertSQL(TableName, parameters);

            int rows;
            rows = oMSSQLHelper.ExecuteNonQuery(oSqlTransaction, sql, CommandType.Text, parameters);
            parameters.Clear();
            return rows > 0 ? true : false;
        }

        protected int InsertWithReturnKey(SqlTransaction oSqlTransaction, string TableName, List<SqlParameter> parameters)
        {
            if (parameters.Count == 0)
            {
                return 0;
            }

            string sql = this.GetInsertSQL(TableName, parameters);

            int seq = oMSSQLHelper.ExecuteWithReturnKey(oSqlTransaction, sql, CommandType.Text, parameters);
            parameters.Clear();

            return seq;
        }

        protected bool Update(SqlTransaction oSqlTransaction, string TableName, List<SqlParameter> parameters, List<SqlParameter> conditions)
        {
            if (parameters.Count == 0)
            {
                return false;
            }

            string sql = this.GetUpdateSQL(TableName, parameters, conditions);

            int rows;
            rows = oMSSQLHelper.ExecuteNonQuery(oSqlTransaction, sql, CommandType.Text, parameters);
            parameters.Clear();
            conditions.Clear();
            return rows > 0 ? true : false;
        }
        #endregion

        protected dynamic ConvertDataRow(Type type, DataRow row)
        {

            object obj = Activator.CreateInstance(type);

            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Type propertyType = propertyInfo.PropertyType;

                if (!row.Table.Columns.Contains(propertyInfo.Name))
                {
                    continue;
                }

                object data = row[propertyInfo.Name];

                if (propertyType == typeof(bool))
                {
                    propertyInfo.SetValue(obj, Convert.ToBoolean(data));
                    continue;
                }

                if (propertyType == typeof(string))
                {
                    propertyInfo.SetValue(obj, data.ToString());
                    continue;
                }

                if (propertyType == typeof(Int16))
                {
                    propertyInfo.SetValue(obj, Convert.ToInt16(data));
                    continue;
                }

                if (propertyType == typeof(Int32))
                {
                    propertyInfo.SetValue(obj, Convert.ToInt32(data));
                    continue;
                }
                if (propertyType == typeof(Double))
                {
                    propertyInfo.SetValue(obj, Convert.ToDouble(data));
                    continue;
                }

                if (propertyType == typeof(Int64))
                {
                    propertyInfo.SetValue(obj, Convert.ToInt64(data));
                    continue;
                }

                if (propertyType == typeof(Decimal))
                {
                    propertyInfo.SetValue(obj, Convert.ToDecimal(data));
                    continue;
                }

                if (propertyType == typeof(DateTime))
                {
                    if (data == DBNull.Value)
                    {
                        propertyInfo.SetValue(obj, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(obj, Convert.ToDateTime(data));
                    }

                    continue;
                }

                if (propertyType == typeof(Decimal?))
                {
                    if (data == DBNull.Value)
                    {
                        propertyInfo.SetValue(obj, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(obj, (Decimal?)Convert.ToDecimal(data));
                    }
                    continue;
                }
                if (propertyType == typeof(int?))
                {
                    if (data == DBNull.Value)
                    {
                        propertyInfo.SetValue(obj, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(obj, (int?)Convert.ToInt32(data));
                    }
                    continue;
                }
                if (propertyType == typeof(long?))
                {
                    if (data == DBNull.Value)
                    {
                        propertyInfo.SetValue(obj, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(obj, (long?)Convert.ToInt32(data));
                    }
                    continue;
                }
                if (propertyType == typeof(DateTime?))
                {
                    if (data == DBNull.Value)
                    {
                        propertyInfo.SetValue(obj, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(obj, (DateTime?)Convert.ToDateTime(data));
                    }
                    continue;
                }
            }

            return obj;
        }
    }
    public class MSSQLHelper
    {
        #region for general 
        public int ExecuteNonQuery(string connString, string cmdText, CommandType cmdType, List<SqlParameter> parameters)
        {
            int rows = 0;

            using (SqlConnection _conn = new SqlConnection(connString))
            {
                _conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, _conn))
                {
                    cmd.CommandType = cmdType;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    rows = cmd.ExecuteNonQuery();
                }
            }
            parameters.Clear();
            return rows;
        }

        public bool ExecuteHasRowsQuery(string connString, string cmdText, CommandType cmdType, List<SqlParameter> parameters)
        {
            bool hasRows = false;

            using (SqlConnection _conn = new SqlConnection(connString))
            {
                _conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, _conn))
                {
                    cmd.CommandType = cmdType;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    using (SqlDataReader _rdr = cmd.ExecuteReader())
                    {
                        hasRows = _rdr.HasRows;
                    }
                }
            }
            parameters.Clear();
            return hasRows;
        }

        public DataTable ExecuteQuery(string connString, string cmdText, CommandType cmdType, List<SqlParameter> parameters)
        {
            DataTable oDataTable = new DataTable();

            using (SqlConnection _conn = new SqlConnection(connString))
            {
                _conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, _conn))
                {
                    cmd.CommandType = cmdType;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    using (SqlDataAdapter apr = new SqlDataAdapter(cmd))
                    {
                        apr.Fill(oDataTable);
                    }
                }
            }
            parameters.Clear();
            return oDataTable;
        }

        public int ExecuteWithReturnKey(string connString, string cmdText, CommandType cmdType, List<SqlParameter> parameters)
        {
            int seq = 0;

            cmdText += ";SELECT SCOPE_IDENTITY();";

            using (SqlConnection _conn = new SqlConnection(connString))
            {
                _conn.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, _conn))
                {
                    cmd.CommandType = cmdType;
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }

                    object identity = cmd.ExecuteScalar();

                    seq = int.Parse(identity.ToString());
                }
            }
            parameters.Clear();
            return seq;
        }
        #endregion

        #region for transaction
        public int ExecuteNonQuery(SqlTransaction oSqlTransaction, string cmdText, CommandType cmdType, List<SqlParameter> parameters)
        {
            int rows = 0;

            using (SqlCommand cmd = new SqlCommand(cmdText, oSqlTransaction.Connection))
            {
                cmd.Transaction = oSqlTransaction;
                cmd.CommandType = cmdType;
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                rows = cmd.ExecuteNonQuery();
            }
            parameters.Clear();
            return rows;
        }

        public int ExecuteWithReturnKey(SqlTransaction oSqlTransaction, string cmdText, CommandType cmdType, List<SqlParameter> parameters)
        {
            int seq = 0;

            cmdText += ";SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(cmdText, oSqlTransaction.Connection))
            {
                cmd.Transaction = oSqlTransaction;
                cmd.CommandType = cmdType;
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                object identity = cmd.ExecuteScalar();

                seq = int.Parse(identity.ToString());
            }
            parameters.Clear();
            return seq;
        }
        #endregion
    }
}