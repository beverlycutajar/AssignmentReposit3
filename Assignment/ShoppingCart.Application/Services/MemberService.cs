using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
   public class MemberService:IMemberService
    {
        private IMembersRepository _membersRepository;

        public MemberService(IMembersRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }

        public void AddMember(MemberViewModel m)
        {
            Member member = new Member()
            {
                email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName
            };
            _membersRepository.AddMember(member);
        }

    }
}
