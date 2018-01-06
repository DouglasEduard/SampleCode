using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using System.Data.Entity;
using Vidly2.ViewModels;


namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();

            var ViewModel = new CustomerDetail
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", ViewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            //return View(customers);
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            CustomerDetail ResultView = new CustomerDetail();
            ResultView.Id = customer.Id;
            ResultView.Name = customer.Name;
            ResultView.MembershipType = customer.MembershipType.Name;
            ResultView.Birthdate = customer.Birthdate;

            return View(ResultView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerDetail {
                    Name = customer.Name,
                    Birthdate = customer.Birthdate,
                    MembershipTypes = _context.MembershipType.ToList(),
                    MembershipTypeId = customer.MembershipTypeId
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerDetail
            {
                Name = customer.Name,
                Birthdate = customer.Birthdate,
                MembershipTypes = _context.MembershipType.ToList(),
                MembershipTypeId = customer.MembershipTypeId
            };

            viewModel.Operation = "Edit";

            return View("CustomerForm", viewModel);
        }
    }
}