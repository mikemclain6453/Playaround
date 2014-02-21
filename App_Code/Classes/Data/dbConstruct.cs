using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using data.database;
using data.construct;

namespace data.construct
{
    public class dbConstruct
    {
        public dbhandling db = new dbhandling();
        public tableFormats tf = new tableFormats();

        public void buildUpdateDB()
        {
            string[][][] dbInfo = tf.allTables();

            foreach (string[][] tableInfo in dbInfo)
            {
                bool tableExist = doesTableExist(tableInfo[0][0]);

                if (tableExist == false)
                {
                    string tableBuilder = string.Format("CREATE TABLE {0} (", tableInfo[0][0]);
                    for (int i = 0; tableInfo[1].Length > i; i++)
                    {
                        tableBuilder += buildColumnPart(tableInfo[1][i], tableInfo[2][i]);

                        if (tableInfo[1].Length > i + 1)
                        {
                            tableBuilder += ",";
                        }
                    }
                    tableBuilder += ");";
                    SqlCommand command = new SqlCommand(tableBuilder);
                    db.dbActionSet(command, databaseAction.Execute);
                }
                if (tableExist == true)
                {
                    for (int i = 0; tableInfo[1].Length > i; i++)
                    {
                        bool columnExist = doesColumnExist(tableInfo[0][0],tableInfo[1][i]);
                        
                        if (columnExist == false)
                        {
                            string columnBuild = buildColumnPart(tableInfo[1][i], tableInfo[2][i]);
                            string alterBuilder = string.Format("ALTER TABLE {0} ADD {1}", tableInfo[1][i],columnBuild);
                            SqlCommand command = new SqlCommand(alterBuilder);
                            db.dbActionSet(command, databaseAction.Execute);
                        }
                    }
                }

            }

        }

        public string buildColumnPart(string columnName, string columnDataType)
        {
            return columnName + " " + columnDataType;
        }

        public bool doesTableExist(string tableName)
        {
            try
            {
                SqlCommand command = new SqlCommand(string.Format("SELECT * FROM {0};",tableName));
                DataTable executed = db.dbActionSet(command, databaseAction.Read);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool doesColumnExist(string tableName,string columnName)
        {
            try
            {
                SqlCommand command = new SqlCommand(string.Format("SELECT {1} FROM {0};", tableName,columnName));
                DataTable executed = db.dbActionSet(command, databaseAction.Read);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void truncateDB()
        {
            string[][][] dbInfo = tf.allTables();
            foreach (string[][] tableInfo in dbInfo)
            {
                bool tableExist = doesTableExist(tableInfo[0][0]);

                if (tableExist)
                {
                    SqlCommand command = new SqlCommand(string.Format("TRUNCATE TABLE {0};", tableInfo[0][0]));
                    db.dbActionSet(command, databaseAction.Execute);
                }
            }
        }

        public void dropTableDB()
        {
            string[][][] dbInfo = tf.allTables();
            foreach (string[][] tableInfo in dbInfo)
            {
                bool tableExist = doesTableExist(tableInfo[0][0]);

                if (tableExist)
                {
                    SqlCommand command = new SqlCommand(string.Format("DROP TABLE {0};", tableInfo[0][0]));
                    db.dbActionSet(command, databaseAction.Execute);
                }
            }
        }
    }
}