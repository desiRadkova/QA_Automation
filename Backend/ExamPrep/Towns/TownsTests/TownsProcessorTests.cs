﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towns;

namespace TownsTests
{
    public class TownsProcessorTests
    {
        [Test]
        public void Test_ExecuteCommand_InvalidOperation()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var actual = townProcessor.ExecuteCommand("Alabala");

            //Assert
            Assert.That(actual, Is.EqualTo("Invalid command: Alabala"));
        }

        [Test]
        public void Test_ExecuteCommand_CREATE()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            var actual = townProcessor.ExecuteCommand(createCommand);

            //Assert
            Assert.That(actual, Is.EqualTo("Successfully created collection of towns."));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_ExecuteCommand_PRINT()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var printCommnad = "PRINT";

            var actual = townProcessor.ExecuteCommand(printCommnad);

            //Assert
            Assert.That(actual, Is.EqualTo("Towns: Paris, London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_ExecuteCommand_ADD()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommnad = "ADD Sofia";

            var actual = townProcessor.ExecuteCommand(addCommnad);

            //Assert
            Assert.That(actual, Is.EqualTo("Successfully added: Sofia"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(3));
        }

        [Test]
        public void Test_ExecuteCommand_TryADDExisting()
        {
            // Arrange
            var townProcessor = new TownsProcessor();

            // Act
            var createCommand = "CREATE Paris, London";
            townProcessor.ExecuteCommand(createCommand);

            var addCommnad = "ADD London";

            var actual = townProcessor.ExecuteCommand(addCommnad);

            //Assert
            Assert.That(actual, Is.EqualTo("Cannot add: London"));
            Assert.That(townProcessor.Towns.Count, Is.EqualTo(2));
        }
    }
}
