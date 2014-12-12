using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;
using AutoReservation.Ui.Factory;

namespace AutoReservation.Ui.Factory
{
    internal class LocalDataAccessCreator : Creator
	{
		public override IAutoReservationService CreateInstance()
		{
			var local = new AutoReservationService();
			return local;
		}
	}
}
