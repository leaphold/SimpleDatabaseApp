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
        var expectedUser = new User(2, "Anna");

        var mockDatabase = new Mock<IDatabase>();
        mockDatabase.Setup(service => service.GetUser(2)).Returns(expectedUser);

        var userManager = new UserManager(mockDatabase.Object);

        // Act
        var actualUser = userManager.GetUser(2);

        // Assert
        Assert.That(actualUser, Is.EqualTo(expectedUser));
    }

/*     [Test]
    public void GetUser_ReturnsCorrectUser2()
    {
        // Arrange
        var expectedUser1 = new User(1, "John");
        var expectedUser2 = new User(2, "Anna");

        var mockDatabase = new Mock<IDatabase>();
        mockDatabase.Setup(service => service.GetUser(1)).Returns(expectedUser1);
        mockDatabase.Setup(service => service.GetUser(2)).Returns(expectedUser2);

        var userManager = new UserManager(mockDatabase.Object);

        // Act
        var actualUser = userManager.GetUser(3);

        // Assert
        Assert.That(actualUser, Is.EqualTo(expectedUser2));
    } */

}