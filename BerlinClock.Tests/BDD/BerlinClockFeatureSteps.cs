﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BerlinClock.Tests.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private ITimeRepresentationConverter berlinClock = new TimeRepresentationConverter();
        private String theTime;

        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }

        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(berlinClock.ConvertTimeRepresentation(theTime), theExpectedBerlinClockOutput);
        }
    }
}
