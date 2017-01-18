using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CustomersRepo : ICustomersRepo
    {
        private CustomerContext db = new CustomerContext();

        public Customer create_customer(Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
            return c;
        }

        public bool delete_customer(int key)
        {

            Customer cust = db.Customers.FirstOrDefault(c => c.id == key);
            if (cust != null)
            {
                db.Remove(cust);
                db.SaveChanges();
            }
            return (db.Customers.FirstOrDefault(c => c.id == key) == null);
        }

        public ICollection<Customer> get_all_customers()
        {
            return db.Customers.ToList();
        }

        public Customer get_customer(int key)
        {
            return db.Customers.FirstOrDefault(c => c.id == key);
        }

        public Customer update_customer(Customer c)
        {
            Customer original = db.Customers.FirstOrDefault(i => i.id == c.id);
            if (original == null)
                return null;
            original.FirstName = c.FirstName;
            original.LastName = c.LastName;
            original.age = c.age;
            db.SaveChanges();
            return original;
        }
    }
}
