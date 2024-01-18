using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trabalho.Models;

namespace Trabalho.ViewComponents
{
    public class ViewAdmLogado : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoadm = HttpContext.Session.GetString("sessaoadmlogado");

            if (string.IsNullOrEmpty(sessaoadm))
            {
                // Return an empty result or any other appropriate result
                return Content(""); // You can customize this based on your needs
            }

            Adm adm = JsonConvert.DeserializeObject<Adm>(sessaoadm);

            return View(adm);
        }
    }
}
