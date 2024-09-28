using System;

namespace Hunter.BookStore.Authors
{
    public class CreateUpdateAuthorDto
    {
        public string Name { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public string ShortBio { get; set; }
    }
}