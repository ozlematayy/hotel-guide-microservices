using HotelService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.Repository
{
    public interface IContactRepository:IGenericRepository<ContactModel>
    {
        Task<List<ContactModel>> GetContactInformationByHotelIdAsync(int hotelId);
        Task<List<string>> GetDistinctLocationsAsync();
        Task<List<int>> GetHotelIdsByLocationAsync(string location);
        Task<int> GetPhoneNumberCountByLocationAsync(string location);



    }

}
