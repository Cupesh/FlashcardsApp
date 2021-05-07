using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashcardsAppDataManager.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public int BlockPartId { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}
