using AutoReservation.Dal.Entities;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {

        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }
        
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            Auto auto = Target.GetAutoById(1);
            Assert.AreEqual(50, auto.Tagestarif);
            auto.Tagestarif = 55;
            Target.UpdateAuto(auto);
            Auto auto2 = Target.GetAutoById(1);
            Assert.AreEqual(55, auto2.Tagestarif);
            auto.Tagestarif = 50;
            Target.UpdateAuto(auto);
            auto = Target.GetAutoById(1);
            Assert.AreEqual(50, auto.Tagestarif);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Kunde kunde = Target.GetKundeById(1);
            Assert.AreEqual("Nass", kunde.Nachname);
            kunde.Nachname = "Mooser";
            Target.UpdateKunde(kunde);
            kunde = null;
            Assert.IsNull(kunde);
            kunde = Target.GetKundeById(1);
            Assert.AreEqual("Mooser", kunde.Nachname);
            kunde.Nachname = "Nass";
            Target.UpdateKunde(kunde);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation res = Target.GetReservationById(1);
            Assert.AreEqual(1, res.AutoId);
            res.AutoId = 2;
            res.Auto = Target.GetAutoById(2);
            Target.UpdateReservation(res);
            res = null;
            res = Target.GetReservationById(1);
            Assert.AreEqual(2, res.AutoId);
            res.AutoId = 1;
            res.Auto = Target.GetAutoById(1);
            Target.UpdateReservation(res);
        }

    }

}
