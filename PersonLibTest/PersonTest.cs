using ElZino.Models.PersonLib;
using System;
using System.Collections.Generic;
using Xunit;

namespace PersonLibTest
{
    public class PersonTest
    {
        public static IEnumerable<object[]> PersonDataPass =>
           new List<object[]>
           {
                new object[] { true, "Max","Mustermann"},
                new object[] { true, "Alice","MusterFrau"},
                new object[] { false, "Max","Mustermann" },
                new object[] { false, "Alice","MusterFrau"}
           };

        [Theory]
        [MemberData(nameof(PersonDataPass))]
        public void CreateConstructor_Passing(bool withConst, string fname, string lname)
        {
            Person p;
            if (withConst)
                p = new(fname, lname);
            else
                p = new()
                {
                    FirstName = fname,
                    LastName = lname
                };

            //Test
            Assert.NotNull(p);
            Assert.Equal(fname, p.FirstName);
            Assert.Equal(lname, p.LastName);
        }

        public static IEnumerable<object[]> PersonDataFail =>
           new List<object[]>
           {
                new object[] { true, string.Empty,"Mustermann"},
                new object[] { true, "Alice",string.Empty},
                new object[] { true, string.Empty, string.Empty},
                new object[] { false, string.Empty,"Mustermann"},
                new object[] { false, "Alice",string.Empty},
                new object[] { false, string.Empty, string.Empty}
           };

        [Theory]
        [MemberData(nameof(PersonDataFail))]
        public void CreateConstructor_Failing(bool withConst, string fname, string lname)
        {
            if (withConst)
            {
                Person p;
                Assert.Throws<Exception>(() => p = new(fname, lname));
            }
            else
            {
                Person p = new();

                Assert.Throws<Exception>(() =>
                {
                    p.FirstName = fname;
                    p.LastName = lname;
                });
            }
        }

        public static IEnumerable<object[]> ToStringPass =>
           new List<object[]>
           {
                new object[] {"Max","Mustermann"},
                new object[] {"Alice","MusterFrau"},
                new object[] {"Mahmoud","Zino"},
                new object[] {"Simon","Masooglu"},
                new object[] {"yay","WOW"},
           };

        [Theory]
        [MemberData(nameof(ToStringPass))]
        public void ToString_Passing(string fname, string lname)
        {
            Person p = new(fname, lname);

            Assert.Equal($"{fname} {lname}", p.ToString());
        }
    }
}
