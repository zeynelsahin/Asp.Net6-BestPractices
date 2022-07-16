using AutoMapper;
using BestPractices.Api.Data.Models;
using BestPractices.Api.Models;

namespace BestPractices.Api.Service;

public class ContactService: IContactService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private IMapper Mapper { get; }

    public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory )
    {
        _httpClientFactory = httpClientFactory;
        Mapper = mapper;
    }
    public ContactDVO GetContactById(int id)
    {
        //data serviceden veri getirilmesi
        var dbContact = getContact();
        // var resultContact = new ContactDVO();
        // Mapper.Map(dbContact, resultContact);
        var client = _httpClientFactory.CreateClient("api");
       
        var resultContact = Mapper.Map<ContactDVO>(dbContact);
        return resultContact;
    }

    private Contact getContact()
    {
        return new Contact() { Id = 1, FirstName = "Zeynel", LastName = "Şahin" };
    }
}