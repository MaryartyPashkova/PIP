using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data.SqlClient;
using Задание_Crud_создание_клиента.Repositories;
using Задание_Crud_создание_клиента.Models;

namespace Задание_Crud_создание_клиента
{
    internal class Program
    {
        const string ConnectionString = "Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb";
        static void Main(string[] args)
        {
            using var connection = new NpgsqlConnection(ConnectionString);
            connection.Open();
            var manufacturerRepo = new ManufacturerRepository(ConnectionString);
            var modelerRepo = new ModelsRepository(ConnectionString);
            while (true)
            {
            Console.WriteLine("1. Список производителей");
            Console.WriteLine("2. Список всех моделей");
            Console.WriteLine("3. Выполнение вставку новой модели");
            //Console.WriteLine("4. Новый список всех моделей");
            Console.WriteLine("4. Удаление строки в таблице Модели");
            //Console.WriteLine("6. Новый список всех моделей");
            Console.WriteLine("5. Обновление даннх в таблице");
            var choise = Convert.ToInt32(Console.ReadLine());

            if (choise == 1)
                {
                    //var connection = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
                    ////var connection = new NpgsqlConnection("Host=ep-sweet-rain-62023004-pooler.us-east-2.aws.neon.tech;Username=andrewflorko;Password=8IxlXzMneB9N;Database=neondb");
                    //connection.Open();
                    //var command = connection.CreateCommand();
                    ////command.CommandText = "select * from Manufactures";
                    //command.CommandText = "select \"Name\" as manufacturer from \"Manufactures\" ";
                    //var reader = command.ExecuteReader();
                    //Console.WriteLine("1. Список производителей:");
                    //while (reader.Read())
                    //{
                    //    Console.WriteLine(reader["manufacturer"]);
                    //}
                    foreach(var item in manufacturerRepo.GetAll())
                    {
                        Console.WriteLine($"Name: {item.Name}, Manufacturer: {item.numb}");
                    }
                    Console.WriteLine();
                }

                if (choise == 2)
                {
                    //Console.WriteLine("2. Список всех моделей:");
                    //var connection1 = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
                    //connection1.Open();
                    //var command1 = connection1.CreateCommand();
                    //command1.CommandText = "select \"Name\" as modname from \"Models\" ";
                    //var reader1 = command1.ExecuteReader();
                    //while (reader1.Read())
                    //{
                    //    Console.WriteLine(reader1["modname"]);
                    //}
                    //Console.WriteLine();
                    foreach (var item in modelerRepo.GetAll())
                    {
                        Console.WriteLine($"ID = {item.choco_id}, Name: {item.MName}");
                    }
                    Console.WriteLine();
                }



                if (choise == 3) {
                    //Console.WriteLine("3. Выполнение вставку новой модели");
                    var nme = "";
                    var yar=0;
                    var mon=0;
                    Console.WriteLine("Введите новый вид шоколада:");
                    nme = Console.ReadLine(); 
                    Console.WriteLine("Введите год выпуска:");
                    yar = Convert.ToInt32(Console.ReadLine()); 
                    Console.WriteLine("Введите номер производителя:");
                    mon = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите ID:");
                    var id  = Convert.ToInt32(Console.ReadLine());
                    //var connection2 = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
                    //NpgsqlCommand comand = new NpgsqlCommand("INSERT INTO \"Models\" (\"ID\", \"Name\", \"Year\",\"ManufacturerId\") values (11, \'" + nme +"\', " + yar + "," + mon + ")");
                    ////var command2 = connection2.CreateCommand();
                    //connection2.Open();
                    //comand.Connection = connection2;
                    //comand.ExecuteNonQuery();
                    modelerRepo.Insert(new Modeler
                    { choco_name = nme, choco_yar = yar, choco_number = mon , choco_id = id});
                    Console.WriteLine("Успешно");
                    Console.WriteLine();
                }
            


                //if (choise == 4)
                //{
                //    Console.WriteLine("4. Новый список всех моделей:");
                //    var connection11 = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
                //    connection11.Open();
                //    var command11 = connection11.CreateCommand();
                //    command11.CommandText = "select \"Name\" as modname from \"Models\" ";
                //    var reader11 = command11.ExecuteReader();
                //    while (reader11.Read())
                //    {
                //        Console.WriteLine(reader11["modname"]);
                //    }
                //    Console.WriteLine();
                //}


                if (choise == 4)
                {
                    Console.WriteLine("4. Удаление строки в таблице Модели:");
                    Console.WriteLine("Введите название Шоколада, который хотите удалить:");
                    var nam_ch = Console.ReadLine();
                    //var connection5 = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
                    //connection5.Open();
                    //var command5 = connection5.CreateCommand();
                    //command5.CommandText = "DELETE FROM \"Models\" " + "WHERE \"Name\" = \'"+nam_ch+"\'";

                    //command5.ExecuteNonQuery();
                    modelerRepo.DeleteByName(new Modeler { choco_name = nam_ch });
                    Console.WriteLine("Удаление прошло успешно.");
                }


                //if (choise == 6)
                //{
                //    Console.WriteLine("6. Новый список всех моделей:");
                //    var connection6 = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
                //    connection6.Open();
                //    var command6 = connection6.CreateCommand();
                //    command6.CommandText = "select \"Name\" as modname from \"Models\" ";
                //    var reader6 = command6.ExecuteReader();
                //    while (reader6.Read())
                //    {
                //        Console.WriteLine(reader6["modname"]);
                //    }
                //    Console.WriteLine();
                //}


                if (choise == 5)
                {
                    Console.WriteLine("5. Обновление даннх в таблице:");
                    //Console.WriteLine("Введите имя модли шоколада, год производства которого вы хотите поменять:");
                    //var nam_ch7 = Console.ReadLine();
                    Console.WriteLine("Введите нов name:");
                    var nam_ch7 = Console.ReadLine();
                    Console.WriteLine("Введите год выпуска:");
                    var yar = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите номер производителя:");
                    var mon = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите ID:");
                    var id = Convert.ToInt32(Console.ReadLine());
                    //var connection7 = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
                    //connection7.Open();
                    ////var command7 = connection7.CreateCommand();

                    //using (var command7 = connection7.CreateCommand())
                    //{
                    //    command7.CommandText = "UPDATE \"Models\" set \"Name\" =@newname  WHERE \"ID\" =@oldname";
                    //    command7.Parameters.AddWithValue("@newname", "" + nam_ch7 + "");                      
                    //    command7.Parameters.AddWithValue("@oldname", 11);
                    //    command7.ExecuteNonQuery();
                    //    Console.WriteLine(nam_ch7);

                    //    Console.WriteLine();
                    //}
                    modelerRepo.UpdateById(new Modeler
                    { choco_id = id, choco_name = nam_ch7, choco_yar = yar, choco_number = mon});
                }
                   



            //Console.WriteLine("8. Новый список всех моделей:");
            //var connection8 = new NpgsqlConnection("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
            //connection8.Open();
            //var command8 = connection8.CreateCommand();
            //command8.CommandText = "select \"Year\" as modname from \"Models\" ";
            //var reader8 = command8.ExecuteReader();
            //while (reader8.Read())
            //{
            //    Console.WriteLine(reader8["modname"]);
            //}
            //Console.WriteLine();
            //Console.ReadLine();
            }
        }
            
    }
}

