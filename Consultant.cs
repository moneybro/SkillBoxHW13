﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBoxHW11
{
    internal class Consultant : Employee
    {
        protected override string Type => "consultant";
        
        public override Client ChangeClient(Client _client)
        {
            Client client = _client;
            EditClient editClient = new EditClient(client, this);
            if(editClient.ShowDialog() == true) _client = editClient.editedClient;
            editClient.Close();
            base.SaveEditedClient(client, this);
            return _client;
        }

        public override List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            clients.AddRange(base.getClientsAllData());
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].PaspSeria = 0;
                clients[i].PaspNum = 0;
            }
            return clients;
        }

        public override List<Client> RefreshClientsView(List<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].PaspSeria = 0;
                clients[i].PaspNum = 0;
            }
            return clients;
        }
    }
}
