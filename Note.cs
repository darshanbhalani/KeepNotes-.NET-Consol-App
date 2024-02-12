namespace KeepNotes
{
    internal class Note
    {
        public string noteId { get; set; }
        public DateTime createAt { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime updateAt { get; set; }
    }
}
