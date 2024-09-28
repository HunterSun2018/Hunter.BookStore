using System;

namespace Hunter.BookStore.Books
{
    public class CreateUpdateBookDto
    {
        public Guid AuthorId { get; set; }

        public string Name { get; set; } = String.Empty;

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public float Price { get; set; }

        public string[] CategoryNames { get; set; }
    }
}