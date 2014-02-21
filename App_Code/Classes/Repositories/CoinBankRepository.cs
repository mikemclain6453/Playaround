using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class CoinBankRepository : ISqlFunction<CoinBankMap>
{
    private sqlFunction<CoinBankMap> sqlFunc = new sqlFunction<CoinBankMap>();

    public string[] paramList(CoinBankMap data)
    {
        List<string> tempList = new List<string>();
        tempList.Add("*");
        
        if (data.id != 0)
        {
            tempList.Add("id=@Id");
        }

        if (data.CT != coinType.NULL)
        {
            tempList.Add("CT=@CT");
        }

        if (data.coinBankVal != null)
        {
            tempList.Add("coinBankVal=@CoinBankVal");
        }

        if (data.totalCoinString != null)
        {
            tempList.Add("totalCoinString=@TotalCoinString");
        }

        return tempList.ToArray();
    }

    public CoinBankMap populateMap(DataRow row)
    {
        CoinBankMap temp = new CoinBankMap();
        
        temp.id = row.Field<int>("Id");
        temp.CT = sqlFunc.func.coinTypeStringToEnum(row.Field<string>("CT"));
        temp.coinBankVal = row.Field<string>("CoinBankVal");
        temp.totalCoinString = row.Field<string>("TotalCoinString");

        return temp;
    }

    public SqlCommand sqlParamPopulate(CoinBankMap map, SqlCommand command)
    {
        
        if (map.id != 0)
        {
            command.Parameters.Add(new SqlParameter("id", map.id));
        }

        if (map.CT != coinType.NULL)
        {
            command.Parameters.Add(new SqlParameter("CT", sqlFunc.func.coinTypeEnumToString(map.CT)));
        }

        if (map.coinBankVal != null)
        {
            command.Parameters.Add(new SqlParameter("coinBankVal", map.coinBankVal));
        }

        if (map.totalCoinString != null)
        {
            command.Parameters.Add(new SqlParameter("totalCoinString", map.totalCoinString));
        }


        return command;
    }

    public void executeData(CoinBankMap data, sqlStatementType sql)
    {
        if (sql == sqlStatementType.Insert)
        {
            sqlFunc.insertData(data, databaseTable.CoinBank);
        }
        else if (sql == sqlStatementType.Update)
        {
            sqlFunc.updateData(data, databaseTable.CoinBank);
        }
        else if (sql == sqlStatementType.Delete)
        {
            sqlFunc.deleteData(data, databaseTable.CoinBank, paramList(data));
        }
    }

    public CoinBankMap selectData(CoinBankMap data)
    {
        data = sqlFunc.selectBuilder(databaseTable.CoinBank, data, paramList(data));
        return data;
    }
}

