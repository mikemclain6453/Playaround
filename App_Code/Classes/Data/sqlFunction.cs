using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using data.database;


public class sqlFunction<T> where T : new()
{
    #region private objects
    private dbhandling db = new dbhandling();
    private dbQueryBuilder<T> dbq = new dbQueryBuilder<T>();
    private genericFunctions<T> gfunc = new genericFunctions<T>();
    public functionality func = new functionality();
    #endregion

    public SqlCommand StringBuilder(databaseTable dbt, T map, params string[] paramList)
    {
        genericFunctions<string[][]> gfunc = new genericFunctions<string[][]>();
        string[][] tableFormat = gfunc.processTableFunction(dbt, tableFunction.tableFormatChoose);

        string baseString = string.Format("SELECT {1} FROM {0}", tableFormat[0][0],paramList[0]);

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

        return sqlParamPopulate(map, command, dbt);
    }

    #region Select

    public DataTable dbActionSet(SqlCommand query, databaseAction dba)
    {
        return db.dbActionSet(query, dba);
    }

    public T selectData(SqlCommand query, databaseTable dbt)
    {
        T results = processMap(dbActionSet(query, databaseAction.Read), dbt);
        return results;
    }

    public List<T> selectDataList(SqlCommand query, databaseTable dbt)
    {
        List<T> results = processList(dbActionSet(query, databaseAction.Read), dbt);
        return results;
    }

    public T selectBuilder(databaseTable dbt, T AM, params string[] paramList)
    {
        SqlCommand command = StringBuilder(dbt, AM, paramList);
        return selectData(command, dbt);
    }

    public List<T> selectBuilderList(databaseTable dbt, T AM, params string[] paramList)
    {
        SqlCommand command = StringBuilder(dbt, AM, paramList);
        return selectDataList(command, dbt);
    }

    public T processMap(DataTable Data, databaseTable dbt)
    {
        T results = new T();
        foreach (DataRow row in Data.Rows)
        {
            results = gfunc.processTableFunction(dbt, tableFunction.processRow, row);
        }
        return results;
    }

    public List<T> processList(DataTable Data, databaseTable dbt)
    {
        List<T> results = new List<T>();
        foreach (DataRow row in Data.Rows)
        {
            results.Add(gfunc.processTableFunction(dbt,tableFunction.processRow, row));
        }
        return results;
    }

    SqlCommand sqlParamPopulate(T value, SqlCommand command, databaseTable dbTable)
    {
        return gfunc.processTableFunction(dbTable, tableFunction.sqlParamPopulate, value, command );
    }
    #endregion Select

    #region Execution Data

    public void insertData(T value, databaseTable dbTable)
    {
        SqlCommand query = new SqlCommand(dbq.insertBuilder(dbTable));
        queryExecution(value, query, dbTable);
    }

    public void updateData(T value, databaseTable dbTable)
    {
        SqlCommand query = new SqlCommand(dbq.updateBuilder(value,dbTable));
        queryExecution(value, query, dbTable);
    }

    public void deleteData(T value, databaseTable dbTable, params string[] paramList)
    {
        SqlCommand query = dbq.deleteBuilder(dbTable, value, paramList);
        query = sqlParamPopulate(value, query, dbTable);
        executeQuery(query);
    }

    public void queryExecution(T value, SqlCommand command, databaseTable dbTable)
    {
        executeQuery(sqlParamPopulate(value, command, dbTable));
    }

    public void executeQuery(SqlCommand value)
    {
        db.dbActionSet(value, databaseAction.Execute);
    }

    #endregion
}