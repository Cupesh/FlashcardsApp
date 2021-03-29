using System;
using System.Collections.Generic;
using System.Text;

namespace FlashcardsApp.Models
{
    public class BlockPart
    {
        public int Id { get; set; }
        public int ModuleBlockId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
