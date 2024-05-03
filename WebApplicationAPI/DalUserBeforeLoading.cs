using Microsoft.Data.SqlClient;
using System.Data;
using WebApplicationAPI.Constants;

namespace WebApplicationAPI
{
    /// <summary>
    /// build query command
    /// </summary>
    public class DalUserBeforeLoading
    {
        private static readonly string ConnecStr = SystemConstants.AppSetting.ConnectionString;

        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new(storedProcName, connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 12000
            };
            return command;
        }
        /// <summary>
        /// Run stored procedure
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using SqlConnection connection = new(ConnecStr);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }
    }
}
