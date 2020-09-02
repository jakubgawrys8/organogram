using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Organogram;

namespace OrganogramTests
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void Test_PrintStructure()
        {
            // Arrange
            var parent = new Person()
            {
                Id = 1,
                ParentId = 0,
                FirstName = "John",
                LastName = "Smith",
                Company = "Oracle",
                Position = "Senior developer",
                FirstNumber = 123,
                SecondNumber = 456,
                ThirdNumber = 789
            };

            var child = new Person()
            {
                Id = 2,
                ParentId = 1,
                FirstName = "Mary",
                LastName = "Smith",
                Company = "Oracle",
                Position = "Junior developer",
                FirstNumber = 123,
                SecondNumber = 456,
                ThirdNumber = 789

            };

            parent.Children.Add(child);

            // Act
            parent.PrintStructure("", true);
        }
    }
}
