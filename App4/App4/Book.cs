using System;
using System.Collections.Generic;
using System.Text;

namespace App4
{
    public class Book
    {
        public int Id { get; set; }

        public int JanrId { get; set; }

        public Janr Janr { get; set; }

        public string Name { get; set; }

        
    }
}
