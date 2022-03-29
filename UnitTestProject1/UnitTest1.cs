using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Penalty_Correct_3350()
        {
            DateTime dateStart = new DateTime(2021, 03, 29);
            double price = 1000;
            double ex = 3350;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
        [TestMethod]
        public void Penalty_Correct_155()
        {
            DateTime dateStart = new DateTime(2022, 01, 27);
            double price = 500;
            double ex = 155;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
        [TestMethod]
        public void Penalty_Correct_1215()
        {
            DateTime dateStart = new DateTime(2021, 06, 29);
            double price = 500;
            double ex = 1215;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
        [TestMethod]
        public void Penalty_Correct_139()
        {
            DateTime dateStart = new DateTime(2022, 01, 27);
            double price = 449;
            double ex = 139.19;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }

        [TestMethod]
        public void Penalty_Correct_402()
        {
            DateTime dateStart = new DateTime(2022, 02, 15);
            double price = 1299;
            double ex = 155.88;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }

        [TestMethod]
        public void Penalty_Correct_50()
        {
            DateTime dateStart = new DateTime(2021, 09, 13);
            double price = 200;
            double ex = 334;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
        [TestMethod]
        public void Penalty_Correct_484()
        {
            DateTime dateStart = new DateTime(2021, 06, 30);
            double price = 993;
            double ex = 2403.06;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
        [TestMethod]
        public void Penalty_Correct_655()
        {
            DateTime dateStart = new DateTime(2022, 01, 09);
            double price = 1337;
            double ex = 655.13;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
        [TestMethod]
        public void Penalty_Correct_0()
        {
            DateTime dateStart = new DateTime(2022, 03, 29);
            double price = 1337;
            double ex = 0;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
        [TestMethod]
        public void Penalty_Correct_4()
        {
            DateTime dateStart = new DateTime(2022, 02, 25);
            double price = 100;
            double ex = 2;
            double res = LibraryShiryaev2isp11_17.ClassHelper.Penalty.DebtClient(dateStart, price);
            Assert.AreEqual(ex, res);

        }
    }
}
