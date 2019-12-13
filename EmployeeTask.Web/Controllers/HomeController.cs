using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeTask.Web.Models;
using EmployeeTask.DomainModels;
using System.Net.Http;

namespace EmployeeTask.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string baseUrl = "https://localhost:44361/api/v1/";
            List<Employee> employees = new List<Employee>(); 
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    HttpResponseMessage msg = await client.GetAsync("employees");
                    msg.EnsureSuccessStatusCode();
                    employees = await msg.Content.ReadAsAsync<List<Employee>>();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = "Error fetching employee records";
            }
            return View(employees);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
