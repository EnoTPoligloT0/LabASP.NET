namespace LabProject.Models.Services;

public interface IContactService
{
    void Add(ContactModel contact);
    void Update(ContactModel conatact);
    void Delete(int id);
    List<ContactModel> GetAll();
    ContactModel? GetById(int id);
    List<OrganizationEntity> GetAllOrganizations();
}