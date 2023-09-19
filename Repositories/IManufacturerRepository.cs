using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Задание_Crud_создание_клиента.Models;

namespace Задание_Crud_создание_клиента.Repositories
{
    //class IManufacturerRepository
    //{
       
    //}
    internal interface IManufacturerRepository
    {
        IList<Manufacturer> GetAll();
    }
}
