using FlashcardsApp.Models;
using FlashcardsApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashcardsApp.ViewModels
{
    public class FlashcardsViewModel : ViewModel
    {
        public BlockPart BlockPart { get; set; }

        public void Initialize(BlockPart blockPart)
        {
            BlockPart = blockPart;
        }
    }
}
