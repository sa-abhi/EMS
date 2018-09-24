using EventManagementSystem.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Web.Mvc;

using EventManagementSystem.ViewModels;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EventManagementSystem.Controllers
{
    public class ClientOrderVMController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ClientOrderVM
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {

            List<ClientOrderViewModel> covm = new List<ClientOrderViewModel>();

            var clientOrderDetails = (from co in db.ClientOrders
                                      join cl in db.Clients
                                      on co.ClientID equals cl.ClientID
                                      join ep in db.EventsPhotographies
                                      on co.ClientOrderID equals ep.ClientOrderID
                                      join city in db.Cities
                                      on co.CityID equals city.CityID
                                      join et in db.EventTypes
                                      on co.EventTypeID equals et.EventTypeID
                                      join est in db.EventSubTypes
                                      on co.EventSubTypeID equals est.EventSubTypeID
                                      join vn in db.Venues
                                      on co.VenueID equals vn.VenueID

                                      select new { co.ClientOrderID, cl.ClientID, cl.Name, city.CityName, et.EventTypeName, est.EventSubTypeName, co.EventName, co.EventStartDate, co.EventEndDate, co.NoOfGuest, vn.VenueName, co.SpecialInstruction }).ToList();

            foreach (var item in clientOrderDetails)
            {
                ClientOrderViewModel cvm = new ClientOrderViewModel();
                cvm.ClientOrderID = item.ClientOrderID;
                cvm.Name = item.Name;
                cvm.CityName = item.CityName;
                cvm.EventTypeName = item.EventTypeName;
                cvm.EventSubTypeName = item.EventSubTypeName;
                cvm.EventName = item.EventName;
                cvm.EventStartDate = item.EventStartDate;
                cvm.EventEndDate = item.EventEndDate;

                cvm.NoOfGuest = item.NoOfGuest;
                cvm.VenueName = item.VenueName;
                cvm.SpecialInstruction = item.SpecialInstruction;
                covm.Add(cvm);
            }
            return View(covm);
        }

        [Authorize]
        public ActionResult IndexByID()
        {
            var context = new IdentityDbContext();
            var users = context.Users.ToList();
            var user = User.Identity.Name;
            var Usercontact = users.Where(m => m.UserName == user).Single();
            var contact = Usercontact.PhoneNumber;
            var clID = db.Clients.Where(c => c.Phone == contact).Select(i => i.ClientID).FirstOrDefault();

            List<ClientOrderViewModel> covm = new List<ClientOrderViewModel>();

            var clientOrderDetails = (from co in db.ClientOrders
                                      join cl in db.Clients
                                      on co.ClientID equals cl.ClientID
                                      join ep in db.EventsPhotographies
                                      on co.ClientOrderID equals ep.ClientOrderID
                                      join city in db.Cities
                                      on co.CityID equals city.CityID
                                      join et in db.EventTypes
                                      on co.EventTypeID equals et.EventTypeID
                                      join est in db.EventSubTypes
                                      on co.EventSubTypeID equals est.EventSubTypeID
                                      join vn in db.Venues
                                      on co.VenueID equals vn.VenueID
                                      where cl.ClientID== clID
                                      select new { co.ClientOrderID, cl.ClientID, cl.Name, city.CityName, et.EventTypeName, est.EventSubTypeName, co.EventName, co.EventStartDate, co.EventEndDate, co.NoOfGuest, vn.VenueName, co.SpecialInstruction }).ToList();

            foreach (var item in clientOrderDetails)
            {
                ClientOrderViewModel cvm = new ClientOrderViewModel();
                cvm.ClientOrderID = item.ClientOrderID;
                cvm.Name = item.Name;
                cvm.CityName = item.CityName;
                cvm.EventTypeName = item.EventTypeName;
                cvm.EventSubTypeName = item.EventSubTypeName;
                cvm.EventName = item.EventName;
                cvm.EventStartDate = item.EventStartDate;
                cvm.EventEndDate = item.EventEndDate;

                cvm.NoOfGuest = item.NoOfGuest;
                cvm.VenueName = item.VenueName;
                cvm.SpecialInstruction = item.SpecialInstruction;
                covm.Add(cvm);
            }
            return View(covm);
        }
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                ClientOrderViewModel cvm = new ClientOrderViewModel();


                var clientOrderDetails = (from co in db.ClientOrders
                                          join cl in db.Clients
                                          on co.ClientID equals cl.ClientID
                                          join ep in db.EventsPhotographies
                                          on co.ClientOrderID equals ep.ClientOrderID
                                          join city in db.Cities
                                          on co.CityID equals city.CityID
                                          join et in db.EventTypes
                                          on co.EventTypeID equals et.EventTypeID
                                          join est in db.EventSubTypes
                                          on co.EventSubTypeID equals est.EventSubTypeID
                                          join vn in db.Venues
                                          on co.VenueID equals vn.VenueID
                                          where co.ClientOrderID == id
                                          select new
                                          {
                                              co.ClientOrderID,
                                              cl.Name,
                                              city.CityName,
                                              et.EventTypeName,
                                              est.EventSubTypeName,
                                              co.EventName,
                                              co.EventStartDate,
                                              co.EventEndDate,
                                              co.NoOfGuest,
                                              vn.VenueName,
                                              co.SpecialInstruction,
                                              ep.EventsPhotographyID,
                                              ep.Category,
                                              ep.NumberOfTeam,
                                              ep.Price
                                          }).FirstOrDefault();

                var eventCate = db.EventsCaterings.Where(i => i.ClientOrderID == id).ToList();
                var eventDec = db.EventsDecorations.Where(i => i.ClientOrderID == id).ToList();


                var EventOtherSer = db.EventServicess.Where(i => i.ClientOrderID == id).ToList();


                cvm.ClientOrderID = clientOrderDetails.ClientOrderID;
                cvm.FirstName = clientOrderDetails.Name;
                cvm.CityName = clientOrderDetails.CityName;
                cvm.EventTypeName = clientOrderDetails.EventTypeName;
                cvm.EventSubTypeName = clientOrderDetails.EventSubTypeName;
                cvm.EventName = clientOrderDetails.EventName;
                cvm.EventStartDate = clientOrderDetails.EventStartDate;
                cvm.EventEndDate = clientOrderDetails.EventEndDate;
                cvm.NoOfGuest = clientOrderDetails.NoOfGuest;
                cvm.VenueName = clientOrderDetails.VenueName;
                cvm.SpecialInstruction = clientOrderDetails.SpecialInstruction;
                cvm.PgCategory = clientOrderDetails.Category;
                cvm.PgNumberOfTeam = clientOrderDetails.NumberOfTeam;
                cvm.PgPrice = clientOrderDetails.Price;

                if (eventCate != null)
                {
                    cvm.EventsCaterings = eventCate;
                }
                //if (eventDec != null)
                //{
                //    cvm.EventsDecorations = eventDec;
                //}
                //if (EventOtherSer != null)
                //{
                //    cvm.EventServicess = EventOtherSer;

                //}

                return View(cvm);
            };


        }

        public ActionResult DetailsForClient(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                ClientOrderViewModel cvm = new ClientOrderViewModel();


                var clientOrderDetails = (from co in db.ClientOrders
                                          join cl in db.Clients
                                          on co.ClientID equals cl.ClientID
                                          join ep in db.EventsPhotographies
                                          on co.ClientOrderID equals ep.ClientOrderID
                                          join city in db.Cities
                                          on co.CityID equals city.CityID
                                          join et in db.EventTypes
                                          on co.EventTypeID equals et.EventTypeID
                                          join est in db.EventSubTypes
                                          on co.EventSubTypeID equals est.EventSubTypeID
                                          join vn in db.Venues
                                          on co.VenueID equals vn.VenueID
                                          where co.ClientOrderID == id
                                          select new
                                          {
                                              co.ClientOrderID,
                                              cl.Name,
                                              city.CityName,
                                              et.EventTypeName,
                                              est.EventSubTypeName,
                                              co.EventName,
                                              co.EventStartDate,
                                              co.EventEndDate,
                                              co.NoOfGuest,
                                              vn.VenueName,
                                              co.SpecialInstruction,
                                              ep.EventsPhotographyID,
                                              ep.Category,
                                              ep.NumberOfTeam,
                                              ep.Price
                                          }).FirstOrDefault();

                var eventCate = db.EventsCaterings.Where(i => i.ClientOrderID == id).ToList();
                var eventDec = db.EventsDecorations.Where(i => i.ClientOrderID == id).ToList();

                //var eventDec = (from ed in db.EventsDecorations
                //                join de in db.DecorationTypes
                //                on ed.DecorationTypeID equals de.DecorationTypeID
                //                join di in db.DecorationImages
                //                on ed.DecorationImageID equals di.DecorationImageID
                //                where ed.ClientOrderID == id
                //                select ed).ToList();
                var EventOtherSer = db.EventServicess.Where(i => i.ClientOrderID == id).ToList();

                
                cvm.ClientOrderID = clientOrderDetails.ClientOrderID;
                cvm.FirstName = clientOrderDetails.Name;
                cvm.CityName = clientOrderDetails.CityName;
                cvm.EventTypeName = clientOrderDetails.EventTypeName;
                cvm.EventSubTypeName = clientOrderDetails.EventSubTypeName;
                cvm.EventName = clientOrderDetails.EventName;
                cvm.EventStartDate = clientOrderDetails.EventStartDate;
                cvm.EventEndDate = clientOrderDetails.EventEndDate;
                cvm.NoOfGuest = clientOrderDetails.NoOfGuest;
                cvm.VenueName = clientOrderDetails.VenueName;
                cvm.SpecialInstruction = clientOrderDetails.SpecialInstruction;
                if (eventCate != null)
                {
                    cvm.EventsCaterings = eventCate;
                }
                if (eventDec != null)
                {
                    cvm.EventsDecorations = eventDec;
                }
                if (EventOtherSer != null)
                {
                    cvm.EventServicess = EventOtherSer;

                }

                return PartialView(cvm);
            };


        }


        public ActionResult Create()
        {
            ClientOrderViewModel comodel = new ClientOrderViewModel();

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Name");
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName");
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName");
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName");
            ViewBag.pgCategory = new SelectList("1", "1", "1");
            ViewBag.DecorationTypeID = new SelectList(db.DecorationTypes, "DecorationTypeID", "Name");
            ViewBag.DecorationImageID = new SelectList(db.DecorationImages, "DecorationImageID", "Image");
            return View(comodel);
        }

        [HttpPost]
        public JsonResult Create(ClientOrderViewModel vm)
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "Name");
            ViewBag.EventSubTypeID = new SelectList(db.EventSubTypes, "EventSubTypeID", "EventSubTypeName");
            ViewBag.EventTypeID = new SelectList(db.EventTypes, "EventTypeID", "EventTypeName");
            ViewBag.VenueID = new SelectList(db.Venues, "VenueID", "VenueName");
            ViewBag.ServiceID = new SelectList(db.Services, "ServiceID", "ServiceName");
            ViewBag.ServiceProviderID = new SelectList(db.ServiceProviders, "ServiceProviderID", "ServiceProviderName");


            bool status = false;

            if (ModelState.IsValid)
            {
                EventServices evs = new EventServices();



                ClientOrder co = new ClientOrder();
                co.ClientID = vm.ClientID;
                co.CityID = vm.CityID;
                co.EventTypeID = vm.EventTypeID;
                co.EventSubTypeID = vm.EventSubTypeID;
                co.EventName = vm.EventName;
                co.EventStartDate = vm.EventStartDate;
                co.EventEndDate = vm.EventEndDate;
                co.NoOfGuest = vm.NoOfGuest;
                if (vm.VenueID != 0)
                {
                    co.VenueID = Convert.ToInt32(vm.VenueID);
                }
                co.SpecialInstruction = vm.SpecialInstruction;
                co.Date = DateTime.Now.Date;
                db.ClientOrders.Add(co);
                db.SaveChanges();

                int latestCoId = co.ClientOrderID;

                if (vm.VenueID != 0)
                {
                    evs.ClientOrderID = latestCoId;
                    evs.ServiceID = 9;
                    evs.Price = Convert.ToDouble(db.Venues.Where(e => e.VenueID == vm.VenueID).Select(rent => rent.Rent).FirstOrDefault());
                    db.EventServicess.Add(evs);
                    db.SaveChanges();
                }


                EventSchedule es = new EventSchedule();
                es.EventName = vm.EventName;
                es.EventStartDate = vm.EventStartDate;
                es.EventEndDate = vm.EventEndDate;
                es.VenueID = Convert.ToInt32(vm.VenueID);
                db.EventSchedules.Add(es);
                db.SaveChanges();


                if (vm.PgCategory != null)
                {
                    EventsPhotography ep = new EventsPhotography();
                    ep.Category = Convert.ToInt32(vm.PgCategory);
                    ep.NumberOfTeam = Convert.ToInt32(vm.PgNumberOfTeam);
                    ep.Price = Convert.ToDouble(vm.PgPrice);
                    ep.ClientOrderID = latestCoId;
                    db.EventsPhotographies.Add(ep);
                    db.SaveChanges();


                    evs.ClientOrderID = latestCoId;
                    evs.ServiceID = 7;
                    evs.Price = Convert.ToDouble(vm.PgPrice);
                    db.EventServicess.Add(evs);
                    db.SaveChanges();
                }


                if (vm.EventsDecorations != null)
                {
                    foreach (var item in vm.EventsDecorations)
                    {
                        EventsDecoration evDec = new EventsDecoration();
                        evDec.ClientOrderID = latestCoId;
                        evDec.DecorationTypeID = item.DecorationTypeID;
                        if (item.DecorationImageID != null)
                        {
                            evDec.DecorationImageID = item.DecorationImageID;
                        }
                        if (item.CustomImage != null)
                        {
                            evDec.CustomImage = item.CustomImage;
                        }
                        evDec.Price = item.Price;
                        db.EventsDecorations.Add(evDec);
                    }

                    evs.ClientOrderID = latestCoId;
                    evs.ServiceID = 6;
                    evs.Price = Convert.ToDouble(vm.TotalDecCost);
                    db.SaveChanges();
                }


                if (vm.EventsCaterings != null)
                {
                    foreach (var item in vm.EventsCaterings)
                    {
                        EventsCatering ecate = new EventsCatering();
                        ecate.ClientOrderID = latestCoId;
                        ecate.MealType = item.MealType;
                        ecate.FoodItems = item.FoodItems;
                        ecate.PerPersonCost = item.PerPersonCost;
                        ecate.TotalCost = item.PerPersonCost * vm.NoOfGuest;
                        db.EventsCaterings.Add(ecate);
                    }
                    evs.ClientOrderID = latestCoId;
                    evs.ServiceID = 5;
                    evs.Price = Convert.ToDouble(vm.TotalCateCost* vm.NoOfGuest);
                    db.SaveChanges();
                }

                if (vm.EventServicess != null)
                {
                    foreach (var i in vm.EventServicess)
                    {
                        EventServices eser = new EventServices();
                        eser.ClientOrderID = latestCoId;
                        eser.ServiceID = i.ServiceID;
                        eser.Price = i.Price;
                        db.EventServicess.Add(eser);
                    }
                    db.SaveChanges();
                }


                var subTotal = db.EventServicess.Where(e => e.ClientOrderID == latestCoId).Sum(s => s.Price);

                if (subTotal != 0)
                {
                    EventBill ebill = new EventBill();

                    ebill.ClientOrderID = latestCoId;
                    ebill.SubTotalAmount = Convert.ToDouble(subTotal);
                    ebill.MadeBy = User.Identity.GetUserName();
                    ebill.vat = vm.Vat;
                    ebill.Discount = Convert.ToInt32(vm.Discount);
                    db.EventBills.Add(ebill);
                    db.SaveChanges();

                    EventPayment epay = new EventPayment();
                    epay.ClientOrderID = latestCoId;
                    epay.Total = vm.NetTotal;
                    epay.PaidAmount = 0;
                    db.EventPayments.Add(epay);
                    db.SaveChanges();
                }

                status = true;
            }
            else
            {
                status = false;
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            return Json(status, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetVenueCost(int Venueid)
        {
            var venueRent = db.Venues.FirstOrDefault(v => v.VenueID == Venueid).Rent;

            return Json(venueRent, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFoodItem(string meal)
        {
            var fooditems = db.FoodItems.Where(m => m.MealType == meal).Select(mt => new { mealName = mt.Name, cost = mt.Cost, foodid = mt.FoodItemID }).ToList();
            return Json(fooditems, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEventSubType(int EventTypeId)
        {
            var subTypeList = db.EventSubTypes.Where(st => st.EventTypeID == EventTypeId).Select(x => new { EventSubTypeId = x.EventSubTypeID, EventSubTypeName = x.EventSubTypeName }).ToList();

            return Json(subTypeList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CityVenue(int CityId)
        {
            var cityvenueList = db.Venues.Where(cv => cv.CityID == CityId).Select(c => new { VenueId = c.VenueID, VenueName = c.VenueName }).ToList();

            return Json(cityvenueList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVenueWithNoOfGuest(int numberOfGuest)
        {
            var venueList = db.Venues.Where(nv => nv.SeatCapacity >= numberOfGuest).Select(x => new { VId = x.VenueID, VName = x.VenueName }).ToList();

            return Json(venueList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEventDec(int COID)
        {
            var eventDec = (from ed in db.EventsDecorations
                            join de in db.DecorationTypes
                            on ed.DecorationTypeID equals de.DecorationTypeID
                            join di in db.DecorationImages
                            on ed.DecorationImageID equals di.DecorationImageID
                            where ed.ClientOrderID == COID
                            select new { DecType = de.Name, DecImg = di.Image,CustomImage=ed.CustomImage, Price = ed.Price }).ToList();
            return Json(eventDec, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOtherService(int COID)
        {
            var otherSer = (from es in db.EventServicess
                            join ss in db.Services
                            on es.ServiceID equals ss.ServiceID
                            where es.ClientOrderID == COID
                            select new { ServiceID = es.ServiceID, ServiceName = ss.ServiceName, Price = es.Price }).ToList();
            return Json(otherSer, JsonRequestBehavior.AllowGet);
        }

    }
}