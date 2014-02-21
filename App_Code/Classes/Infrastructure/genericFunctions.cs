using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Cryptography;
using System.Dynamic;
using System.Data;
using System.Data.SqlClient;
using data.construct;

public class genericFunctions<T>
{
    private T conversion(dynamic value)
    {
        try
        {
            return (T)System.Convert.ChangeType(value, Type.GetTypeCode(typeof(T)));
        }
        catch
        {
            return value;
        }
    }

    internal dynamic processTableFunction(databaseTable dbt, tableFunction tfunc, params dynamic[] args)
    {
        CompiledRepositories CR = new CompiledRepositories();
        dynamic repo = CR.repositoryGrab(dbt);
        tableFormats tf = new tableFormats();

        if (tfunc == tableFunction.paramArray || tfunc == tableFunction.processRow)
        {
            switch (tfunc)
            {
                case tableFunction.processRow:
                    return conversion(repo.populateMap(args[0]));

                case tableFunction.paramArray:
                    return repo.ParamArray;

                default:
                    return conversion(null);
            }
        }
        else
        {
            switch (dbt)
            {
                case databaseTable.PrimaryAccount:
                    switch (tfunc)
                    {
                        case tableFunction.sqlParamPopulate:
                            return repo.sqlParamPopulate((PrimaryAccountMap)(object)args[0], args[1]);

                        case tableFunction.tableFormatChoose:
                            return conversion(tf.PrimaryAccount());

                        default:
                            return conversion(null);
                    }
                case databaseTable.Sessions:
                    switch (tfunc)
                    {
                        case tableFunction.sqlParamPopulate:
                            return repo.sqlParamPopulate((SessionsMap)(object)args[0], args[1]);

                        case tableFunction.tableFormatChoose:
                            return conversion(tf.Sessions());

                        default:
                            return conversion(null);
                    }
                case databaseTable.CoinBank:
                    switch (tfunc)
                    {
                        case tableFunction.sqlParamPopulate:
                            return repo.sqlParamPopulate((CoinBankMap)(object)args[0], args[1]);

                        case tableFunction.tableFormatChoose:
                            return conversion(tf.CoinBank());

                        default:
                            return conversion(null);
                    }
                case databaseTable.TotalCoins:
                    switch (tfunc)
                    {
                        case tableFunction.sqlParamPopulate:
                            return repo.sqlParamPopulate((TotalCoinsMap)(object)args[0], args[1]);

                        case tableFunction.tableFormatChoose:
                            return conversion(tf.TotalCoins());

                        default:
                            return conversion(null);
                    }
                case databaseTable.CoinOrder:
                    switch (tfunc)
                    {
                        case tableFunction.sqlParamPopulate:
                            return repo.sqlParamPopulate((CoinOrderMap)(object)args[0], args[1]);

                        case tableFunction.tableFormatChoose:
                            return conversion(tf.CoinOrder());

                        default:
                            return conversion(null);
                    }
                case databaseTable.Logs:
                    switch (tfunc)
                    {
                        case tableFunction.sqlParamPopulate:
                            return repo.sqlParamPopulate((LogsMap)(object)args[0], args[1]);

                        case tableFunction.tableFormatChoose:
                            return conversion(tf.Logs());

                        default:
                            return conversion(null);
                    }
                
                default:
                    return conversion(null);
            }
        }
    }
}

public class functionality
{
    public string baseURL = "C:/HostingSpaces/Skynet/architect.mathisonenterprises.com/wwwroot/";

    #region Random Sets

    public string randomCharacterSet(int maxlength)
    {
        string permittedCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890";
        string set = "";
        while (set.Length < maxlength)
        {
            set += permittedCharacters[randnum(0, permittedCharacters.Length)];
        }
        return set;
    }

    public string randomnumberset(int maxlength)
    {
        string set = "";
        while (set.Length < maxlength)
        {
            set += randnum(0, 10).ToString();
        }
        return set;
    }

