using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MSTest;


[TestClass]
public abstract class BaseTestInit
{
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
    }


    [TestInitialize]
    public virtual void TestInitialize()
    {
    }

    [TestCleanup]
    public void TestCleanup()
    {
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
    }
}
