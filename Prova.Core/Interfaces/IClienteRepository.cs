using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Core.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetByID(int id);
    }
}
