using System;
using System.Collections.Generic;

namespace CoreService.Models
{
    public partial class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slag { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
