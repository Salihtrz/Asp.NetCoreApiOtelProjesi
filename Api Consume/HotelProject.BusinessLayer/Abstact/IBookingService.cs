﻿using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstact
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(Booking booking);
        int TGetBookingCount();
        List<Booking> TLast6Bookings();
        void TBookingStatusChangeApproved3(int id);
        void TBookingStatusChangeCancel(int id);
        void TBookingStatusChangeWait(int id);
    }
}
