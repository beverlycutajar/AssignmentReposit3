using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IMemberService
    {
        public void AddMember(MemberViewModel m);
    }
}
