using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class LogsRepository : ISqlFunction<LogsMap>
{
    private sqlFunction<LogsMap> sqlFunc = new sqlFunction<LogsMap>();

    private string[] paramList(LogsMap data)
    {
        List<string> tempList = new List<string>();
        tempList.Add("*");
        
        if (data.id != 0)
        {
            tempList.Add("id=@Id");
        }

        if (data.LT != null)
        {
            tempList.Add("LT=@LT");
        }

        if (data.timeOfEvent != null)
        {
            tempList.Add("timeOfEvent=@TimeOfEvent");
        }

        if (data.uid1 != 0)
        {
            tempList.Add("uid1=@Uid1");
        }

        if (data.uid2 != 0)
        {
            tempList.Add("uid2=@Uid2");
        }

        if (data.logData != null)
        {
            tempList.Add("logData=@LogData");
        }

        return tempList.ToArray();
    }

    public LogsMap populateMap(DataRow row)
    {
        LogsMap temp = new LogsMap();
        
        temp.id = row.Field<int>("Id");
        temp.LT = row.Field<logType>("LT");
        temp.timeOfEvent = row.Field<DateTime>("TimeOfEvent");
        temp.uid1 = row.Field<int>("Uid1");
        temp.uid2 = row.Field<int>("Uid2");
        temp.logData = row.Field<string>("LogData");

        return temp;
    }

    public SqlCommand sqlParamPopulate(LogsMap map, SqlCommand command)
    {
        
        if (map.id != 0)
        {
            command.Parameters.Add(new SqlParameter("id", map.id));
        }

        if (map.LT != null)
        {
            command.Parameters.Add(new SqlParameter("LT", map.LT));
        }

        if (map.timeOfEvent != null)
        {
            command.Parameters.Add(new SqlParameter("timeOfEvent", map.timeOfEvent));
        }

        if (map.uid1 != 0)
        {
            command.Parameters.Add(new SqlParameter("uid1", map.uid1));
        }

        if (map.uid2 != 0)
        {
            command.Parameters.Add(new SqlParameter("uid2", map.uid2));
        }

        if (map.logData != null)
        {
            command.Parameters.Add(new SqlParameter("logData", map.logData));
        }


        return command;
    }

    public void executeData(LogsMap data, sqlStatementType sql)
    {
        if (sql == sqlStatementType.Insert)
        {
            sqlFunc.insertData(data, databaseTable.Logs);
        }
        else if (sql == sqlStatementType.Update)
        {
            sqlFunc.updateData(data, databaseTable.Logs);
        }
        else if (sql == sqlStatementType.Delete)
        {
            sqlFunc.deleteData(data, databaseTable.Logs, paramList(data));
        }
    }

    public LogsMap selectData(LogsMap data)
    {
        data = sqlFunc.selectBuilder(databaseTable.Logs, data, paramList(data));
        return data;
    }
}

