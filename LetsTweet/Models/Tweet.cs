﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTweet.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
