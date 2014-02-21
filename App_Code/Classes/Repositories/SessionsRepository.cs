using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class SessionsRepository : ISqlFunction<SessionsMap>
{
    private sqlFunction<SessionsMap> sqlFunc = new sqlFunction<SessionsMap>();

    private string[] paramList(SessionsMap data)
    {
        List<string> tempList = new List<string>();
        tempList.Add("*");
        
        if (data.id != 0)
        {
            tempList.Add("id=@Id");
        }

        if (data.expiration.Millisecond > 1)
        {
            tempList.Add("expiration=@Expiration");
        }

        if (data.uid != 0)
        {
            tempList.Add("uid=@Uid");
        }

        if (data.sessionVal != null)
        {
            tempList.Add("sessionVal=@SessionVal");
        }

        return tempList.ToArray();
    }

    public SessionsMap populateMap(DataRow row)
    {
        SessionsMap temp = new SessionsMap();
        
        temp.id = row.Field<int>("Id");
        temp.expiration = row.Field<DateTime>("Expiration");
        temp.uid = row.Field<int>("Uid");
        temp.sessionVal = row.Field<string>("SessionVal");

        return temp;
    }

    public SqlCommand sqlParamPopulate(SessionsMap map, SqlCommand command)
    {
        
        if (map.id != 0)
        {
            command.Parameters.Add(new SqlParameter("id", map.id));
        }

        if (map.expiration.Millisecond > 1)
        {
            command.Parameters.Add(new SqlParameter("expiration", map.expiration));
        }

        if (map.uid != 0)
        {
            command.Parameters.Add(new SqlParameter("uid", map.uid));
        }

        if (map.sessionVal != null)
        {
            command.Parameters.Add(new SqlParameter("sessionVal", map.sessionVal));
        }


        return command;
    }

    public void executeData(SessionsMap data, sqlStatementType sql)
    {
        if (sql == sqlStatementType.Insert)
        {
            sqlFunc.insertData(data, databaseTable.Sessions);
        }
        else if (sql == sqlStatementType.Update)
        {
            sqlFunc.updateData(data, databaseTable.Sessions);
        }
        else if (sql == sqlStatementType.Delete)
        {
            sqlFunc.deleteData(data, databaseTable.Sessions, paramList(data));
        }
    }

    public SessionsMap selectData(SessionsMap data)
    {
        data = sqlFunc.selectBuilder(databaseTable.Sessions, data, paramList(data));
        return data;
    }
}

