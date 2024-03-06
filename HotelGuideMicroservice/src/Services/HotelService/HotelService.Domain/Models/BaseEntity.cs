using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public int UUID { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime? UpdatedDate { get; set; }
    }
}
