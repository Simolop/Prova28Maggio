using Microsoft.EntityFrameworkCore;
using Prova.Core.EF;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.EntityFrk.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Entity Framework - Prova ---");

            Console.WriteLine();

            using (LibraryContext ctx = new LibraryContext())
            {
                Cliente c1 = new Cliente
                {
                    CodiceCliente = "123H",
                    Nome = "Pino",
                    Cognome = "Aragonesi"
                };

                Cliente c2 = new Cliente
                {
                    CodiceCliente = "123U",
                    Nome = "Serena",
                    Cognome = "Chiari"
                };
               
                Ordine o1 = new Ordine
                {
                    ClienteID = 1,
                    DataOrdine = new DateTime(2021-01-01),
                    CodiceOrdine = "2367hgf",
                    CodiceProdotto = "56hgjd",
                    Importo = 67
                };

                Ordine o2 = new Ordine
                {
                    ClienteID = 2,
                    DataOrdine = new DateTime(2021 - 05 - 04),
                    CodiceOrdine = "23fr67f",
                    CodiceProdotto = "56s5690k",
                    Importo = 35
                };

                ctx.Clienti.Add(c1);
                ctx.Clienti.Add(c2);
                ctx.Ordini.Add(o1);
                ctx.Ordini.Add(o2);
                ctx.SaveChanges();

                Console.WriteLine("--Elenco Clienti--");
                foreach (var item in ctx.Clienti)
                    Console.WriteLine($"[{item.ID}] Codice Cliente: {item.CodiceCliente} - Cliente: {item.Nome} {item.Cognome}");

                Console.WriteLine();

                Console.WriteLine("--Elenco Ordini--");
                foreach (var item in ctx.Ordini)
                    Console.WriteLine($"[{item.ID}] Codice Ordine: {item.CodiceOrdine} - Codice Prodotto: {item.CodiceProdotto} - Data Ordine: {item.DataOrdine} - Importo: {item.Importo}");

                Console.WriteLine();

                Console.WriteLine("--Ordini e clienti--");
                foreach (var item in ctx.Ordini.Include(o => o.Cliente))  // Eager Loading
                    Console.WriteLine($"[{item.ID}] Codice Ordine: {item.CodiceOrdine} - Codice Prodotto: {item.CodiceProdotto} - Data Ordine: {item.DataOrdine} - Importo: {item.Importo} - Cliente: {item.Cliente.Nome} {item.Cliente.Cognome}");


                Console.ReadLine();
            }
        }
    }
}
