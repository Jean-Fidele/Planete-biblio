using Hangfire;

namespace Synchonisation.Job
{
    public class JobsList
    {
        public static void Run()
        {
            RecurringJob.AddOrUpdate<JobsToRead>("denis-every-nights", svc => svc.EveryNights(), Cron.Daily(4)); // tous les jours à 4h00
            RecurringJob.AddOrUpdate<JobsToRead>("denis-every-two-hours", svc => svc.EveryTwoHours(), "0 0/2 * * *"); // toutes les 2 heures
            RecurringJob.AddOrUpdate<JobsToRead>("denis-pull-documents", svc => svc.EveryNights(), Cron.Daily(23)); // tous les jours à 23h00
            RecurringJob.AddOrUpdate<JobsToRead>("denis-download-images", svc => svc.EveryNights(), Cron.Daily(0)); // tous les jours à minuit (doit être fait après les documents car MAJ aussi les documents)
            RecurringJob.AddOrUpdate<JobsToRead>("denis-download-documents", svc => svc.EveryNights(), Cron.Daily(1)); // tous les jours à minuit (doit être fait après les documents car MAJ aussi les documents)
        }
    }
}
