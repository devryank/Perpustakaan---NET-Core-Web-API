using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }

        public IEnumerable<Member> GetMembers(PaginationParameters paginationParameters)
        {
            return FindAll()
                .ToList();
        }

        public Member GetMemberById(Guid id)
        {
            return FindByCondition(member => member.Id.Equals(id)).FirstOrDefault();
        }

        public void CreateMember(Member member) => Create(member);
        public void UpdateMember(Member member) => Update(member);
        public void DeleteMember(Member member) => Delete(member);
    }
}
