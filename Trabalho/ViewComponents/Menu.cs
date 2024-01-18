using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trabalho.Models;

namespace Trabalho.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");

            string sessaousuario = HttpContext.Session.GetString("sessaousuariologado");

            if ((string.IsNullOrEmpty(sessaoadm)) && (string.IsNullOrEmpty(sessaousuario)))
            {
                // Return an empty result or any other appropriate result
                return Content(""); // You can customize this based on your needs
            }

    

            return View();
        }
    }
}
