using Microsoft.AspNetCore.Mvc;
using ReviewThisCountryWS.Models;
using ReviewThisCountryWS.Data;
using Microsoft.EntityFrameworkCore;

namespace ReviewThisCountryWS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ILogger<CommentsController> _logger;
    private readonly DBContext _context;

    public CommentsController(DBContext context, ILogger<CommentsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet(Name = "GetComments")]
    public async Task<ActionResult<IEnumerable<Comment>>> Get()
    {
        return await _context.Comments.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] CommentDto commentDto)
    {
        var comment = new Comment
        {
            Username = commentDto.Username,
            Text = commentDto.Text,
            Rating = commentDto.Rating,
            CountryId = commentDto.CountryId
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        var country = await _context.Countries
            .FirstOrDefaultAsync(c => c.Id == commentDto.CountryId);

        if (country != null)
        {
            switch (comment.Rating)
            {
                case 1:
                    country.OneStarCount += 1;
                    break;
                case 2:
                    country.TwoStarsCount += 1;
                    break;
                case 3:
                    country.ThreeStarsCount += 1;
                    break;
                case 4:
                    country.FourStarsCount += 1;
                    break;
                case 5:
                    country.FiveStarsCount += 1;
                    break;
                default:
                    break;
            }

            Decimal totalScore = (country.OneStarCount
                + 2 * country.TwoStarsCount
                + 3 * country.ThreeStarsCount
                + 4 * country.FourStarsCount
                + 5 * country.FiveStarsCount
                );

            country.AverageRating = totalScore / (country.OneStarCount
                + country.TwoStarsCount
                + country.ThreeStarsCount
                + country.FourStarsCount
                + country.FiveStarsCount);

            await _context.SaveChangesAsync();
        }

        return CreatedAtAction(nameof(Get), new { id = comment.Id }, comment);
    }
}