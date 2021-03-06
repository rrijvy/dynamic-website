﻿using System;

namespace Alphasoft.Models
{
    public class Blog : Base
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Creator { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
