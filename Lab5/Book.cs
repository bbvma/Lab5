using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genres { get; set; }
        public string PublicationDate { get; set; }
        public string Annotation { get; set; }
        [Key]
        public string ISBN { get; set; }
    }
}