using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RandomPos;
namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    RandomPassword pos = new RandomPassword();
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        pos.Sla();
        
    }

    

    public void OnGet()
    {
        

    }
}
