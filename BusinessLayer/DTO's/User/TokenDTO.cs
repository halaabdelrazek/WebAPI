using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO_s.User
{
    public class TokenDTO
    {
        public string Token { get; init; }
        public DateTime ExpiryDate { get; set; }
    }
}
