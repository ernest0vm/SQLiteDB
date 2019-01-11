using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using SQLiteDB.Helpers;

namespace SQLiteDB.ViewModels
{
    public class MainViewModel : Observable
    {
        
        public void AddtoDataBase(String _data)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=sqlite.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand
                {
                    Connection = db,

                    //Use parameterized query to prevent SQL injection attacks
                    CommandText = "INSERT INTO Table1 VALUES (NULL, @Entry);"
                };
                insertCommand.Parameters.AddWithValue("@Entry", _data);

                try
                {
                    insertCommand.ExecuteReader();
                }
                catch (SqliteException)
                {
                    //Handle error
                    return;
                }
                db.Close();
            }
            

        }

        public List<String> Grab_Entries()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection("Filename=sqlite.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from Table1", db);
                SqliteDataReader query;
                try
                {
                    query = selectCommand.ExecuteReader();
                }
                catch (SqliteException)
                {
                    //Handle error
                    return entries;
                }
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }

    }
}
