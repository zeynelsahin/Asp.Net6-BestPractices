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

    public ContactController(IConfiguration configuration,IContactService contactService)
    {
        _configuration = configuration;
        _contactService = contactService;
    }

    [HttpGet]
    public string Get()
    {
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