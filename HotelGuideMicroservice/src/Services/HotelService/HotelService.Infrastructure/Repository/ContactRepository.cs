using HotelService.Domain.Models;
using HotelService.Domain.Repository;
using HotelService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Infrastructure.Repository
{
    public class ContactRepository : GenericRepository<ContactModel>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ContactModel>> GetContactInformationByHotelIdAsync(int hotelId)
        {
            return await _context.ContactModels
                .Where(contact => contact.HotelUUID == hotelId)
                .ToListAsync();
        }

        public async Task<List<string>> GetDistinctLocationsAsync()
        {
                return await _context.ContactModels
                        .Where(contact => contact.Type == InfoType.Location)
                      .Select(contact => contact.Content)
                      .Distinct()
                      .ToListAsync();
        }

        public async Task<List<int>> GetHotelIdsByLocationAsync(string location)
        {
            return await _context.ContactModels
                     .Where(contact => contact.Type == InfoType.Location && contact.Content == location)
                        .Select(contact => contact.HotelUUID)
                        .Distinct()
                        .ToListAsync();
        }

        public async Task<int> GetPhoneNumberCountByLocationAsync(string location)
        {
            return await _context.ContactModels
                  .Where(contact => contact.Type == InfoType.Phone && contact.Content == location)
                  .CountAsync();
        }
    }
}
