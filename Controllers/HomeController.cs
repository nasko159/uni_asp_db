using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using contacts.Models;

namespace contacts.Controllers
{
    public class HomeController : Controller
    {
        private IContactsRepository contactsRepository;

        public HomeController(IContactsRepository contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        public IActionResult Index()
        {
            return View(contactsRepository.Contacts);
        }

        public IActionResult Show(int id)
        {
            return View(contactsRepository.findById(id));
        }

        [HttpGet]
        public IActionResult New() {
            return View();
        }

        [HttpPost]
        public IActionResult New(Contact contact) {
            int id = contactsRepository.add(contact);

            return RedirectToAction("Show", new {id = id});
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            return View(contactsRepository.findById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, Contact contact) {
            contactsRepository.save(id, contact);

            return RedirectToAction("Show", new {id = id});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
