using BestPractices.Api.Models;
using BestPractices.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace BestPractices.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ContactController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IContactService _contactService;
    private readonly ILogger<ContactController> _logger;
    public ContactController(IConfiguration configuration,IContactService contactService, ILogger<ContactController> logger)
    {
        _configuration = configuration;
        _contactService = contactService;
        _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
        _logger.LogTrace("LogTrace ->Get Method is called");
        _logger.LogDebug("LogDebug->Get Get Method is called");
        _logger.LogInformation("LogInformation ->Get Get Method is called");
        _logger.LogWarning("LogWarning ->Get Get Method is called");
        _logger.LogError("LogError ->Get Get Method is called");
        
        return _configuration["ReadMe"].ToString();
    }
    
    [ResponseCache(Duration = 10)]
    [HttpGet("{id:int}")]
    public ContactDVO GetContactById(int id)
    {
        return _contactService.GetContactById(id);
    }
    [HttpPost]
    public ContactDVO CreateContact(ContactDVO contact)
    {
        // kayıt yapılabilir
        return contact;
     }
}