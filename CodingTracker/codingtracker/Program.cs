// See https://aka.ms/new-console-template for more information

using System;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace codingtracker
{
    class Program
    {

        //specify the database
        static string connectionString = @"Data Source=codingtracker.db";

        static void Main(string[] args)
        {
            //connect to the database using connection string
            using (var connection = new SqliteConnection(connectionString))
            {
                //open the connection
                connection.Open();
                //tell connection to create a command
                var tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS codingtracker (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                )";
                //executes the command without returning any values
                tableCmd.ExecuteNonQuery();
                //close connection
                connection.Close();

            }
            GetUserInput();

        }



static void GetUserInput()
{
    Console.Clear();
    bool closeApp = false;
    while (closeApp == false)
    {
        Console.WriteLine("\n\nMAIN MENU");
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("\nType 0 to Close Application");
        Console.WriteLine("Type 1 to READ");
        Console.WriteLine("Type 2 to CREATE");
        Console.WriteLine("Type 3 to DELETE");
        Console.WriteLine("Type 4 to UPDATE");
        Console.WriteLine("==================================================\n");

        string command = Console.ReadLine();

        switch (command)
        {
            case "0":
                Console.WriteLine("\nGoodBye!\n");
                closeApp = true;
                break;
            case "1":
                ReadRecord();
                break;
            case "2":
                CreateRecord();
                break;
            case "3":
                DeleteRecord();
                break;
            case "4":
                UpdateRecord();
                break;
            default:
                Console.WriteLine("\nInavlid Command. Please enter a number between 0 and 4.\n");
                break;
        }
    }
}


static void UpdateRecord()
{
    Console.Clear();
    var recordId = GetNumberInput("Enter record id to update");

    using (var connection = new SqliteConnection(connectionString))
    {
        //open the connection
        connection.Open();

        //check if the id exists in the table
        var checkCmd = connection.CreateCommand();
        checkCmd.CommandText = $"SELECT EXISTS(SELECT 1 FROM codingtracker WHERE Id = {recordId})";
        int checkQuery = Convert.ToInt32(checkCmd.ExecuteScalar());

        if (checkQuery == 0)
        {
            Console.WriteLine($"\n\nRecord with Id {recordId} doesn't exist. \n\n");
            connection.Close();
            UpdateRecord();
        }

        var recordDate = GetDateInput();

        var recordQty = GetNumberInput("Enter record quantity to update");

        //tell connection to create a command
        var tableCmd = connection.CreateCommand();

        tableCmd.CommandText = $"UPDATE codingtracker SET Date = '{recordDate}', Quantity='{recordQty}' WHERE Id = '{recordId}'";

        tableCmd.ExecuteNonQuery();

        Console.WriteLine($"\n\nRecord with Id {recordId} was successfully updated. \n\n");

        //close connection
        connection.Close();
    }

}


static void DeleteRecord()
{
    Console.Clear();
    var recordId = GetNumberInput("Enter record id to delete");

    using (var connection = new SqliteConnection(connectionString))
    {
        //open the connection
        connection.Open();
        //tell connection to create a command
        var tableCmd = connection.CreateCommand();

        tableCmd.CommandText = $"DELETE FROM codingtracker WHERE Id = '{recordId}'";

        //executes the command without returning any values
        int rowCount = tableCmd.ExecuteNonQuery();

        if (rowCount == 0)
        {
            Console.WriteLine($"\n\nRecord with Id {recordId} doesn't exist. \n\n");
            DeleteRecord();
        }

        Console.WriteLine($"\n\nRecord with Id {recordId} was deleted. \n\n");

        //close connection
        connection.Close();
    }




}


static void ReadRecord()
{
    Console.Clear();
    using (var connection = new SqliteConnection(connectionString))
    {
        //open the connection
        connection.Open();

        //tell connection to create a command
        var tableCmd = connection.CreateCommand();

        tableCmd.CommandText = $"SELECT * FROM codingtracker";
        //executes the command without returning any values

        List<CodingTracker> tableData = new List<CodingTracker>();

        SqliteDataReader reader = tableCmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                tableData.Add(new CodingTracker
                {
                    Id = reader.GetInt32(0),
                    Date = DateTime.ParseExact(reader.GetString(1), "dd-MM-yy", new CultureInfo("en-US")),
                    Quantity = reader.GetInt32(2)
                });
            }

        }
        else
        {
            Console.WriteLine("No rows found!");
        }

        //close connection
        connection.Close();
        Console.WriteLine("------------------------------------------\n");

        foreach (var item in tableData)
        {
            Console.WriteLine($"{item.Id} - {item.Date.ToString("dd-MMM-yyyy")} - Quantity: {item.Quantity}");
        }

        Console.WriteLine("------------------------------------------\n");
    }

}

static void CreateRecord()
{
    string date = GetDateInput();
    int quantity = GetNumberInput("Enter the quantity of code. no floats!");

    using (var connection = new SqliteConnection(connectionString))
    {
        //open the connection
        connection.Open();
        //tell connection to create a command
        var tableCmd = connection.CreateCommand();

        tableCmd.CommandText =
        $"INSERT INTO codingtracker ( date, quantity) VALUES ('{date}', {quantity})";
        //executes the command without returning any values
        tableCmd.ExecuteNonQuery();
        //close connection
        connection.Close();
    }
}

    internal static string GetDateInput()
    {
        Console.WriteLine("Enter date format dd-mm-yy");
        string dateInput = Console.ReadLine();
        if (dateInput == "0") GetUserInput();
        return dateInput;
    }

    internal static int GetNumberInput(string message)
    {
        Console.WriteLine(message);
        string numInput = Console.ReadLine();
        if (numInput == "0") GetUserInput();
        int finalInput = Convert.ToInt32(numInput);
        return finalInput;
    }

    }

    public class CodingTracker
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }

    }

}




