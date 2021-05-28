using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Prova.WCF
{
    [ServiceContract]
    public interface ILibraryService
    {
        [OperationContract]
        List<Cliente> GetCliente();

        [OperationContract]
        Cliente GetClienteByID(int id);

        [OperationContract]
        bool AddNewCliente(Cliente newCliente);

        [OperationContract]
        bool EditCliente(Cliente updatedCliente);

        [OperationContract]
        bool DeleteClienteByID(int id);

        [OperationContract]
        bool OrdineCliente(int id, string cod, string prod);

        

    }
}
