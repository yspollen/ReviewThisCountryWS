using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReviewThisCountryWS.Models
{
    public class CommentDto
    {
        [Required]
        public required String Username { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
        public int CountryId { get; set; }
    }
}