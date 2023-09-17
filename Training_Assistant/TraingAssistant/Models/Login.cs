using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraingAssistantDAL.Models
{
    public class Login
    {
        public record LoginRequest(string Login, string Password);
        public record LoginResponse(string Token);
    }
}
