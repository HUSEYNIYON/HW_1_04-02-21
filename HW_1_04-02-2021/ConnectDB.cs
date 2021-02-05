using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HW_1_04_02_2021
{
    class ConnectDB
    {
        SqlConnection connect = new SqlConnection(@"Data source=DESKTOP-G6SLUNJ; Initial catalog=AlifAcademy; Integrated security=true");
        public void OpenConnection()
        {
            if (connect.State == ConnectionState.Closed) connect.Open();
        }
        public void CloseConnection() => connect.Close();

        public void Insert(string LastName, string FirstName, string MiddleName, string BirthDate)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand("INSERT INTO Person([LastName],[FirstName],[MiddleName],[BirthDate]) Values ('" + LastName + "','" + FirstName + "','" + MiddleName + "','" + Convert.ToDateTime(BirthDate) + "')", connect))
            {
                int a = command.ExecuteNonQuery();
                if (a > 0)
                {
                    MakeGreen();
                    Console.WriteLine("Данные успешно добавлен в базу данных!");
                    MakeWhite();
                }
            }
            CloseConnection();
        }
        public void SelectAll()
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand("Select * from Person", connect))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       Console.WriteLine($"Id: {reader.GetValue(0)}\t LastName: {reader.GetValue(1)}\t FirstName: {reader.GetValue(2)}\t MiddleName: {reader.GetValue(3)}\t\t BirthDate: {reader.GetValue(4).ToString().Substring(0, 10)}");
                    }
                }
            }
            CloseConnection();
        }
        public void SelectById(int Id)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Person WHERE Id =" + Id, connect))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int c = 0;
                    while (reader.Read())
                    {
                        System.Console.WriteLine($"Id: {reader.GetValue(0)}\t LastName: {reader.GetValue(1)}\t FirstName: {reader.GetValue(2)}\t MiddleName: {reader.GetValue(3)}\t\t BirthDate: {reader.GetValue(4).ToString().Substring(0, 10)}");
                        c += (reader.GetValue(0).ToString() == Id.ToString()) ? 1 : 0;
                    }
                    if (c == 0)
                    {
                        MakeRed();
                        System.Console.WriteLine("Такого Id не существует в базе данных!");
                        MakeWhite();
                    }
                }
            }
            CloseConnection();
        }
        public void UpdateById(int Id, string LastName, string FirstName, string MiddleName, string BirthDate)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand("UPDATE Person SET LastName = '" + LastName + "',FirstName ='" + FirstName + "',MiddleName ='" + MiddleName + "','" + Convert.ToDateTime(BirthDate) + "') where Id =" + Id, connect))
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    MakeGreen();
                    Console.WriteLine("Updated Person with " + Id + " Id!");
                    MakeWhite();
                }
                else
                {
                    MakeRed();
                    Console.WriteLine("Такого Id не существует в базе данных!");
                    MakeWhite();
                }
            }
            CloseConnection();
        }
        public void Delete(int Id)
        {
            OpenConnection();
            using (SqlCommand command = new SqlCommand("DELETE Person WHERE Id ='" + Id + "'", connect))
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    MakeGreen();
                    Console.WriteLine("Успешно удалено!");
                    MakeWhite();
                }
                else
                {
                    MakeRed();
                    Console.WriteLine("Такого Id не существует в базе данных!");
                    MakeWhite();
                }
            }
            CloseConnection();
        }
        public void MakeGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void MakeWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void MakeRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}

