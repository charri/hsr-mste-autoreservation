using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent _target;
        private AutoReservationBusinessComponent Target
        {
            get { return _target ?? (_target = new AutoReservationBusinessComponent()); }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            var original = AutoReservationBusinessComponent.Find<Auto>(1);
            var auto = AutoReservationBusinessComponent.Find<Auto>(1);
            int newValue = ++auto.Tagestarif;

            original = AutoReservationBusinessComponent.Update(original, auto);

            Assert.AreEqual(newValue, original.Tagestarif);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            var original = AutoReservationBusinessComponent.Find<Kunde>(1);
            var kunde = AutoReservationBusinessComponent.Find<Kunde>(1);
            var newDate = kunde.Geburtsdatum.AddDays(1.0);
            kunde.Geburtsdatum = newDate;

            original = AutoReservationBusinessComponent.Update(original, kunde);

            Assert.AreEqual(newDate, original.Geburtsdatum);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            var original = AutoReservationBusinessComponent.Find<Reservation>(1);
            var res = AutoReservationBusinessComponent.Find<Reservation>(1);
            var newDate = res.Bis.AddDays(1.0);
            res.Bis = newDate;

            original = AutoReservationBusinessComponent.Update(original, res);

            Assert.AreEqual(newDate, original.Bis);
        }

    }
}
