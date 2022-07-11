using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Dal.ViewModels
{
    public class AddBookViewModel
    {
        [MinLength(13,ErrorMessage ="ISBN should be 13 digits"),
         Required(ErrorMessage = "The ISBN is required"),
         MaxLength(13,ErrorMessage = "ISBN should be 13 digits")]
        public string ISBN { get; set; } 
        [Required(ErrorMessage = "The Name is required"), MaxLength(15, ErrorMessage = "A book Name cannot exceed 15 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The author is required"), MaxLength(20, ErrorMessage = "A book author cannot exceed 20 characters")]
        public string Author { get; set; }

        [DataType(DataType.Date), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Enter a price"), Range(1, 1000, ErrorMessage = "Min price: 1, max price: 1000")]
        public int Price { get; set; }
    }
}
