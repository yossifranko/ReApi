using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReApi.Models
{
    public class Bookmark
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string avatarUrl { get; set; }

        public string Url { get; set; }

    }
}
