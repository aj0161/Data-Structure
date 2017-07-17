using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjectionExample
{
    class Program
    {
        static void Main(string[] args)
         {
            //-------------------------------------------Constructor Injection--------------------------------------------------------------------------//
                        /// Constructor Injection. Benefit:provides loose coupling (PurchaseBl is independent from lower level class)
                        /// Now think if you need to save information to TextFile then you don’t need to change the PurchaseBL class.
                        /// You just have to pass another TextRepository class which is responsible for saving data to text file
            
            //Creating dependency
            IRepository dbRepository = new PrinterRepository(); // change this if required
            //injecting dbRepository
            PurchaseBl purchaseBl = new PurchaseBl(dbRepository);
            Console.WriteLine(purchaseBl.SavePurchaseOrder());
        }
    }
   
    //Pass dependencies to dependent class through constructor.PurchaseBl class which is responsible to perform save operation and depends on IRepository.   
    public class PurchaseBl
    {
        private readonly IRepository _repository;

        //passes the dependencies through constructor
        public PurchaseBl(IRepository repository)
        {
            _repository = repository;
        }

        public string SavePurchaseOrder()
        {
            return _repository.Save();
        }
    }

    public interface IRepository
    {
        string Save();
    }

    public class Repository : IRepository
    {
        public string Save()
        {
            return "I am saving data to Database.";
        }
    }

    class TextRepository : IRepository
    {
        public string Save()
        {
            return "I am saving data to TextFile.";
        }
    }

    class PrinterRepository : IRepository
    {
        public string Save()
        {
            return "I am saving data to Printer.";
        }
    }
}
