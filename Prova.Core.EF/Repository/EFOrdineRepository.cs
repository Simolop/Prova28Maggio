using Prova.Core.Interfaces;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prova.Core.EF.Repository
{
    public class EFOrdineRepository : IOrdineRepository
    {
        private readonly LibraryContext ctx;

        public EFOrdineRepository() : this(new LibraryContext())
        {

        }

        public EFOrdineRepository(LibraryContext ctx)
        {
            this.ctx = ctx;
        }


        public bool Add(Ordine item)
        {
            try
            {
                ctx.Ordini.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Ordine item)
        {
            try
            {
                var ordine = ctx.Ordini.Find(item.ID);

                if (ordine != null)
                    ctx.Ordini.Remove(ordine);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ordine> Fetch()
        {
            try
            {
                return ctx.Ordini.ToList();
            }
            catch (Exception)
            {
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            try
            {
                var ordine = ctx.Ordini.Find(id);

                return ordine;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Ordine item)
        {
            try
            {
                ctx.Ordini.Update(item);
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
