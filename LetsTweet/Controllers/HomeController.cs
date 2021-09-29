using LetsTweet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LetsTweet.ViewModels;

namespace LetsTweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Tweets = _context.Tweets
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel viewModel)
        {
            //User meuusuario = Repository.GetUserById(viewModel.UserId);
            

            if (!string.IsNullOrWhiteSpace(viewModel.Search))
            {
                viewModel.Tweets = _context.Tweets.Where(x => x.Text.Contains(viewModel.Search));
            }
            else
            {
                viewModel.Tweets = _context.Tweets;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveTweet(IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Tweets.Add(viewModel.Tweet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.Tweets = _context.Tweets;
            return View("Index", viewModel);
        }
    }
}
