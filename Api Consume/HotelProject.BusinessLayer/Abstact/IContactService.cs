﻿using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstact
{
    public interface IContactService : IGenericService<Contact>
    {
        public int TGetContactCount();
    }
}
