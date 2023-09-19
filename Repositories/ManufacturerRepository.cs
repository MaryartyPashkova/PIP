using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задание_Crud_создание_клиента.Models;
using Npgsql;

namespace Задание_Crud_создание_клиента.Repositories
{
    internal class ManufacturerRepository : IManufacturerRepository
    {
        private NpgsqlConnection _connection;

        public ManufacturerRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }


       

        public IList<Manufacturer> GetAll()
        {

            var result = new List<Manufacturer>();

            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select \"Name\", \"id\" from \"Manufactures\" ";
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Manufacturer
                    {
                        numb = reader.GetInt32((reader.GetOrdinal("id"))),
                        Name = reader.GetString((reader.GetOrdinal("Name"))),
                    });
                }
                return result;
            }
        }
    }
    
    
}
