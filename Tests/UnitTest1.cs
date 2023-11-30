using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learn_Tests.Tests;
public class Tests
{
    [Test]
    public void GetUser_ReturnsCorrectUser()
    {
        // Arrange
        var expectedUser = new User(1, "Anna");

        var mockDatabase = new Mock<IDatabase>();
        mockDatabase.Setup(service => service.GetUser(1)).Returns(expectedUser);

        var userManager = new UserManager(mockDatabase.Object);

        // Act
        var actualUser = userManager.GetUser(1);

        // Assert
        Assert.That(actualUser, Is.EqualTo(expectedUser));
    }


    [Test]
    public void AddUser_CreatesUserInDatabase()
    {
        // Arrange
        var newUser = new User(1, "John");

        var mockDatabase = new Mock<IDatabase>();
        mockDatabase.Setup(service => service.GetUser(1)).Returns((User)null); // Assume user doesn't exist initially

        var userManager = new UserManager(mockDatabase.Object);

        // Act
        userManager.AddUser(newUser);

        // Assert
        mockDatabase.Verify(service => service.AddUser(newUser), Times.Once);
    }


    [Test]
    public void RemoveUser_RemovesUserFromDatabase()
    {
        // Arrange
        var userIdToRemove = 1;

        var mockDatabase = new Mock<IDatabase>();
        var userToRemove = new User(userIdToRemove, "John");

        mockDatabase.Setup(service => service.GetUser(userIdToRemove)).Returns(userToRemove);

        var userManager = new UserManager(mockDatabase.Object);

        // Act
        userManager.RemoveUser(userIdToRemove);

        // Assert
        mockDatabase.Verify(service => service.RemoveUser(userIdToRemove), Times.Once);
    }


}