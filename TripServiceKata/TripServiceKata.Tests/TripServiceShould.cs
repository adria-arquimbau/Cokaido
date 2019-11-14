using System.Collections;
using System.Collections.Generic;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void PrintErrorMessageWhenUserIsNotLogged()
        {
            var tripService = new TripServiceTesteable(null);
            var user = new User.User();

            Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(user));
        }

        [Fact]
        public void NotReturnTripsWhenUserIsNotFriendFromLoggedUser()
        {
            var user = new User.User();
            var tripService = new TripServiceTesteable(user);

            var trips = tripService.GetTripsByUser(user);

            Assert.Empty(trips);
        }

        [Fact]
        public void NotReturnTripsWhenUserHasFriendsButNotTheLoggedUser()
        {
            var userLogged = new User.User();
            var tripService = new TripServiceTesteable(userLogged);

            var user = new User.User();
            user.AddFriend(new User.User());

            var trips = tripService.GetTripsByUser(user);
            
            Assert.Empty(trips);
        }

        [Fact]
        public void NotReturnTripsWhenUserAndUserLoggedAreFriendsAndUserHasNotTrips()
        {
            var userLogged = new User.User();
            var tripService = new TripServiceTesteable(userLogged);

            var user = new User.User();
            user.AddFriend(userLogged);

            var trips = tripService.GetTripsByUser(user);

            Assert.Empty(trips);
        }

        [Fact]
        public void ReturnATripWhenUserAndUserLoggedAreFriendsAndUserHasOneTrip()
        {
            var userLogged = new User.User();
            var tripService = new TripServiceTesteable(userLogged);

            var user = new User.User();
            user.AddFriend(userLogged);

            user.AddTrip(new Trip.Trip());
            var trips = tripService.GetTripsByUser(user);

            Assert.NotEmpty(trips);
        }
    }

    public class TripServiceTesteable : TripService
    {
        private readonly User.User _userLogged;

        public TripServiceTesteable(User.User userLogged)
        {
            _userLogged = userLogged;
        }

        protected override User.User GetLoggedUser()
        {
            return _userLogged;
        }

        protected override List<Trip.Trip> FindTripsByUser(User.User user)
        {
            return user.Trips();
        }
    }
}
