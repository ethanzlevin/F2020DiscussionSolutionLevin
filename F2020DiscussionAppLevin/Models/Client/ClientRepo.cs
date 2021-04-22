using F2020DiscussionAppLevin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F2020DiscussionAppLevin.Models
{
    public class ClientRepo : IClientRepo
    {
        private ApplicationDbContext database;


        // dependancy injection
        public ClientRepo(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public Client FindClient(string clientID)
        {
            Client client = database.Client.Find(clientID);
            return client;
        }

        public List<Client> ListAllClients()
        {
            List<Client> clients = database.Client.ToList();
            return clients;
        }
    }
}
