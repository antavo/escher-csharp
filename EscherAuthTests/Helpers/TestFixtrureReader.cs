﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace EscherAuthTests.Helpers
{
    class TestFixtureReader
    {
        public static TestFixture Read(string fileName)
        {
            return JsonConvert.DeserializeObject<TestFixture>(File.ReadAllText(fileName));
        }
    }
}
