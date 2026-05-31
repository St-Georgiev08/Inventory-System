using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Data.DTOs
{
    public class AuditsLogDto
    {
        public int Id { get; set; }
        public string UsersName { get; set; }
        public string Action {  get; set; }
        public DateTime Time {  get; set; }
        public string? Description { get; set; }
    }
}
