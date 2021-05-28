using Microsoft.EntityFrameworkCore;
using Prova.Core.Interfaces;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prova.Core.EF.Repository
{
    public class EFClienteRepository : IClienteRepository
    {
        private readonly LibraryContext ctx;

        public EFClienteRepository() : this(new LibraryContext())
        {

        }

        public EFClienteRepository(LibraryContext ctx)
        {
            this.ctx = ctx;
        }


        public bool Add(Cliente newCliente)
        {
            try
            {
                ctx.Clienti.Add(newCliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Cliente item)
        {
            try
            {
                var cliente = ctx.Clienti.Find(item.ID);

                if (cliente != null)
                    ctx.Clienti.Remove(cliente);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Cliente> Fetch()
        {
            try
            {
                return ctx.Clienti.ToList();
            }
            catch (Exception)
            {
                return new List<Cliente>();
            }
        }

        public Cliente GetByID(int id)
        {
            try
            {
                var cliente = ctx.Clienti.Include(c => c.Ordini)
                    .FirstOrDefault(c => c.ID == id);

                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente updatedCliente)
        {
            try
            {
                ctx.Clienti.Update(updatedCliente);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
