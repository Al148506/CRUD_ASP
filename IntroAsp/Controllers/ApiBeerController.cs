using IntroAsp.Models;
using IntroAsp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {
        private readonly PubContext _context;
        public ApiBeerController(PubContext context)
        {
            _context = context;
        }


    }


}
