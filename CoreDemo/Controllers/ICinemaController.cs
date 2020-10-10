using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using CoreDemo.Models;
using CoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class ICinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        public ICinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院列表";
            return View(await _cinemaService.GetllAllSync());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院名称";
            return View(new Cinema());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cinema model)
        {
            if(ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }
            return RedirectToAction("Index");
        }

        
    }
}
