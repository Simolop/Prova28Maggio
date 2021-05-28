using Prova.Core.BusinessLayer;
using Prova.Core.EF.Repository;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Prova.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LibraryService : ILibraryService
    {
        ILibraryBL bl;

        public LibraryService()
        {
            var clienteRepo = new EFClienteRepository();
            var ordiniRepo = new EFOrdineRepository();

            bl = new LibraryBL(clienteRepo, ordiniRepo);
        }

        public bool AddNewCliente(Cliente newCliente)
        {
            try
            {
                return bl.CreateCliente(newCliente);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClienteByID(int id)
        {
            try
            {
                var cliente = GetClienteByID(id);

                return bl.DeleteCliente(cliente);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditCliente(Cliente updatedCliente)
        {
            try
            {
                return bl.EditCliente(updatedCliente);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> GetCliente()
        {
            try
            {
                return bl.FetchClienti().ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public Cliente GetClienteByID(int id)
        {
            try
            {
                return bl.FetchClienteByID(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool OrdineCliente(int id, string cod, string prod)
        {
            try
            {
                return bl.OrdineCliente(id, cod, prod);
            }
            catch (Exception)
            {
                return false;
            }
        }

       

        
    }
}
