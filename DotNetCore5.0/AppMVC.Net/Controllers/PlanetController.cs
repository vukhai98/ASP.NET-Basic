﻿using AppMVC.Net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Net.Controllers
{
    [Route("he-mat-troi/[action]")]
    public class PlanetController : Controller
    {
        public readonly PlantService _planetService;
        public readonly ILogger<PlanetController> _logger;
        public PlanetController(PlantService planetService,ILogger<PlanetController> logger)
        {
            _planetService = planetService;
            _logger = logger;        
        }

        [Route("/danh-sach-cac-hanh-tinh.html")]
        public IActionResult Index()
        {
            return View();
        }

        //route: action
        [BindProperty(SupportsGet = true, Name ="action")]
        public string Name { set; get; }

        public IActionResult Mercury() //he-mat-troi/Mercury
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail",planet);
        }

        public IActionResult Earth()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        [HttpGet("/saomoc.html")]
        public IActionResult Jupiter()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Mars()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        [Route("sao/[action]",Order =3,Name ="neptune3")] //sao/Neptune
        [Route("sao/[controller]/[action]", Order = 2, Name = "neptune2")] //sao/Planet/Neptune
        [Route("[controller]-[action].html", Order = 1, Name = "neptune1")] // /Planet-Neptune.html
        public IActionResult Neptune()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Saturn()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        public IActionResult Uranus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }

        public IActionResult Venus()
        {
            var planet = _planetService.Where(p => p.Name == Name).FirstOrDefault();
            return View("Detail", planet);
        }
        
        //controller, action , area => [controller] [action] [area]

        [Route("hantinh/{id:int}")] // /hanhtinh/1
        public IActionResult PlanetInfo( int id)
        {
            var planet = _planetService.Where(p => p.Id == id).FirstOrDefault();
            return View("Detail", planet);
        }









    }
}
