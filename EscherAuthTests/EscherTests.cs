﻿using NUnit.Framework;
using EscherAuth;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscherAuthTests
{
    [TestFixture()]
    public class EscherTests
    {
        [Test()]
        public void HelloTest()
        {
            Assert.AreEqual("Hello World", new Escher().Hello());
        }
    }
}
