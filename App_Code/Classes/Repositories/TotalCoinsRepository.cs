using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class TotalCoinsRepository : ISqlFunction<TotalCoinsMap>
{
    private sqlFunction<TotalCoinsMap> sqlFunc = new sqlFunction<TotalCoinsMap>();

    private string[] paramList(TotalCoinsMap data)
    {
        List<string> tempList = new List<string>();
        tempList.Add("*");
        
        if (data.id != 0)
        {
            tempList.Add("id=@Id");
        }

        if (data.totalCoinString != null)
        {
            tempList.Add("totalCoinString=@TotalCoinString");
        }

        if (data.amount != 0)
        {
            tempList.Add("amount=@Amount");
        }

        return tempList.ToArray();
    }

    public TotalCoinsMap populateMap(DataRow row)
    {
        TotalCoinsMap temp = new TotalCoinsMap();
        
        temp.id = row.Field<int>("Id");
        temp.totalCoinString = row.Field<string>("TotalCoinString");
        temp.amount = row.Field<decimal>("Amount");

        return temp;
    }

    public SqlCommand sqlParamPopulate(TotalCoinsMap map, SqlCommand command)
    {
        
        if (map.id != 0)
        {
            command.Parameters.Add(new SqlParameter("id", map.id));
        }

        if (map.totalCoinString != null)
        {
            command.Parameters.Add(new SqlParameter("totalCoinString", map.totalCoinString));
        }

        if (map.amount != null)
        {
            command.Parameters.Add(new SqlParameter("amount", map.amount));
        }


        return command;
    }

    public void executeData(TotalCoinsMap data, sqlStatementType sql)
    {
        if (sql == sqlStatementType.Insert)
        {
            sqlFunc.insertData(data, databaseTable.TotalCoins);
        }
        else if (sql == sqlStatementType.Update)
        {
            sqlFunc.updateData(data, databaseTable.TotalCoins);
        }
        else if (sql == sqlStatementType.Delete)
        {
            sqlFunc.deleteData(data, databaseTable.TotalCoins, paramList(data));
        }
    }

    public TotalCoinsMap selectData(TotalCoinsMap data)
    {
        data = sqlFunc.selectBuilder(databaseTable.TotalCoins, data, paramList(data));
        return data;
    }
}

