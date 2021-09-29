using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsTweet.Models;

namespace LetsTweet.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Tweet> Tweets { get; set; }
        public Tweet Tweet { get; set; }
        public string Search { get; set; }
    }
}
