using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.Interfaces;

namespace AutoReservation.Ui.Factory
{
    internal class RemoteDataAccessCreator : Creator
    {
        public override IAutoReservationService CreateInstance()
        {
            var factory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
            return factory.CreateChannel();
        }
    }
}
