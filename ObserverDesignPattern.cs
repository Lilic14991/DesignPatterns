using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            string dateRelease = "19/04/2020";

            DateTime date = DateTime.ParseExact(dateRelease, "dd/MM/yyyy",
            CultureInfo.CurrentCulture);


            Company company = new Company("Cyberpunk 2077", date);
            company.AttachSubscriber(new Subscriber(1));
            company.AttachSubscriber(new Subscriber(2));
            company.AttachSubscriber(new Subscriber(3));

            company.Release = date.AddMonths(1);
            company.Release = date.AddMonths(3);
            company.Release = date.AddMonths(5);

            Console.ReadKey();

        }
    }

    public interface ISubscriber
    {
        void Update(DateTime ReleaseDate);
    }

    public class Subscriber : ISubscriber
    {
        private int subscriberID;

        

        public Subscriber(int id)
        {
            subscriberID = id;
        }

        public void Update(DateTime ReleaseDate)
        {
            Console.WriteLine($"Notification for subscriber with id: {subscriberID}\n" +
                $"Game will be released in {ReleaseDate}");
        }
    }

    public class ReleaseGame
    {
        private string GameName;
        private DateTime ReleaseDate;
        private List<ISubscriber> _sub = new List<ISubscriber>();

        public ReleaseGame(string gameName, DateTime releaseDate)
        {
            GameName = gameName;
            ReleaseDate = releaseDate;
        }


        public void PrintReleaseGameDate(string gameName, DateTime releaseDate)
        {
            Console.WriteLine($"{gameName} game will be released {releaseDate} ");
        }

        public void AttachSubscriber(ISubscriber subscriber)
        {
            _sub.Add(subscriber);
        }


        public void DetachSubscriber(ISubscriber subscriber)
        {
            _sub.Remove(subscriber);
        }


        public void NotifySubscriber()
        {
            foreach(ISubscriber subscriber in _sub)
            {
                subscriber.Update(ReleaseDate);
            }

            Console.WriteLine("");
        }

        public DateTime Release
        {
            get { return ReleaseDate; }
            set
            {
                if (ReleaseDate != value)
                {
                    ReleaseDate = value;
                    NotifySubscriber();
                }

                PrintReleaseGameDate(GameName,ReleaseDate);
            }
        }
    }
                
                
    public class Company : ReleaseGame
    {
        public Company(string gameName, DateTime release) : base(gameName, release)
        {

        }
    }
                








}
