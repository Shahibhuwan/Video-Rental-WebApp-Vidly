using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext __context;

        public CustomersController()
        {
            __context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            __context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = __context.Customers.Include(c => c.MembershipType).ToList();            // ego loading which means loading membershiptype object with customer object//to list is used to execute query immediatiley whith out goinng to view for iteration

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = __context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int id)
        {

            var customer = __context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = __context.MembershipTypes.ToList()
            };

            return View("New", viewModel);                                                       //redirect to the new view
        }
        public ActionResult New()
        {
            var membershipTypes = __context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {  Customer = new Customer(),                          // this line will make the hidden field id of new form to initialized to 0 and the other properties of customer to default
                MembershipTypes = membershipTypes                                               //here we have  collected data of membershiptype table into membershiptypes variable then we have palced memebershiptype varibledata into the object of newcoustomerviewmodel class of viewmodel ie enumurable of membershiptype  
            };
            return View(viewModel);

        }
        [HttpPost]                                                                              // can be used only by httppost method
        [ValidateAntiForgeryToken]                                                                                          // public ActionResult create(NewCustomerViewModel viewModel) // model binding in which MVC will automatically bind the request data of form to this viewModel object 
        public ActionResult Create(Customer customer)                                          // as all the properties of form are in Customer class so mvc in smart enough to bind this object with form data
        {
            if(!ModelState.IsValid)                                                                                             //ModelState.IsValid indicates if it was possible to bind the incoming values from the request to the model correctly and whether any explicitly specified validation rules were broken during the model binding process.
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = __context.MembershipTypes.ToList()

                };

                return View("New",viewModel);

            
            }
            if (customer.Id == 0)
            {                                                                                 // if id is 0 then it is new customer so addd it to database else update the esiting coustomer
                __context.Customers.Add(customer);
            }

            // save data into memmory
            else
            {
                var customerInDb = __context.Customers.Single(c => c.Id == customer.Id); // in c object id propertie in returned
                                                                                             //TryUpdateModel(customerInDb); create security issue cuz can update every field
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                                                                                             //outmapper   Mapper.Map(customer, customerInDb)

            }
            __context.SaveChanges();                                                             //now update in the database by generating in query for database with acid propertie doing all transaction or nothing

            return RedirectToAction("Index", "Customers");
        }

    }                                                                                               // create act as update or save to all and also class and view name is changed

}