using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            // create and run EastKingdome World
            ContinentFactory eastKingdom = new EastKingdomFactory();
            Warcraft warcraft = new Warcraft(eastKingdom);
            warcraft.Fight();

            ContinentFactory kalimdor = new Kalimdor();
            warcraft = new Warcraft(kalimdor);
            warcraft.Fight();

            Console.ReadKey();
        }
    }


    // abstract product A
    abstract class Alliance
    {
        public abstract void Duel(Horde h);
    }

    // abstract product B
    abstract class Horde
    {
        public abstract void Duel(Alliance a);
    }


    // AbstractFactory / abstract class
    abstract class ContinentFactory
    {
        public abstract Alliance CreateHero();
        public abstract Horde CreateVillain();
    }

    // ConcrateFactory1 class
    class EastKingdomFactory : ContinentFactory
    {
        public override Alliance CreateHero()
        {
            return new NightElf();
        }

        public override Horde CreateVillain()
        {
            return new Orc();
        }
    }

    // ConcrateFactory2 class
    class Kalimdor : ContinentFactory
    {
        public override Alliance CreateHero()
        {
            return new Human();
        }

        public override Horde CreateVillain()
        {
            return new Undead();
        }
    }

    //ProductA1 class
    class NightElf : Alliance
    {
        public override void Duel(Horde h)
        {
            Console.WriteLine(this.GetType().Name + " heroic strike " + h.GetType().Name);
        }
    }

    //ProductB1 class
    class Orc : Horde
    {
        public override void Duel(Alliance a)
        {
            Console.WriteLine(this.GetType().Name + " backstab " + a.GetType().Name);
        }
    }

    //ProductA2 class
    class Human : Alliance
    {
        public override void Duel(Horde h)
        {
            Console.WriteLine(this.GetType().Name + " blinds " + h.GetType().Name);
        }
    }


    //PruductB2 class
    class Undead : Horde
    {
        public override void Duel(Alliance a)
        {
            Console.WriteLine(this.GetType().Name + " shadow bolt " + a.GetType().Name);
        }
    }

    // Client class
    class Warcraft
    {
        private Alliance _alliance;
        private Horde _horde;

        // constructor
        public Warcraft(ContinentFactory factory)
        {
            _alliance = factory.CreateHero();
            _horde = factory.CreateVillain();
        }

        public void Fight()
        {
            _horde.Duel(_alliance);
            _alliance.Duel(_horde);
        }
    }






}
