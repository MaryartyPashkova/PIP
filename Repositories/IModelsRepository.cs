using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задание_Crud_создание_клиента.Models;

namespace Задание_Crud_создание_клиента.Repositories
{
    internal interface IModelsRepository
    {
        IList<Modeler> GetAll();
        void Insert(Modeler model);
        void DeleteByName(Modeler model);
        void UpdateById(Modeler model);
    }
}
