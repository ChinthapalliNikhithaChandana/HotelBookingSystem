using HotelAvailabilityService;
using HotelAvailabilityService.Models;
using HotelAvailabilityService.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAvailabilityServiceTest
{
    public class Tests
    {
        List<Availablehotels> availableHotels = new List<Availablehotels>();
        IQueryable<Availablehotels> hoteldata;
        Mock<DbSet<Availablehotels>> mockSet;
        Mock<AvailabilityDbContext> hotelcontextmock;
        [SetUp]
        public void Setup()
        {
            availableHotels = new List<Availablehotels>()
            {
                new Availablehotels{Id = 1, Name="novotel", AvailableRooms=17,CostPerDay=200},
                new Availablehotels{Id = 2, Name="park", AvailableRooms=100,CostPerDay=300},
                new Availablehotels{Id = 3, Name="dolphin", AvailableRooms=9,CostPerDay=2000},
                new Availablehotels{Id = 4, Name="lemon tree", AvailableRooms=25,CostPerDay=4000}

            };
            hoteldata = availableHotels.AsQueryable();
            mockSet = new Mock<DbSet<Availablehotels>>();
            mockSet.As<IQueryable<Availablehotels>>().Setup(m => m.Provider).Returns(hoteldata.Provider);
            mockSet.As<IQueryable<Availablehotels>>().Setup(m => m.Expression).Returns(hoteldata.Expression);
            mockSet.As<IQueryable<Availablehotels>>().Setup(m => m.ElementType).Returns(hoteldata.ElementType);
            mockSet.As<IQueryable<Availablehotels>>().Setup(m => m.GetEnumerator()).Returns(hoteldata.GetEnumerator());
            var p = new DbContextOptions<AvailabilityDbContext>();
            hotelcontextmock = new Mock<AvailabilityDbContext>(p);
            hotelcontextmock.Setup(x => x.Hotels).Returns(mockSet.Object);

        }
        [Test]
        public void GetAllTest()
        {
            var hotelrepo = new AvailabilityRepository(hotelcontextmock.Object);
            var hotellist = hotelrepo.GetAll();
            Assert.IsNotNull(hotellist);

        }
        [Test]
        public void GetByIdTest()
        {
            var hotelrepo = new AvailabilityRepository(hotelcontextmock.Object);
            var hotelobj = hotelrepo.GetById(2);
            Assert.AreNotEqual(2,hotelobj.Id);
        }
        [Test]
        public void GetByIdTestFail()
        {
            var hotelrepo = new AvailabilityRepository(hotelcontextmock.Object);
            var hotelobj = hotelrepo.GetById(55);
            Assert.AreNotEqual(55,hotelobj.Id);
        }
        [Test]
        public  void ReduceById()
        {
            var hotelrepo = new AvailabilityRepository(hotelcontextmock.Object);
            var hotelobj =  hotelrepo.Reduce(1);
             Assert.AreEqual(true,hotelobj.GetAwaiter().GetResult() );
           
        }
        [Test]
        public void ReduceByIdFail()
        {
            var hotelrepo = new AvailabilityRepository(hotelcontextmock.Object);
            var hotelobj = hotelrepo.Reduce(10);
            Assert.AreEqual(false, hotelobj.GetAwaiter().GetResult());
        }

    }
}