using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Member
{
    public class MemberDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public string Phone { get; set; }
        public DateTime DateBirth { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
