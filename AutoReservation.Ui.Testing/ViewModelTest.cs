using AutoReservation.TestEnvironment;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosLoadTest()
        {
            var viewModel = new AutoViewModel();
            var cmd = viewModel.LoadCommand;
            Assert.AreEqual(true, cmd.CanExecute(null));
            cmd.Execute(null);
            Assert.IsTrue(viewModel.Autos.Count > 0);
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            var viewModel = new KundeViewModel();
            var cmd = viewModel.LoadCommand;
            Assert.AreEqual(true, cmd.CanExecute(null));
            cmd.Execute(null);
            Assert.IsTrue(viewModel.Kunden.Count > 0);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            var viewModel = new ReservationenViewModel();
            var cmd = viewModel.LoadCommand;
            Assert.AreEqual(true, cmd.CanExecute(null));
            cmd.Execute(null);
            Assert.IsTrue(viewModel.Reservations.Count > 0);
        }
    }
}