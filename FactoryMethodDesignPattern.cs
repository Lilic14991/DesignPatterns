using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Canvas[] canvases = new Canvas[2];

            canvases[0] = new Gameplay();
            canvases[1] = new UI();

            foreach(Canvas canvas in canvases)
            {
                Console.WriteLine("\n" + canvas.GetType().Name + " : ");
                foreach(Point point in canvas.Points)
                {
                    Console.WriteLine(" " + point.GetType().Name);
                }
            }
            Console.ReadKey();

        }



    }
    // Product abstract class
    abstract class Point
    {

    }

    //  A 'ConcreteProduct' class
    class SkillPoint : Point
    {

    }

    class ExpiriencePoint : Point
    {

    }

    class HitPoint : Point
    {

    }

    class WayPoint : Point
    {

    }

    class CheckPoint : Point
    {

    }

    class ScorePoint : Point
    {

    }

    class AnchorPoint : Point
    {

    }

    // The 'Creator' abstract class
    abstract class Canvas
    {
        private List<Point> _points = new List<Point>();

        public Canvas()
        {
            this.CreatePoints();
        }

        public List<Point> Points
        {
            get { return _points; }
        }
        // Factory Method
        public abstract void CreatePoints();


    }

    // A 'ConcreteCreator' class
    class Gameplay : Canvas
    {
        public override void CreatePoints()
        {
            // Factory Method implementation
            Points.Add(new SkillPoint());
            Points.Add(new ExpiriencePoint());
            Points.Add(new HitPoint());
            Points.Add(new CheckPoint());
            Points.Add(new WayPoint());
        }
    }
    // A 'ConcreteCreator' class
    class UI : Canvas
    {
        public override void CreatePoints()
        {
            // Factory Method implementation
            Points.Add(new ScorePoint());
            Points.Add(new AnchorPoint());
        }
    }


}
