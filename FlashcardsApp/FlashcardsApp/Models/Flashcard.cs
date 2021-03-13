using System;
using System.Collections.Generic;
using System.Text;

namespace FlashcardsApp.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}
