using Prova.Core.Model;
using System;
using System.Collections.Generic;

namespace Prova.Core.BusinessLayer
{
    public interface ILibraryBL
    {
        #region Cliente

        IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null);

        bool CreateCliente(Cliente newCliente);
        bool EditCliente(Cliente editedCliente);
        bool DeleteCliente(Cliente clienteToBeDeleted);
        Cliente FetchClienteByID(int id);



        #endregion

        #region Ordine

        bool OrdineCliente(int id, string cod, string prod);
        

        #region CRUD

        IEnumerable<Ordine> FetchOrdini();
        Ordine FetchOrdineById(int id);
        bool CreateOrdine(Ordine newOrdine);
        bool EditOrdine(Ordine editedOrdine);
        bool DeleteOrdine(object ordineToBeDeleted);
       


        #endregion

        #endregion

    }
}