using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using PersonsTest;

const string connectionString = @"Data Source=C:\Programming\test_db\persons.db";
var connection = new SqliteConnection(connectionString);
connection.Open();

const string sql = "SELECT * FROM table_persons";
var command = new SqliteCommand(sql, connection);
var reader = command.ExecuteReader();

var persons = new List<Person>();
if (reader.HasRows)
{
    while (reader.Read())
    {
        var id = reader.GetInt32("id");
        var lastName = reader.GetString("last_name");
        var firstName = reader.GetString("first_name");
        var person = new Person()
        {
            Id = id,
            LastName = lastName,
            FirstName = firstName
        };
        persons.Add(person);
    }
    
    reader.Close();
    connection.Close();
}
else
{
    Console.WriteLine("Нет данных в БД");
    
    reader.Close();
    connection.Close();
    
    return 1;
}

foreach (var person in persons)
{
    Console.WriteLine(person);
}

return 0;