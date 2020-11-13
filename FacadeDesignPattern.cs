using System;

namespace FacadeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            RobotFacade robotFacade = new RobotFacade();

            robotFacade.CreateRobot();

            Console.ReadKey();

        }
    }

   


    public class Arms
    {
        public void AttachRightArm()
        {
            Console.WriteLine("- Attaching right arm component!");
        }

        public void AttachLeftArm()
        {
            Console.WriteLine("-- Attaching left arm component!\n");
        }
    }

    public class Legs
    {
        public void AttachRightLeg()
        {
            Console.WriteLine("- Attaching right leg component!");
        }

        public void AttachLeftLeg()
        {
            Console.WriteLine("-- Attaching left leg component!\n");
        }
    }

    public class Torso
    {
        public void AttachTorso()
        {
            Console.WriteLine("- Attaching torso component!\n");
        }
    }

    public class Head
    {
        public void AttachHead()
        {
            Console.WriteLine("- Attaching head component!\n");
        }
    }


    // Facade 
    public class RobotFacade
    {
        readonly Arms arms;
        readonly Legs legs;
        readonly Torso torso;
        readonly Head head;


        public RobotFacade()
        {
            arms = new Arms();
            legs = new Legs();
            torso = new Torso();
            head = new Head();
        }

        public void CreateRobot()
        {
            Console.WriteLine("---| Building Robot |---\n");
            arms.AttachRightArm();
            arms.AttachLeftArm();
            legs.AttachRightLeg();
            legs.AttachLeftLeg();
            torso.AttachTorso();
            head.AttachHead();

            Console.WriteLine("---| Attaching different componenents to build Robot... |---");

            Console.WriteLine("---| ...Robot is merged! |---\t");

        }

    }










}
