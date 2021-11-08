using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ArhamTechnosoftLoyalty.DAL.Data
{
    public static class NpgHelper
    {
        public static IEnumerable<T> QueryStoredProcPgSql<T>(this IDbConnection connection, string procName, dynamic parameters)
        {
            IDbTransaction transaction = connection.BeginTransaction();

            var resultsReference = (IDictionary<string, object>)connection.Query<dynamic>("\"" + procName + "\"",
                (object)parameters, commandType: CommandType.StoredProcedure, transaction: transaction).Single();
            string resultSetName = (string)resultsReference[procName];
            string resultSetReferenceCommand = string.Format(@"FETCH ALL IN ""{0}""", resultSetName);

            var result = connection.Query<T>(resultSetReferenceCommand,
                null, commandType: CommandType.Text, transaction: transaction);

            transaction.Commit();

            return result;
        }
    }
}
