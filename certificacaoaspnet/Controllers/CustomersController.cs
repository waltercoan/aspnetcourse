using certificacaoaspnet.DAL;
using System.Data.Entity;
using certificacaoaspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using certificacaoaspnet.ViewModels;

namespace certificacaoaspnet.Controllers
{
    public class CustomersController : Controller
    {
        private CertificacaoDbContext _context;

        public CustomersController()
        {
            _context = new CertificacaoDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
                
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }


            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers; Executa a consulta de forma lazy
            //executa a consulta na hora
            //Include força ele a carregar objeto associado Eager mode
            //var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            //return View(customers);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound("Deu ruim");

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            /*var customer = from Customer c in customers
                           where c.Id == id
                           select c;*/
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound("Deu Ruim");

            //return View(customer.First());
            return View(customer);
        }
        /*
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1,Name="John Smith"},
                new Customer{Id=2,Name="Mary Williams"}
            };
        }*/
    }
}