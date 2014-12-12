using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer
{
    public partial class AutoReservationBusinessComponent
    {

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }

        public static List<T> FindAll<T>()
            where T : class
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Set<T>().ToList();
            }
        }

        public static T Find<T>(int id)
            where T : class
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Set<T>().Find(id);
            }
        }

        public static List<Reservation> FindAllReservationen()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.Include(r => r.Auto).Include(r => r.Kunde).ToList();
            }
        }

        public static Reservation FindReservation(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservationen.Include(r => r.Auto)
                    .Include(r => r.Kunde).First(r => r.ReservationNr == id);
            }
        }

        public static T Insert<T>(T entry) where T : class
        {
            using (var context = new AutoReservationEntities())
            {
                entry = context.Set<T>().Add(entry);
                context.SaveChanges();
                return entry;
            }
        }

        public static T Update<T>(T original, T modified) where T : class
        {
            using (var context = new AutoReservationEntities())
            {
                try
                {

                    context.Set<T>().Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                    return modified;
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }

            return null;
        }
    }
}