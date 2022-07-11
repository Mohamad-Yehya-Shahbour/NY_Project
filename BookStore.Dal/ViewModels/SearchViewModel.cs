using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dal.ViewModels
{
    public class SearchViewModel
    {
        public string ISBN { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime? Date { get; set; }

        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
    }
}
