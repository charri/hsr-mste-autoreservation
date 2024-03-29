﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Common.Interfaces;
using AutoReservation.Ui.Properties;

namespace AutoReservation.Ui.Factory
{
    internal abstract class Creator
    {
        public abstract IAutoReservationService CreateInstance();

        public static Creator GetCreator()
        {
            Type serviceLayerType = Type.GetType(Settings.Default.ServiceLayerType);
            if (serviceLayerType == null)
            {
                return new LocalDataAccessCreator();
            }
            return (Creator)Activator.CreateInstance(serviceLayerType);
        }
    }
}
