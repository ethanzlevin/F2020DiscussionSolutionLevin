using System;
using Xunit;
using F2020DiscussionAppLevin.Controllers;
using F2020DiscussionAppLevin.Data;

namespace F2020DiscussionTestLevin
{
    public class PetTest
    {
        [Fact]
        public void ShouldListAllPets()
        {
            //AA

            //1.Arrange
            ApplicationDbContext database = null;
            ////2. Act
            PetController petController = new PetController(database);
            petController.ListAllPets();
            //3.Assert

        }
    }
}
