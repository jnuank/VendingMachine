using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;
using VendingMachine.Domain;
using VendingMachine.Utility;

namespace VendingMachineTest
{
    [TestClass]
    public class UnitTest1
    {
        VendingLogic logic = new VendingLogic();

        [TestMethod]
        public void TestMethod1()
        {
            logic.PutMoney(MoneyKind.ONE_HUNDRED);

            Assert.AreEqual(100, logic.GetPoolMoneyAmount());

            logic.PutMoney(MoneyKind.TEN);

            Assert.AreEqual(110, logic.GetPoolMoneyAmount());
        }

        [TestMethod]
        public void TestMethod2()
        {
            logic.PutMoney(MoneyKind.ONE);

            logic.PutMoney(MoneyKind.TWO_THOUSAND);

            logic.PutMoney(MoneyKind.FIVE_THOUSAND);

            logic.PutMoney(MoneyKind.TEN_THOUSAND);

            Assert.AreEqual(0, logic.GetPoolMoneyAmount());
        }

    }
}
