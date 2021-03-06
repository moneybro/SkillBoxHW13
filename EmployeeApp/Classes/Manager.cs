using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary.Classes;
using ClassLibrary.Methods;
using EmployeeApp.Views;

namespace EmployeeApp
{
    public class Manager : Employee
    {
        public Manager()
        {
            this.FirstName = default;
            this.LastName = default;
            this.Age = default;
            this.Salary = default;
        }
        public Manager(int id, string fn, string ln, int age, int salary)
        {
            this.Id = id;
            this.FirstName = fn;
            this.LastName = ln;
            this.Age = age;
            this.Salary = salary;
            this.BankAccActions = new BankAccActions();
            this.TransactionsActions = new BankAccActions();
        }
        public override string Type => "manager";
        public override Client AddNewClient()
        {
            Client newClient;
            long newClID = ClientCommonMethods.getNewClientId();
            EditClient createNewClientWin = new EditClient(newClID);
            if (createNewClientWin.ShowDialog() == true)
            {
                var newMainAccForNewClient = GetNewMainAcc(newClID);
                newClient = createNewClientWin.editedClient;
                if (newClient != null)
                {
                    createNewClientWin.Close();
                    base.SaveEditedClient(newClient, this);
                    DateTime now = DateTime.Now;
                    this.BankAccActions.SaveAcc(newMainAccForNewClient, GlobalVarsAndActions.MainAccsRepoPath, now, now);
                    return newClient;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public override void ChangeClient(Client _client)
        {
            EditClient editClient = new EditClient(_client, this);
            if (editClient.ShowDialog() == true) editClient.Close();
        }
        public override bool DeleteClient(Client client)
        {
            Client clientToDel = client;
            if (clientToDel != null)
            {
                clientToDel.Status = "deleted";
                if (base.SaveEditedClient(clientToDel, this))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override List<Client> GetClients()
        {
            return ClientCommonMethods.GetClientsAllData();
        }
        internal BankAccMain GetNewMainAcc(long clId)
        {
            return BankAccActions.GetNewMainAcc(clId);
        }
        public BankAccDepo GetNewDepoAcc(long clId)
        {
            return BankAccActions.GetNewDepoAcc(clId);
        }
        public List<BankAccForClient> GetClientAccs(long clId)
        {
            return BankAccActions.GetClientAccs(clId);
        }
        bool CloseAcc(long accNum)
        {
            return BankAccActions.CloseAcc(accNum);
        }
    }
}
