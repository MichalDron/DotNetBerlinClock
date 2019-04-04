using System.Collections.Generic;
using BerlinClock.Models;
using NUnit.Framework;

namespace BerlinClock.Tests.Models
{
    public class TimeTests
    {
        [TestCaseSource(nameof(CorrectData))]
        public void GivenCorrectDateFormats_WhenTryParse_ReturnsCorrectTime(string timeInput, Time expectedTime)
        {
            // Act
            var successfullyParsedTime = Time.TryParse(timeInput, out var actual);

            // Assert
            Assert.IsTrue(successfullyParsedTime);
            Assert.AreEqual(expectedTime, actual);
        }

        private static IEnumerable<object[]> CorrectData()
        {
            yield return new object[] { "00:00:00", new Time { Hours = 0, Minutes = 0, Seconds = 0 } };
            yield return new object[] { "24:00:00", new Time { Hours = 24, Minutes = 0, Seconds = 0 } };
            yield return new object[] { "01:01:01", new Time { Hours = 1, Minutes = 1, Seconds = 1 } };
            yield return new object[] { "1:01:01", new Time { Hours = 1, Minutes = 1, Seconds = 1 } };
            yield return new object[] { "01:1:01", new Time { Hours = 1, Minutes = 1, Seconds = 1 } };
            yield return new object[] { "01:01:1", new Time { Hours = 1, Minutes = 1, Seconds = 1 } };
            yield return new object[] { "1:1:1", new Time { Hours = 1, Minutes = 1, Seconds = 1 } };
            yield return new object[] { "23:59:59", new Time { Hours = 23, Minutes = 59, Seconds = 59 } };
        }

        [TestCaseSource(nameof(IncorrectData))]
        public void GivenIncorrectDateFormats_WhenTryParse_ReturnsFalse(string timeInput)
        {
            // Arrange
            var expectedTime = new Time { Hours = 0, Minutes = 0, Seconds = 0 };

            // Act
            var successfullyParsedTime = Time.TryParse(timeInput, out var actual);

            // Assert
            Assert.IsFalse(successfullyParsedTime);
            Assert.AreEqual(expectedTime, actual);
        }

        private static IEnumerable<object[]> IncorrectData()
        {
            yield return new object[] { null };
            yield return new object[] { "" };
            yield return new object[] { " " };
            yield return new object[] { "a" };
            yield return new object[] { "0" };
            yield return new object[] { "01" };
            yield return new object[] { "01:01" };
            yield return new object[] { "01:01:001" };
            yield return new object[] { "01:001:01" };
            yield return new object[] { "001:01:01" };
            yield return new object[] { "24:01:01" };
            yield return new object[] { "24:00:01" };
            yield return new object[] { "25:00:00" };
            yield return new object[] { "00:60:00" };
            yield return new object[] { "00:00:60" };
        }
    }
}
