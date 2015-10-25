﻿using NUnit.Framework;
using EscherAuth;
using System;
using System.IO;
using System.Linq;
using EscherAuthTests.Helpers;

namespace EscherAuthTests
{
    [TestFixture()]
    public class StringToSignComposerTests
    {
        [Test(), TestCaseSource("TestFixtures")]
        public void ComposeTest(TestFixture testFixture)
        {
            var stringToSignComposer = new StringToSignComposer();
            var stringToSign = stringToSignComposer.Compose(
                testFixture.expected.canonicalizedRequest,
                testFixture.config.DateTime,
                testFixture.config.ToEscherConfig()
            );

            Assert.AreEqual(testFixture.expected.stringToSign, stringToSign, "stringToSign does not work");
        }

        static object[] TestFixtures()
        {
            //return new object[] { TestFixtureReader.Read(@"TestFixtures/aws4_testsuite\signrequest-get-vanilla.json") };

            var files = Directory.GetFiles("TestFixtures/aws4_testsuite")
                .Union(Directory.GetFiles("TestFixtures/emarsys_testsuite"));

            return files
                .Where(file => file.Contains("signrequest"))
                .Where(file => !IsOnBlackList(file))
                .Select(file => (object)TestFixtureReader.Read(file))
                .ToArray();
        }

        static bool IsOnBlackList(string file)
        {
            var blackList = new[]
            {
                "signrequest-get-vanilla-query-unreserved",
                "signrequest-post-vanilla-query-nonunreserved",
                "signrequest-date-header-should-be-signed-headers", // WARNING do not exclude in e2e tests
                "signrequest-support-custom-config" // 2x // TODO what are these?
            };

            return blackList.Any(file.Contains);
        }
    }
}