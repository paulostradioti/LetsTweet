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
            if (!string.IsNullOrWhiteSpace(viewModel.Search))
            {
                viewModel.Tweets = _context.Tweets.Where(x => x.Text.Contains(viewModel.Search));
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult SaveTweet(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                _context.Tweets.Add(tweet);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
