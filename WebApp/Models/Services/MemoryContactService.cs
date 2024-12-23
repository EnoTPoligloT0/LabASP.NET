// using Microsoft.EntityFrameworkCore;
//
// namespace LabProject.Models.Services
// {
//     public class DatabaseContactService : IContactService
//     {
//         private readonly AppDbContext _context;
//
//         public DatabaseContactService(AppDbContext context)
//         {
//             _context = context;
//         }
//
//         public void Add(ContactModel contact)
//         {
//             var entity = ContactMapper.ToEntity(contact);
//             _context.Contacts.Add(entity);
//             _context.SaveChanges();
//         }
//
//         public void Update(ContactModel contact)
//         {
//             var entity = ContactMapper.ToEntity(contact);
//             _context.Contacts.Update(entity);
//             _context.SaveChanges();
//         }
//
//         public void Delete(int id)
//         {
//             var contact = _context.Contacts.Find(id);
//             if (contact != null)
//             {
//                 _context.Contacts.Remove(contact);
//                 _context.SaveChanges();
//             }
//         }
//
//         public List<ContactModel> GetAll()
//         {
//             return _context.Contacts
//                 .Include(c => c.Organization)
//                 .Select(ContactMapper.FromEntity)
//                 .ToList();
//         }
//
//         public ContactModel GetById(int id)
//         {
//             var contact = _context.Contacts
//                 .Include(c => c.Organization)
//                 .FirstOrDefault(c => c.Id == id);
//
//             return contact != null ? ContactMapper.FromEntity(contact) : null;
//         }
//
//         public List<OrganizationEntity> GetAllOrganizations()
//         {
//             return _context.Organizations.ToList();
//         }
//     }
// }