using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers(PaginationParameters paginationParameters);
        Member GetMemberById(Guid id);
        void CreateMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
    }
}
