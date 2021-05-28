using Prova.Core.Interfaces;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prova.Core.BusinessLayer
{
    public class LibraryBL : ILibraryBL
    {
        private readonly IClienteRepository clienteRepo;
        private readonly IOrdineRepository ordineRepo;

        public LibraryBL(
            IClienteRepository clienteRepo,
            IOrdineRepository ordineRepo
            )
        {
            this.clienteRepo = clienteRepo;
            this.ordineRepo = ordineRepo;
        }

        #region Cliente

        public Cliente FetchClienteByID(int id)
        {
            return clienteRepo.Fetch().FirstOrDefault(c => c.ID == id);
        }

        public IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null)
        {
            return clienteRepo.Fetch();
        }

        public bool CreateCliente(Cliente newCliente)
        {
            return clienteRepo.Add(newCliente);
        }

        public bool EditCliente(Cliente editedCliente)
        {
            return clienteRepo.Update(editedCliente);
        }

        public bool DeleteCliente(Cliente clienteToBeDeleted)
        {
            return clienteRepo.Delete(clienteToBeDeleted);
        }

        #endregion

        #region Ordine

        public bool CreateOrdine(Ordine newOrdine)
        {
            return true;
        }

        public bool EditOrdine(Ordine editedOrdine)
        {
            return true;
        }

        public bool DeleteOrdine(object ordineToBeDeleted)
        {
            return true;
        }

        public Ordine FetchOrdineById(int id)
        {
            return null;
        }

        public IEnumerable<Ordine> FetchOrdini()
        {
            return null;
        }

        public bool OrdineCliente(int id, string cod, string prod)
        {
            return ordineRepo.Add(new Ordine
            {
                ClienteID = id,
                DataOrdine = DateTime.Now,
                CodiceOrdine = cod,
                CodiceProdotto = prod,
                Importo = null
            });
        }

       

        #endregion
    }
}
