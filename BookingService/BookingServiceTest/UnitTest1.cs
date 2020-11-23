using BookingService;
using BookingService.Models;
using BookingService.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingServiceTest
{
    public class Tests
    {
        List<Booking> books = new List<Booking>();
        IQueryable<Booking> bookingdata;
        Mock<DbSet<Booking>> mockSet;
        Mock<BookingsDbContext> bookcontextmock;
        [SetUp]
        public void Setup()
        {
            books = new List<Booking>()
            {
                new Booking{BookingId = 1, HotelId=1,UserId=1,StartDate=Convert.ToDateTime("10/12/2020 00:00:00 AM"), EndDate = Convert.ToDateTime("11/12/2020  00:00:00 AM/"),BillAmount=6000.00},
                 new Booking{BookingId = 2, HotelId=1,UserId=1,StartDate=Convert.ToDateTime("11/12/2020 00:00:00 AM"), EndDate = Convert.ToDateTime("12/12/2020  00:00:00 AM/"),BillAmount=6000.00}

            };
            bookingdata = books.AsQueryable();
            mockSet = new Mock<DbSet<Booking>>();
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Provider).Returns(bookingdata.Provider);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.Expression).Returns(bookingdata.Expression);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.ElementType).Returns(bookingdata.ElementType);
            mockSet.As<IQueryable<Booking>>().Setup(m => m.GetEnumerator()).Returns(bookingdata.GetEnumerator());
            var p = new DbContextOptions<BookingsDbContext>();
            bookcontextmock = new Mock<BookingsDbContext>(p);
            bookcontextmock.Setup(x => x.Bookings).Returns(mockSet.Object);



        }


        [Test]
        public void GetAllBookingsByUserIdTest()
        {
            var bookingrepo = new BookingRepository(bookcontextmock.Object);
            var bookinglist = bookingrepo.GetByUserId(1);
            Assert.AreEqual(1, bookinglist);




        }
        [Test]
        public void AddBookingDetailTest()
        {
            var bookingrepo = new BookingRepository(bookcontextmock.Object);
            var bookingobj = bookingrepo.AddBooking(new Booking { BookingId = 3, HotelId = 1, UserId = 1, StartDate =Convert.ToDateTime("10/11/2020 00:00:00 AM"), EndDate = Convert.ToDateTime("11/11/2020  00:00:00 AM/"), BillAmount = 6000.00 });;
            Assert.IsNotNull(bookingobj);
        }
    }
}