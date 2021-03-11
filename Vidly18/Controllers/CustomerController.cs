using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly18.Models;
using Vidly18.ViewModel;

namespace Vidly18.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var c = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);
            if (c == null)
            {
                return new HttpNotFoundResult();
            }
            return View(c);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Customer(int? id)
        {
            Customer customer;

            if (id == null)
            {
                customer = new Customer();
            }
            else
            {
                customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            }
            if (customer==null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerVIewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customer
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var vm = new CustomerVIewModel
                {
                    Customer = new Customer(),
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return RedirectToAction("Movie", vm);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                _context.Entry(customer).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}