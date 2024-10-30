namespace LabProject.Models.Services;

public class MemoryContactService : IContactService
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1, new ContactModel()
            {
                Category = Category.Business,
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john@gmail.com",
                PhoneNumber = "888888888",
                BirthDate = new(1984, 10, 26)
            }
        },
        {
            2, new ContactModel()
            {
                Category = Category.Friend,
                Id = 2,
                FirstName = "Ela",
                LastName = "McDonald",
                Email = "ela@gmail.com",
                PhoneNumber = "777222444",
                BirthDate = new(1986, 9, 26)
            }
        },
        {
            3, new ContactModel()
            {
                Category = Category.Family,
                Id = 3,
                FirstName = "Paul",
                LastName = "Kings",
                Email = "paul@gmail.com",
                PhoneNumber = "856312534",
                BirthDate = new(1999, 5, 26)
            }
        }
    };

    private static int _currentId = 3;

    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel GetById(int id)
    {
        return _contacts[id];
    }
}