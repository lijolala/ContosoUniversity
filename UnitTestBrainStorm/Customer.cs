using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestBrainStorm
{

    public interface ICustomerRepository
    {
        Customer GetCustomerById(int customerId);
        string GetInitialName();
    }

    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        List<Customer> listCustomers = new List<Customer>();

        public Customer GetCustomerById(int id)
        {
            return listCustomers.First(x => x.ID == id);
        }

        public string GetInitialName()
        {
            return "Append this before";
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
                return string.Format("{0} {1} {2}", this._customerRepository.GetInitialName(), customer.FirstName, customer.LastName);
            }

        }
    }
}
