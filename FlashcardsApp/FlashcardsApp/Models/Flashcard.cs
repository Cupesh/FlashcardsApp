namespace FlashcardsApp.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public int BlockPartId { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}
