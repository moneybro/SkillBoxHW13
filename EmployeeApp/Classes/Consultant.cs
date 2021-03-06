using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Classes;
using ClassLibrary.Methods;
using EmployeeApp.Views;

namespace EmployeeApp
{
    public class Consultant : Employee
    {
        public Consultant()
        {
            this.FirstName = default;
            this.LastName = default;
            this.Age = default;
            this.Salary = default;
        }
        public Consultant(int id, string fn, string ln, int age, int salary)
        {
            this.Id = id;
            this.FirstName = fn;
            this.LastName = ln;
            this.Age = age;
            this.Salary = salary;
            this.BankAccActions = new BankAccActions();
            this.TransactionsActions = new BankAccActions();
        }
        public override string Type => "consultant";
        public override Client AddNewClient()
        {
            return null;
        }
        public override void ChangeClient(Client _client)
        {
            EditClient editClient = new EditClient(_client, this);
            if (editClient.ShowDialog() == true) editClient.Close();
        }
        public override bool DeleteClient(Client client)
        {
            return false;
        }
        public override List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            clients.AddRange(ClientCommonMethods.GetClientsAllData());
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].PaspSeria = 0;
                clients[i].PaspNum = 0;
            }
            return clients;
        }
    }
}