    public int randnum(int min, int max)
    {
        RNGCryptoServiceProvider c = new RNGCryptoServiceProvider();

        int val = 0;

        for (int x = 0; x < 20; x++)
        {
            byte[] randomNumber = new byte[4];
            c.GetBytes(randomNumber);
            int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));
            val = result % max + min;
        }

        return val;
    }

    #endregion

    #region Security

    public string hashedValue(string input)
    {
        // step 1, calculate MD5 hash from input
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        string sb = "";
        for (int i = 0; i < hash.Length; i++)
        {
            sb += hash[i].ToString("X2");
        }
        return sb;
    }

    public HttpCookie createcookie(string value, string cookiename)
    {
        HttpCookie cookievalue = new HttpCookie(cookiename);
        DateTime now = DateTime.Now;
        cookievalue.Value = value;
        cookievalue.Expires = now.AddHours(4);
        cookievalue.Domain = "";
        return cookievalue;
    }

    public dynamic cookieStatus(HttpCookie cookie)
    {
        RepoMapConnect RMC = new RepoMapConnect(databaseTable.Sessions);
        if (cookie != null)
        {
            RMC.map.sessionVal = cookie.Value;
            RMC.map = RMC.repo.selectData(RMC.map);

            if (RMC.map.expiration > DateTime.Now)
            {
                RepoMapConnect RMCaccount = new RepoMapConnect(databaseTable.PrimaryAccount);
                RMCaccount.map.id = RMC.map.uid;
                RMCaccount.map = RMCaccount.repo.selectData(RMCaccount.map);
                return RMCaccount;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region Upper <==> Lower
    public string FirstCharToUpper(string input)
    {
        if (String.IsNullOrEmpty(input))
            throw new ArgumentException("ARGH!");
        return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
    }

    public string FirstCharToLower(string input)
    {
        if (String.IsNullOrEmpty(input))
            throw new ArgumentException("ARGH!");
        return input.First().ToString().ToLower() + String.Join("", input.Skip(1));
    }
    #endregion

    #region Member Level
    public membership memberStringToEnum(string value)
    {
        switch (value)
        {
            case "Unverified":
                return membership.Unverified;

            case "Verified":
                return membership.Verified;

            case "Bronze":
                return membership.Bronze;

            case "Silver":
                return membership.Silver;

            case "Gold":
                return membership.Gold;

            case "Platinum":
                return membership.Platinum;

            default:
                return membership.NULL;
        }
    }

    public string memberEnumToString(membership value)
    {
        switch (value)
        {
            case membership.Unverified:
                return "Unverified";

            case membership.Verified:
                return "Verified";

            case membership.Bronze:
                return "Bronze";

            case membership.Silver:
                return "Silver";

            case membership.Gold:
                return "Gold";

            case membership.Platinum:
                return "Platinum";

            default:
                return "NULL";
        }
    }
    #endregion

    #region Admin Trust
    public administrativeTrust adminTrustStringToEnum(string value)
    {
        switch (value)
        {
            case "Banned":
                return administrativeTrust.Banned;

            case "Unknown":
                return administrativeTrust.Unknown;

            case "Low":
                return administrativeTrust.Low;

            case "Medium":
                return administrativeTrust.Medium;

            case "High":
                return administrativeTrust.High;

            default:
                return administrativeTrust.NULL;
        }
    }

    public string adminTrustEnumToString(administrativeTrust value)
    {
        switch (value)
        {
            case administrativeTrust.Banned:
                return "Banned";

            case administrativeTrust.Unknown:
                return "Unknown";

            case administrativeTrust.Low:
                return "Low";

            case administrativeTrust.Medium:
                return "Medium";

            case administrativeTrust.High:
                return "High";

            default:
                return "NULL";
        }
    }


    #endregion

    #region Coin Type

    public coinType coinTypeStringToEnum(string value)
    {
        switch (value)
        {
            case "Bitcoin":
                return coinType.Bitcoin;

            case "Litecoin":
                return coinType.Litecoin;

            default:
                return coinType.NULL;
        }
    }

    public string coinTypeEnumToString(coinType value)
    {
        switch (value)
        {
            case coinType.Bitcoin:
                return "Bitcoin";

            case coinType.Litecoin:
                return "Litecoin";

            default:
                return null;
        }
    }
    #endregion

    #region Order Type

    public orderType orderTypeStringToEnum(string value)
    {
        switch (value)
        {
            case "Buy":
                return orderType.Buy;

            case "Sell":
                return orderType.Sell;

            default:
                return orderType.NULL;
        }

    }

    public string orderTypeEnumToString(orderType value)
    {

        switch (value)
        {
            case orderType.Buy:
                return "Buy";

            case orderType.Sell:
                return "Sell";

            default:
                return null;
        }
    }

    #endregion

    public string bbcProcess(string value)
    {
        value = value.Replace("[", "<").Replace("]", ">");

        return value;
    }

    public void sendemail(string senderaddress, string receiver, string subject, string message)
    {
        MailMessage MyMailMessage = new MailMessage(senderaddress, receiver, subject, message);
        MyMailMessage.IsBodyHtml = true;
        NetworkCredential mailAuthentication = new NetworkCredential("jakethewizard04@gmail.com", "@sd34964");
        SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
        mailClient.EnableSsl = true;
        mailClient.UseDefaultCredentials = false;
        mailClient.Credentials = mailAuthentication;
        mailClient.Send(MyMailMessage);
    }

    public decimal getValueByBankValue(string bankVal)
    {
        if (bankVal != "")
        {
            RepoMapConnect RMC = new RepoMapConnect(databaseTable.CoinBank);
            RMC.map.coinBankVal = bankVal;
            RMC.map = RMC.repo.selectData(RMC.map);
            return getValueByCoinString(RMC.map.totalCoinString);
        }
        else
        {
            return 0.000m;
        }
    }

    public decimal getValueByCoinString(string coinString)
    {
        if (coinString != "")
        {
            RepoMapConnect RMC = new RepoMapConnect(databaseTable.TotalCoins);
            RMC.map.totalCoinString = coinString;
            RMC.map = RMC.repo.selectData(RMC.map);
            return RMC.map.amount;
        }
        else
        {
            return 0.000m;
        }
    }
}

public class trading
{
    private functionality func = new functionality();
    public CoinOrderMap cheapestCoin(orderType order)
    {
        RepoMapConnect RMC = new RepoMapConnect(databaseTable.CoinOrder);
        RMC.map.OT = order;

        SqlCommand command = new SqlCommand(string.Format("select * from coinOrder WHERE OT = {0} ORDER BY perCoin ASC LIMIT 1;", func.orderTypeEnumToString(RMC.map.OT)));
        RMC.map = RMC.repo.sqlFunc.selectData(command, databaseTable.CoinOrder);

        return RMC.map;
    }
}