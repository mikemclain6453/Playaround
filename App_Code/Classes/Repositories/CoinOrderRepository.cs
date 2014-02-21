using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class CoinOrderRepository : ISqlFunction<CoinOrderMap>
{
    public sqlFunction<CoinOrderMap> sqlFunc = new sqlFunction<CoinOrderMap>();

    private string[] paramList(CoinOrderMap data)
    {
        List<string> tempList = new List<string>();
        tempList.Add("*");
        
        if (data.id != 0)
        {
            tempList.Add("id=@Id");
        }

        if (data.OT != orderType.NULL)
        {
            tempList.Add("OT=@OT");
        }

        if (data.CT != coinType.NULL)
        {
            tempList.Add("CT=@CT");
        }

        if (data.coinBankVal != null)
        {
            tempList.Add("coinBankVal=@CoinBankVal");
        }

        if (data.perCoin != null)
        {
            tempList.Add("perCoin=@PerCoin");
        }

        if (data.coinsToBeTraded != null)
        {
            tempList.Add("coinsToBeTraded=@CoinsToBeTraded");
        }

        return tempList.ToArray();
    }

    public CoinOrderMap populateMap(DataRow row)
    {
        CoinOrderMap temp = new CoinOrderMap();
        
        temp.id = row.Field<int>("Id");
        temp.OT = sqlFunc.func.orderTypeStringToEnum(row.Field<string>("OT"));
        temp.CT = sqlFunc.func.coinTypeStringToEnum(row.Field<string>("CT"));
        temp.coinBankVal = row.Field<string>("CoinBankVal");
        temp.perCoin = row.Field<decimal>("PerCoin");
        temp.coinsToBeTraded = row.Field<decimal>("CoinsToBeTraded");

        return temp;
    }

    public SqlCommand sqlParamPopulate(CoinOrderMap map, SqlCommand command)
    {
        
        if (map.id != 0)
        {
            command.Parameters.Add(new SqlParameter("id", map.id));
        }

        if (map.OT != orderType.NULL)
        {
            command.Parameters.Add(new SqlParameter("OT", sqlFunc.func.orderTypeEnumToString(map.OT)));
        }

        if (map.CT != coinType.NULL)
        {
            command.Parameters.Add(new SqlParameter("CT", sqlFunc.func.coinTypeEnumToString(map.CT)));
        }

        if (map.coinBankVal != null)
        {
            command.Parameters.Add(new SqlParameter("coinBankVal", map.coinBankVal));
        }

        if (map.perCoin != null)
        {
            command.Parameters.Add(new SqlParameter("perCoin", map.perCoin));
        }

        if (map.coinsToBeTraded != null)
        {
            command.Parameters.Add(new SqlParameter("coinsToBeTraded", map.coinsToBeTraded));
        }


        return command;
    }

    public void executeData(CoinOrderMap data, sqlStatementType sql)
    {
        if (sql == sqlStatementType.Insert)
        {
            sqlFunc.insertData(data, databaseTable.CoinOrder);
        }
        else if (sql == sqlStatementType.Update)
        {
            sqlFunc.updateData(data, databaseTable.CoinOrder);
        }
        else if (sql == sqlStatementType.Delete)
        {
            sqlFunc.deleteData(data, databaseTable.CoinOrder, paramList(data));
        }
    }

    public CoinOrderMap selectData(CoinOrderMap data)
    {
        data = sqlFunc.selectBuilder(databaseTable.CoinOrder, data, paramList(data));
        return data;
    }
}

