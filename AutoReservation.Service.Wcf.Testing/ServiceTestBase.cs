using AutoReservation.BusinessLayer;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }
        
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        #region Read all entities

        [TestMethod]
        public void GetAutosTest()
        {
            List<AutoDto> autos = Target.Autos;
            Assert.AreEqual(3, autos.Count);
            Assert.IsTrue(autos[0].Marke == "Fiat Punto");
            Assert.IsTrue(autos[1].Marke == "VW Golf");
            Assert.IsTrue(autos[2].Marke == "Audi S6");
        }

        [TestMethod]
        public void GetKundenTest()
        {
            List<KundeDto> kunden = Target.Kunden;
            Assert.AreEqual(4, kunden.Count);
        }

        [TestMethod]
        public void GetReservationenTest()
        {
            List<ReservationDto> reservationen = Target.Reservationen;
            Assert.AreEqual(3, reservationen.Count);
        }

        #endregion

        #region Get by existing ID

        [TestMethod]
        public void GetAutoByIdTest()
        {
            AutoDto auto = Target.GetAutoById(1);
            Assert.AreEqual(1, auto.Id);
            Assert.AreEqual("Fiat Punto", auto.Marke);
            Assert.AreEqual(50, auto.Tagestarif);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            KundeDto kunde = Target.GetKundeById(1);
            Assert.AreEqual(1, kunde.Id);
            Assert.AreEqual("Nass", kunde.Nachname);
            Assert.AreEqual("Anna", kunde.Vorname);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            ReservationDto reservation = Target.GetReservationByNr(1);
            Assert.AreEqual(1, reservation.ReservationsNr);
            Assert.AreEqual(Convert.ToDateTime("10.01.2020 00:00:00"), reservation.Von);
            Assert.AreEqual(1, reservation.Auto.Id);
        }

        #endregion

        #region Get by not existing ID

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException),"Entity not found")]
        public void GetAutoByIdWithIllegalIdTest()
        {
            AutoDto auto = new AutoReservationService().GetAutoById(99);
            Assert.IsNull(auto);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException), "Entity not found")]
        public void GetKundeByIdWithIllegalIdTest()
        {
            KundeDto kunde = new AutoReservationService().GetKundeById(99);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException), "Entity not found")]
        public void GetReservationByNrWithIllegalIdTest()
        {
            ReservationDto reservation = new AutoReservationService().GetReservationByNr(99);
        }

        #endregion

        #region Insert

        [TestMethod]
        public void InsertAutoTest()
        {
            AutoDto myCar = new AutoDto
            {
                Marke = "Bugatti",
                AutoKlasse = AutoKlasse.Luxusklasse,
                Basistarif = 350,
                Tagestarif = 210
            };
            Assert.AreEqual(Target.Autos.Count, 3);
            Target.InsertAuto(myCar);
            Assert.AreEqual(Target.Autos.Count, 4);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            KundeDto myKunde = new KundeDto
            {
                Nachname = "Meier",
                Vorname = "Hans",
                Geburtsdatum = Convert.ToDateTime("10.12.1990")
            };
            Assert.AreEqual(Target.Kunden.Count, 4);
            Target.InsertKunde(myKunde);
            Assert.AreEqual(Target.Kunden.Count, 5);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            KundeDto myKunde = new KundeDto
            {
                Vorname = "Franz",
                Nachname = "Mueller",
                Geburtsdatum = new DateTime(1988, 6, 23)
            };
            AutoDto myCar = new AutoDto
            {
                Marke = "Porsche 911",
                AutoKlasse = AutoKlasse.Luxusklasse,
                Tagestarif = 300,
                Basistarif = 1000
            };
            Target.InsertKunde(myKunde);
            Target.InsertAuto(myCar);

            ReservationDto reservation = new ReservationDto
            {
                Auto = Target.GetAutoById(Target.Autos.Count),
                Kunde = Target.GetKundeById(Target.Kunden.Count),
                Von = DateTime.Now,
                Bis = new DateTime(2017, 1, 23)
            };
            Target.InsertReservation(reservation);

            ReservationDto inserted = Target.GetReservationByNr(Target.Reservationen.Count);
            Assert.AreEqual(inserted.Kunde.Vorname, "Franz");
            Assert.AreEqual(inserted.Kunde.Nachname, "Mueller");
            Assert.AreEqual(inserted.Auto.Marke, "Porsche 911");
            Assert.AreEqual(Target.Reservationen.Count, 4);
        }

        #endregion

        #region Delete  

        [TestMethod]
        public void DeleteAutoTest()
        {
            var autos = Target.Autos;
            int countBefore = autos.Count;
            AutoDto auto = autos[countBefore -1];
            Target.DeleteAuto(auto);
            Assert.AreEqual(Target.Autos.Count, countBefore - 1);
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            var kunden = Target.Kunden;
            int countBefore = kunden.Count;
            KundeDto kunde = kunden[countBefore - 1];
            Target.DeleteKunde(kunde);
            Assert.AreEqual(Target.Kunden.Count, countBefore - 1);
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            var reservationen = Target.Reservationen;
            int countBefore = reservationen.Count;
            ReservationDto reservation = reservationen[countBefore - 1];
            Target.DeleteReservation(reservation);
            Assert.AreEqual(Target.Reservationen.Count, countBefore - 1);
        }

        #endregion

        #region Update

        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto auto = Target.GetAutoById(1);
            auto.Marke = "Fiat Test";
            Target.UpdateAuto(auto);
            AutoDto modified = Target.GetAutoById(1);
            Assert.AreEqual(auto.Marke, modified.Marke);

        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            KundeDto kunde = Target.GetKundeById(1);
            kunde.Nachname = "NassTest";
            Target.UpdateKunde(kunde);
            KundeDto modified = Target.GetKundeById(1);
            Assert.AreEqual(kunde.Nachname, modified.Nachname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            ReservationDto reservation = Target.GetReservationByNr(1);
            reservation.Bis = new DateTime(2017, 1, 23, 22, 30, 00);
            Target.UpdateReservation(reservation);
            ReservationDto modified = Target.GetReservationByNr(1);
            Assert.AreEqual(reservation.Bis, modified.Bis);
        }

        #endregion

        #region Update with optimistic concurrency violation

        [TestMethod]
        public void UpdateAutoWithOptimisticConcurrencyTest()
        {
            AutoDto beforeAuto = Target.GetAutoById(1);
            beforeAuto.Marke = "Fiat Test";
            Target.UpdateAuto(beforeAuto);
            Target.UpdateAuto(beforeAuto);
        }

        [TestMethod]
        public void UpdateKundeWithOptimisticConcurrencyTest()
        {
            KundeDto beforeKunde = Target.GetKundeById(1);
            beforeKunde.Vorname = "Hans";
            beforeKunde.Nachname = "Test";
            Target.UpdateKunde(beforeKunde);
            Target.UpdateKunde(beforeKunde);
        }

        [TestMethod]
        public void UpdateReservationWithOptimisticConcurrencyTest()
        {
            ReservationDto beforeReservation = Target.GetReservationByNr(1);
            beforeReservation.Kunde = Target.GetKundeById(3);
            Target.UpdateReservation(beforeReservation);
            Target.UpdateReservation(beforeReservation);
        }

        #endregion
    }
}
