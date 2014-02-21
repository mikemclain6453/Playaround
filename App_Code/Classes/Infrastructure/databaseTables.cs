using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum databaseTable
{
    PrimaryAccount,
    Sessions,
    CoinBank,
    TotalCoins,
    CoinOrder,
    Logs,
    }

namespace data.construct
{
    public class tableFormats
    {
        

        public int tableCount = 6;

        public string[][][] allTables()
        {
            string[][][] dbInfo = new string[tableCount][][];
            dbInfo[0] = PrimaryAccount();
            dbInfo[1] = Sessions();
            dbInfo[2] = CoinBank();
            dbInfo[3] = TotalCoins();
            dbInfo[4] = CoinOrder();
            dbInfo[5] = Logs();
            return dbInfo;
        }
        #region Tables
        
        public string[][] PrimaryAccount()
        {
            string[][] value = new string[][]
            {
                // Table Name
                new string[]
                {
                    "PrimaryAccount"
                },
                // Table Keys
                new string[]
                {
                    "id",
                    "email",
                    "username",
                    "password",
                    "salt",
                    "memberLevel",
                    "adminTrust",
                    "accountBalance",
                    "coinBankVal1",
                    "coinBankVal2"
                },
                // Table Key Features
                new string[]
                {
                    "int PRIMARY KEY IDENTITY",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)"
                }
            };
            return value;
        }

        public string[][] Sessions()
        {
            string[][] value = new string[][]
            {
                // Table Name
                new string[]
                {
                    "Sessions"
                },
                // Table Keys
                new string[]
                {
                    "id",
                    "expiration",
                    "uid",
                    "sessionVal"
                },
                // Table Key Features
                new string[]
                {
                    "int PRIMARY KEY IDENTITY",
                    "DateTime",
                    "int",
                    "varchar(255)"
                }
            };
            return value;
        }

        public string[][] CoinBank()
        {
            string[][] value = new string[][]
            {
                // Table Name
                new string[]
                {
                    "CoinBank"
                },
                // Table Keys
                new string[]
                {
                    "id",
                    "CT",
                    "coinBankVal",
                    "totalCoinString"
                },
                // Table Key Features
                new string[]
                {
                    "int PRIMARY KEY IDENTITY",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)"
                }
            };
            return value;
        }

        public string[][] TotalCoins()
        {
            string[][] value = new string[][]
            {
                // Table Name
                new string[]
                {
                    "TotalCoins"
                },
                // Table Keys
                new string[]
                {
                    "id",
                    "totalCoinString",
                    "amount"
                },
                // Table Key Features
                new string[]
                {
                    "int PRIMARY KEY IDENTITY",
                    "varchar(255)",
                    "decimal(6,3)"
                }
            };
            return value;
        }

        public string[][] CoinOrder()
        {
            string[][] value = new string[][]
            {
                // Table Name
                new string[]
                {
                    "CoinOrder"
                },
                // Table Keys
                new string[]
                {
                    "id",
                    "OT",
                    "CT",
                    "coinBankVal",
                    "perCoin",
                    "coinsToBeTraded"
                },
                // Table Key Features
                new string[]
                {
                    "int PRIMARY KEY IDENTITY",
                    "varchar(255)",
                    "varchar(255)",
                    "varchar(255)",
                    "decimal(6,3)",
                    "decimal(6,3)"
                }
            };
            return value;
        }

        public string[][] Logs()
        {
            string[][] value = new string[][]
            {
                // Table Name
                new string[]
                {
                    "Logs"
                },
                // Table Keys
                new string[]
                {
                    "id",
                    "LT",
                    "timeOfEvent",
                    "uid1",
                    "uid2",
                    "logData"
                },
                // Table Key Features
                new string[]
                {
                    "int PRIMARY KEY IDENTITY",
                    "varchar(255)",
                    "DateTime",
                    "int",
                    "int",
                    "varchar(255)"
                }
            };
            return value;
        }

        #endregion Tables
    }
}