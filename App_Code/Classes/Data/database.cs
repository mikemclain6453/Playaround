using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using data.construct;


namespace data.database
{
    #region Database Handling
    public class dbhandling
    {
        public DataTable dbActionSet(SqlCommand command, databaseAction action)
        {
            //Connecting to a database
            string connectdbbe = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;

            //Declare connecting to a database with the name dbcon
            SqlConnection dbcon;
            //Using the connection
            dbcon = new SqlConnection(connectdbbe);
            command.Connection = dbcon;
            dbcon.Open();
            DataTable result = new DataTable();
            if (action == databaseAction.Execute)
            {
                command.ExecuteNonQuery();
            }
            else if (action == databaseAction.Read)
            {
                SqlDataAdapter ad = new SqlDataAdapter(command);
                ad.Fill(result);
            }
            dbcon.Close();

            return result;
        }
    }
    #endregion

    public class dbQueryBuilder<T>
    {
        public functionality func = new functionality();
        public genericFunctions<dynamic> gfunc = new genericFunctions<dynamic>();

        public string insertBuilder(databaseTable table)
        {
            string[][] tableFormat = gfunc.processTableFunction(table,tableFunction.tableFormatChoose);

            string columnCompiled = columnCompiler(tableFormat);
            string columnIdentifiers = columnIdentifierCompiler(tableFormat);

            string compiledString = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", tableFormat[0][0], columnCompiled, columnIdentifiers);
            compiledString = compiledString.Replace("(@Id,", "(");
            compiledString = compiledString.Replace("(id,", "(");

            return compiledString;
        }

        public string updateBuilder(dynamic map,databaseTable table)
        {
            string[][] tableFormat = gfunc.processTableFunction(table, tableFunction.tableFormatChoose);
            RepoMapConnect RMP = new RepoMapConnect(table);
            string updateList = string.Join(",", RMP.repo.paramList(map));

            return string.Format("UPDATE {0} SET {1} WHERE id=@Id;", tableFormat[0][0], updateList.Replace("id=@Id,", "").Replace("*,", ""));
        }

        public SqlCommand deleteBuilder(databaseTable dbt, T map, params string[] paramList)
        {
            genericFunctions<string[][]> gfunc = new genericFunctions<string[][]>();
            string[][] tableFormat = gfunc.processTableFunction(dbt, tableFunction.tableFormatChoose);

            string baseString = string.Format("DELETE FROM {0}", tableFormat[0][0]);

            for (int i = 1; paramList.Length > i; i++)
            {
                if (i == 1)
                {
                    baseString += " WHERE ";
                }

                baseString += paramList[i];

                if (paramList.Length > (i + 1))
                {
                    baseString += " AND ";
                }
            }
            baseString += ";";

            SqlCommand command = new SqlCommand(baseString);
            return command;
        }

        public string columnCompiler(string[][] value)
        {
            string compiledString = "";

            for (int i = 0; value[1].Length > i; i++)
            {
                compiledString += value[1][i];

                if (value[1].Length > (i + 1))
                {
                    compiledString += ",";
                }
            }
            return compiledString;
        }

        public string columnIdentifierCompiler(string[][] value)
        {
            string compiledString = "";

            for (int i = 0; value[1].Length > i; i++)
            {
                compiledString += "@" + func.FirstCharToUpper(value[1][i]);

                if (value[1].Length > (i + 1))
                {
                    compiledString += ",";
                }
            }
            return compiledString;
        }


    }
}