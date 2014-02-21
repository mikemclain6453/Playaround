using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class PrimaryAccountRepository : ISqlFunction<PrimaryAccountMap>
{
    private sqlFunction<PrimaryAccountMap> sqlFunc = new sqlFunction<PrimaryAccountMap>();

    public string[] paramList(PrimaryAccountMap data)
    {
        List<string> tempList = new List<string>();
        tempList.Add("*");
        
        if (data.id != 0)
        {
            tempList.Add("id=@Id");
        }

        if (data.email != null)
        {
            tempList.Add("email=@Email");
        }

        if (data.username != null)
        {
            tempList.Add("username=@Username");
        }

        if (data.password != null)
        {
            tempList.Add("password=@Password");
        }

        if (data.salt != null)
        {
            tempList.Add("salt=@Salt");
        }

        if (data.memberLevel != membership.NULL)
        {
            tempList.Add("memberLevel=@MemberLevel");
        }

        if (data.adminTrust != administrativeTrust.NULL)
        {
            tempList.Add("adminTrust=@AdminTrust");
        }

        if (data.accountBalance != null)
        {
            tempList.Add("accountBalance=@AccountBalance");
        }

        if (data.coinBankVal1 != null)
        {
            tempList.Add("coinBankVal1=@CoinBankVal1");
        }

        if (data.coinBankVal2 != null)
        {
            tempList.Add("coinBankVal2=@CoinBankVal2");
        }

        return tempList.ToArray();
    }

    public PrimaryAccountMap populateMap(DataRow row)
    {
        PrimaryAccountMap temp = new PrimaryAccountMap();
        
        temp.id = row.Field<int>("Id");
        temp.email = row.Field<string>("Email");
        temp.username = row.Field<string>("Username");
        temp.password = row.Field<string>("Password");
        temp.salt = row.Field<string>("Salt");
        temp.memberLevel = sqlFunc.func.memberStringToEnum(row.Field<string>("MemberLevel"));
        temp.adminTrust = sqlFunc.func.adminTrustStringToEnum(row.Field<string>("AdminTrust"));
        temp.accountBalance = decimal.Parse(row.Field<string>("AccountBalance"));
        temp.coinBankVal1 = row.Field<string>("CoinBankVal1");
        temp.coinBankVal2 = row.Field<string>("CoinBankVal2");

        return temp;
    }

    public SqlCommand sqlParamPopulate(PrimaryAccountMap map, SqlCommand command)
    {
        
        if (map.id != 0)
        {
            command.Parameters.Add(new SqlParameter("id", map.id));
        }

        if (map.email != null)
        {
            command.Parameters.Add(new SqlParameter("email", map.email));
        }

        if (map.username != null)
        {
            command.Parameters.Add(new SqlParameter("username", map.username));
        }

        if (map.password != null)
        {
            command.Parameters.Add(new SqlParameter("password", map.password));
        }

        if (map.salt != null)
        {
            command.Parameters.Add(new SqlParameter("salt", map.salt));
        }

        if (map.memberLevel != membership.NULL)
        {
            command.Parameters.Add(new SqlParameter("memberLevel", sqlFunc.func.memberEnumToString(map.memberLevel)));
        }

        if (map.adminTrust != administrativeTrust.NULL)
        {
            command.Parameters.Add(new SqlParameter("adminTrust", sqlFunc.func.adminTrustEnumToString(map.adminTrust)));
        }

        if (map.accountBalance != null)
        {
            command.Parameters.Add(new SqlParameter("accountBalance", map.accountBalance));
        }

        if (map.coinBankVal1 != null)
        {
            command.Parameters.Add(new SqlParameter("coinBankVal1", map.coinBankVal1));
        }

        if (map.coinBankVal2 != null)
        {
            command.Parameters.Add(new SqlParameter("coinBankVal2", map.coinBankVal2));
        }


        return command;
    }

    public void executeData(PrimaryAccountMap data, sqlStatementType sql)
    {
        if (sql == sqlStatementType.Insert)
        {
            sqlFunc.insertData(data, databaseTable.PrimaryAccount);
        }
        else if (sql == sqlStatementType.Update)
        {
            sqlFunc.updateData(data, databaseTable.PrimaryAccount);
        }
        else if (sql == sqlStatementType.Delete)
        {
            sqlFunc.deleteData(data, databaseTable.PrimaryAccount, paramList(data));
        }
    }

    public PrimaryAccountMap selectData(PrimaryAccountMap data)
    {
        data = sqlFunc.selectBuilder(databaseTable.PrimaryAccount, data, paramList(data));
        return data;
    }
}

