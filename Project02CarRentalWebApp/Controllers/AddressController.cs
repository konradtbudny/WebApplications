using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using Project02CarRentalWebApp.Models;

namespace Project02CarRentalWebApp.Controllers
{
    public class AddressController : Controller
    {
        int pageSize = 2;
        private CarRentalDbContext db = new CarRentalDbContext();
        private static Dictionary<string, DateTime> ipDictionary = new Dictionary<string, DateTime>();
        public ActionResult Index(string searchPhrase, string order, int? pageNumber, int? pageSize)
        {
            ViewBag.searchPhrase = searchPhrase;
            if (pageSize != null)
            {
                this.pageSize = (int)pageSize;
            }
            List<Address> list;
            if (!String.IsNullOrWhiteSpace(searchPhrase))
            {
                list = db.Addresses.Where(a => a.CityName.Contains(searchPhrase) ||
                                               a.StreetName.Contains(searchPhrase) ||
                                               a.ZipCode.Contains(searchPhrase) ||
                                               a.Email.Contains(searchPhrase) ||
                                               a.PhoneNumber.Contains(searchPhrase)).ToList();
            }
            else
            {
                list = db.Addresses.ToList();
            }
            if (!String.IsNullOrWhiteSpace(order))
            {
                var splitOrder = order.Split('_');
                var propertyName = splitOrder[0];
                order = splitOrder[1];
                if (order.Equals("Asc"))
                {
                    list = list.OrderBy(o => o.GetType().GetProperty(propertyName).GetValue(o, null)).ToList();
                }
                else if (order.Equals("Desc"))
                {
                    list = list.OrderByDescending(o => o.GetType().GetProperty(propertyName).GetValue(o, null)).ToList();
                }
            }
            ViewBag.TotalPageNumber = GetNumberPages(list);
            int currentPage = pageNumber.HasValue ? pageNumber.Value : 1;
            currentPage = ViewBag.TotalPageNumber < currentPage ? ViewBag.TotalPageNumber : currentPage;
            currentPage = currentPage < 1 ? 1 : currentPage;
            list = list.Skip((currentPage - 1) * this.pageSize).Take(this.pageSize).ToList();
            ViewBag.CurrentPageNumber = currentPage;
            return View(list);
        }
        public int GetNumberPages(List<Address> list)
        {
            int recordNumber = list != null ? list.Count() : 0;
            return recordNumber % pageSize == 0 ?
                 (recordNumber / pageSize) :
                 (recordNumber / pageSize + 1);
        }

        // GET: Address/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            AddressDetailsViewModel addressDetailsViewModel = new AddressDetailsViewModel { Address = address, Surveys = db.Surveys.ToList() };
            return View(address);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CityName,StreetName,ZipCode,Email,PhoneNumber,ImportanceLevel")] Address address)
        {
            if (ModelState.IsValid)
            {
                address.Id = Guid.NewGuid();
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(address);
        }
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CityName,StreetName,ZipCode,Email,PhoneNumber,ImportanceLevel")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(address);
        }
        public void SendEmail(Guid addressId, string messageText)
        {
            string ip = Request.UserHostAddress;
            if (ipDictionary.Keys.Contains(ip) && (DateTime.Now - ipDictionary[ip]).Seconds < 20)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }
            if (!ipDictionary.Keys.Contains(ip))
            {
                ipDictionary.Add(ip, DateTime.Now);
            }
            else if (ipDictionary.Keys.Contains(ip) && (DateTime.Now - ipDictionary[ip]).Seconds > 20)
            {
                ipDictionary[ip] = DateTime.Now;
            }

            var toSendAddress = db.Addresses.Find(addressId);
            if (string.IsNullOrWhiteSpace(toSendAddress.Email))
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.BadRequest);
            }

            SmtpClient smtp = new SmtpClient();
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress(toSendAddress.Email));
            message.Subject = "subject";
            message.Body = messageText;
            {
                smtp.Send(message);
            }
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
