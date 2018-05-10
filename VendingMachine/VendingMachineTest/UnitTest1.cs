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
        VendingMachine.VendingMachine logic = new VendingMachine.VendingMachine();

        [TestMethod]
        public void TestMethod1()
        {
            logic.PutMoney(MoneyKind.ONE_HUNDRED);

            Assert.AreEqual(100, logic.DisplayCache());

            logic.PutMoney(MoneyKind.TEN);

            Assert.AreEqual(110, logic.DisplayCache());
        }

        [TestMethod]
        public void TestMethod2()
        {
            logic.PutMoney(MoneyKind.ONE);

            logic.PutMoney(MoneyKind.TWO_THOUSAND);

            logic.PutMoney(MoneyKind.FIVE_THOUSAND);

            logic.PutMoney(MoneyKind.TEN_THOUSAND);

            Assert.AreEqual(0, logic.DisplayCache());
        }

        [TestMethod]
        public void TestMethod3()
        {

            logic.PutMoney(MoneyKind.FIVE_HUNDRED);

            logic.BuyDrink(DrinkKind.COKE);

            Assert.AreEqual(4, logic.rack.Count(DrinkKind.COKE));

            logic.BuyDrink(DrinkKind.CIDER);

            Assert.AreEqual(4, logic.rack.Count(DrinkKind.CIDER));

            logic.BuyDrink(DrinkKind.TEA);

            Assert.AreEqual(4, logic.rack.Count(DrinkKind.TEA));

            logic.BuyDrink(DrinkKind.COKE);

            Assert.AreEqual(3, logic.rack.Count(DrinkKind.COKE));

        }

        [TestMethod]
        public void TestMethod4()
        {
            for(int index = 0; index<5; index++)
            {
                logic.BuyDrink(DrinkKind.COKE);
            }

            Assert.AreEqual(null, logic.BuyDrink(DrinkKind.COKE));
        }

        [TestMethod]
        public void TestMethod5()
        {
            logic.PutMoney(MoneyKind.FIVE_HUNDRED);

            logic.BuyDrink(DrinkKind.COKE);

            Console.WriteLine(logic.DisplayCache());

            Assert.AreEqual(4, logic.rack.Count(DrinkKind.COKE));

        }

        [TestMethod]
        public void TestMethod6()
        {
            var logic = new VendingMachine.Domain.Moneys.CoinMech();

            logic.IsChange(1100);
        }

        [TestMethod]
        public void TestChange()
        {
            // 500円を2回入れる
            logic.PutMoney(MoneyKind.FIVE_HUNDRED);
            logic.PutMoney(MoneyKind.FIVE_HUNDRED);

            // 120円のコーラを買う
            logic.BuyDrink(DrinkKind.COKE);

            Assert.AreEqual(880, logic.ReturnChange().Amount());

        }

        [TestMethod]
        public void TestPayment()
        {
            // 500円を2回入れる
            logic.PutMoney(MoneyKind.FIVE_HUNDRED);
            logic.PutMoney(MoneyKind.FIVE_HUNDRED);

            // 120円のコーラを買う
            logic.BuyDrink(DrinkKind.COKE);

            Assert.AreEqual(880, logic.DisplayCache());

        }

        [TestMethod]
        public void TestChange2()
        {
            for(int i= 0; i<10; i++)
            {
                logic.PutMoney(MoneyKind.ONE_HUNDRED);
            }
            // 120円のコーラを買う
            logic.BuyDrink(DrinkKind.COKE);

            var change = logic.ReturnChange();

            Assert.AreEqual(880, logic.ReturnChange().Amount());
        }
    }
}
