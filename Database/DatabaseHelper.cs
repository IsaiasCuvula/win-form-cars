using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace Cars.Database
{
    public class DatabaseHelper
    {
        private static string dbPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "cars.db");

        public static string ConnectionString =>
            $"Data Source={dbPath}";

        public static void InitializeDatabase()
        {
            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Cars (
                        CodeTaxi    INTEGER PRIMARY KEY AUTOINCREMENT,
                        RegNumber   TEXT NOT NULL UNIQUE,
                        CarBrand    TEXT NOT NULL,
                        Seats       INTEGER NOT NULL CHECK(Seats >= 3 AND Seats <= 10),
                        Luggage     INTEGER NOT NULL DEFAULT 0,
                        DriverName  TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Orders (
                        OrderNumber INTEGER PRIMARY KEY AUTOINCREMENT,
                        CodeTaxi    INTEGER NOT NULL,
                        Address     TEXT NOT NULL,
                        OrderTime   TEXT NOT NULL DEFAULT (datetime('now','localtime')),
                        Distance    REAL NOT NULL CHECK(Distance > 0),
                        Fare        REAL NOT NULL CHECK(Fare > 0),
                        FOREIGN KEY (CodeTaxi) REFERENCES Cars(CodeTaxi)
                    );
                ";
                new SqliteCommand(sql, conn).ExecuteNonQuery();
            }
        }
    }
}