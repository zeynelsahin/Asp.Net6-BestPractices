using BestPractices.Api.Models;

namespace BestPractices.Api.Service;

public interface IContactService
{
    public ContactDVO GetContactById(int id);
}