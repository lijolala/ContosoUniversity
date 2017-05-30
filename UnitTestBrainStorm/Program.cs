using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBrainStorm
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public int Add(int i, int j)
        {
            int result;
            result = i + j;
            return result;
        }

    }

    public interface ICalculator
    {
        int Add(int a, int b);
        string Mode { get; set; }
        event EventHandler PoweringUp;
    }

    public interface ICommand
    {
        void Execute();
        event EventHandler Executed;
    }

    public class SomethingThatNeedsACommand
    {
        ICommand command;
        public SomethingThatNeedsACommand(ICommand command)
        {
            this.command = command;
        }
        public void DoSomething() { command.Execute(); }
        public void DontDoAnything() { }
    }

    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerId);
    }

    public class Customer
    {
        public int ID { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }

        List<Customer> listCustomers = new List<Customer>();
       
        
        //public Customer()
        //{
        //    listCustomers.Add(new Customer { ID = 1, FirstName = "Lijo", LastName = "jolly" });
        //    listCustomers.Add(new Customer { ID = 1, FirstName = "Thomas", LastName = "Coook" });
        //    listCustomers.Add(new Customer { ID = 1, FirstName = "Alwa", LastName = "Edison" });

        //}

        public Customer GetCustomerById(int id)
        {
            return listCustomers.First(x => x.ID == id);    
        }


        public class CustomerService
        {
            private ICustomerRepository _customerRepository;

            public CustomerService(ICustomerRepository customerRepository)
            {
                this._customerRepository = customerRepository;
            }

            public string GetFullName(int customerId)
            {
                Customer customer = this._customerRepository.GetCustomerById(customerId);
                return string.Format("{0} {1}", customer.FirstName, customer.LastName);
            }
        }
    }
        
  
}
