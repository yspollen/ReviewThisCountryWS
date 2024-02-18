using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReviewThisCountryWS.Models
{
    [Table("Comments", Schema = "CommentSchema")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required String Username { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
        public int CountryId { get; set; }
    }
}