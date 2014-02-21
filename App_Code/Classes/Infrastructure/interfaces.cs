using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using data.construct;

public interface ISqlFunction<T>
{
    T populateMap(DataRow row);
    SqlCommand sqlParamPopulate(T map, SqlCommand command);
}

public interface IPrimaryAccount
{
    int id { get; set; }
    string email { get; set; }
    string username { get; set; }
    string password { get; set; }
    string salt { get; set; }
    membership memberLevel { get; set; }
    administrativeTrust adminTrust { get; set; }
    decimal accountBalance { get; set; }
    string coinBankVal1 { get; set; }
    string coinBankVal2 { get; set; }
}

public interface ISessions
{
    int id { get; set; }
    DateTime expiration { get; set; }
    int uid { get; set; }
    string sessionVal { get; set; }
}

public interface ICoinBank
{
    int id { get; set; }
    coinType CT { get; set; }
    string coinBankVal { get; set; }
    string totalCoinString { get; set; }
}
public interface ITotalCoins
{
    int id { get; set; }
    string totalCoinString { get; set; }
    decimal amount { get; set; }
}

public interface ICoinOrder
{
    int id { get; set; }
    orderType OT { get; set; }
    coinType CT { get; set; }
    string coinBankVal { get; set; }
    decimal perCoin { get; set; }
    decimal coinsToBeTraded { get; set; }
}

public interface ILogs
{
    int id { get; set; }
    logType LT { get; set; }
    DateTime timeOfEvent { get; set; }
    int uid1 { get; set; }
    int uid2 { get; set; }
    string logData { get; set; }
}