using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ClientsService : IClientService
    {
        public IClientsRepository _clientRepo;
        public ClientsService(IClientsRepository clientsRepo)
        {
            _clientRepo = clientsRepo;
        }
        public void AddClient(ClientViewModel c)
        {
            Client client = new Client()
            {
                email = c.email,
                FirstName = c.FirstName,
                LastName = c.LastName
            };
            _clientRepo.AddClient(client);
        }
    }
}
