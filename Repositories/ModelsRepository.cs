using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задание_Crud_создание_клиента.Models;
using Npgsql;
using Dapper;
namespace Задание_Crud_создание_клиента.Repositories
{
    internal class ModelsRepository : IModelsRepository
    {
        private NpgsqlConnection _connection;
        public ModelsRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }
        public IList<Modeler> GetAll()
        {

            var result = new List<Modeler>();

            using (var command = _connection.CreateCommand())
            {

                command.CommandText = "select \"Name\", \"ID\" from \"Models\" ";
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Modeler
                    {
                        choco_id = reader.GetInt32((reader.GetOrdinal("ID"))),
                        MName = reader.GetString((reader.GetOrdinal("Name"))),
                    });
                }
                return result;
            }

        }
        public void Insert(Modeler model)
        {
            var CommandText = "INSERT INTO \"Models\" (\"ID\", \"Name\", \"Year\",\"ManufacturerId\")  VALUES (@id, @name, @y, @num)";

            var queryArguments = new
            {
                name = model.choco_name,
                y = model.choco_yar,
                num = model.choco_number,
                id = model.choco_id
            };

            _connection.Execute(CommandText, queryArguments);
        }
        public void DeleteByName(Modeler model)
        {           
            var CommandText = "DELETE FROM \"Models\" " + "WHERE \"Name\" = (@name)";
            var queryArguments = new
            {
                name = model.choco_name
            };

            _connection.Execute(CommandText, queryArguments);
        }
        public void UpdateById(Modeler model)
        {

            var CommandText = "UPDATE \"Models\" set \"Name\" =@name,  \"Year\"=@y, \"ManufacturerId\"=@num  WHERE \"ID\" =@id";
            var queryArguments = new
            {
                id = model.choco_id,
                name = model.choco_name,
                y = model.choco_yar,
                num = model.choco_number
            };

            _connection.Execute(CommandText, queryArguments);
        }
    }

}
