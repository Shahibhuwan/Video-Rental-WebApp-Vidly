using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dddd, MMMM, d, yyyy}", ApplyFormatInEditMode = true)]

        [Required]
        public DateTime ReleaseDate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dddd/MMMM/d/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        [Range(1,20)]
        public int StockNumber { get; set; }

    }
}