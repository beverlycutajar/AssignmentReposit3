using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private ShoppingCartDbContext _context;
        public ClientsRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public void AddClient(Client m)
        {
            _context.Clients.Add(m);
            _context.SaveChanges();
        }
    }
}
