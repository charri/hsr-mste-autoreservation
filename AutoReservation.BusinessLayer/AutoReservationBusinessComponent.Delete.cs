using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer
{
    public partial class AutoReservationBusinessComponent
    {
        public static Auto DeleteAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                var reservations = context.Reservationen.Where(reservation => reservation.Auto.Id == auto.Id).ToList();
                if (reservations.Count > 0)
                {
                    throw new RelationExistsException(auto, new List<object>(reservations));
                }
            }
            return Delete(auto);
        }

        public static Kunde DeleteKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                var reservations = context.Reservationen.Where(reservation => reservation.Kunde.Id == kunde.Id).ToList();
                if (reservations.Count > 0)
                {
                    throw new RelationExistsException(kunde, new List<object>(reservations));
                }
            }
            return Delete(kunde);
        }

        public static T Delete<T>(T entry) where T : class
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {
                    context.Set<T>().Attach(entry);
                    entry = context.Set<T>().Remove(entry);
                    context.SaveChanges();
                    return entry;
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, entry);
                }
            }
            return null;
        }
    }
}
