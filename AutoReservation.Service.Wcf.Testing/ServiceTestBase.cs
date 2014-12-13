using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Exceptions;
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

        [TestMethod]
        public void AutosTest()
        {
            var result = Target.FindAllAutos();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void KundenTest()
        {
            var result = Target.FindAllKunden();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            var result = Target.FindAllReservationen();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            var auto = Target.FindAuto(1);
            Assert.AreEqual(1, auto.Id);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            var kunde = Target.FindKunde(1);
            Assert.AreEqual(1, kunde.Id);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            var res = Target.FindReservation(1);
            Assert.AreEqual(1, res.ReservationNr);
        }

        
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            var result = Target.FindReservation(int.MaxValue);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            var auto = new AutoDto {Marke = "Lala", AutoKlasse = AutoKlasse.Standard, Tagestarif = 10};
            var after = Target.InsertAuto(auto);
            Assert.AreEqual(auto.Marke, after.Marke);
            Assert.AreNotEqual(auto.Id, after.Id);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            var kunde = new KundeDto {Geburtsdatum = DateTime.Now.Date, Nachname = "Nötig", Vorname = "Hans"};
            var after = Target.InsertKunde(kunde);
            Assert.AreNotSame(kunde, after);
            Assert.AreNotEqual(kunde.Id, after.Id);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            var auto = Target.FindAuto(1);
            var kunde = Target.FindKunde(1);
            var res = new ReservationDto { Auto = auto, Kunde = kunde, Von = DateTime.Now.Date, Bis = DateTime.Now.Date.AddDays(10)};
            var after = Target.InsertReservation(res);
            Assert.AreNotSame(res, after);
            Assert.AreNotEqual(res.ReservationNr, after.ReservationNr);
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            var original = Target.FindAuto(1);
            var auto = Target.FindAuto(1);
            auto.Marke = "LaLa";
            var after = Target.UpdateAuto(original, auto);
            Assert.AreEqual(auto.Marke, after.Marke);
            Assert.AreNotEqual(original.Marke, auto.Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            var original = Target.FindKunde(1);
            var kunde = Target.FindKunde(1);
            kunde.Nachname = "Nötig";
            var after = Target.UpdateKunde(original, kunde);
            Assert.AreEqual(kunde.Nachname, after.Nachname);
            Assert.AreNotEqual(original.Nachname, after.Nachname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            var original = Target.FindReservation(1);
            var res = Target.FindReservation(1);
            res.Bis = res.Bis.AddDays(1);
            var after = Target.UpdateReservation(original, res);

            Assert.AreEqual(res.Bis, after.Bis);
            Assert.AreNotEqual(original.Bis, after.Bis);
        }
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            var original = Target.FindAuto(1);
            var auto = Target.FindAuto(1);
            auto.Marke = "LaLa";
            var after = Target.UpdateAuto(original, auto);
            Target.UpdateAuto(original, after);
        }
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            var original = Target.FindKunde(1);
            var kunde = Target.FindKunde(1);
            kunde.Nachname = "Nötig";
            var after = Target.UpdateKunde(original, kunde);
            Target.UpdateKunde(original, after);
        }
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            var original = Target.FindReservation(1);
            var res = Target.FindReservation(1);
            res.Bis = res.Bis.AddDays(1);
            var after = Target.UpdateReservation(original, res);

            Target.UpdateReservation(original, after);
        }
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [TestMethod]
        public void DeleteKundeTest()
        {
            var kunde = Target.FindKunde(1);
            Target.DeleteKunde(kunde);
        }
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        [TestMethod]
        public void DeleteAutoTest()
        {
            var kunde = Target.FindKunde(1);
            Target.DeleteKunde(kunde);
        }
        [TestMethod]
        public void DeleteReservationTest()
        {
            var res = Target.FindReservation(1);
            Target.DeleteReservation(res);
        }
    }
}
