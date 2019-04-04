﻿using System;
using System.Collections.Generic;
using BerlinClock.Classes.Models.BerlinClockModels;
using BerlinClock.Classes.Models.BerlinClockModels.Lamps;
using BerlinClock.Classes.Models.Consts;

namespace BerlinClock.Classes.Helpers
{
    internal class LightToStringConverter : ILightToStringConverter
    {
        private readonly Dictionary<Light, string> _lightToStringDictionary = new Dictionary<Light, string>()
        {
            {Light.None, "O" },
            {Light.Yellow, "Y" },
            {Light.Red, "R" }
        };

        public string Convert(Light light)
        {
            if (!this._lightToStringDictionary.ContainsKey(light))
            {
                throw new ApplicationException(ErrorMessages.LightNotExists);
            }

            return this._lightToStringDictionary[light];
        }
    }
}
