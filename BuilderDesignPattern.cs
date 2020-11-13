using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            WeaponBuilder builder;
            // create director with weapon builders
            Blacksmith blacksmith = new Blacksmith();

            // Construct and display weapons
            builder = new SwordBuilder();
            blacksmith.Construct(builder);
            builder.Weapon.Examine();

            builder = new DaggerBuilder();
            blacksmith.Construct(builder);
            builder.Weapon.Examine();

            builder = new AxeBuilder();
            blacksmith.Construct(builder);
            builder.Weapon.Examine();

            Console.ReadKey();
        }
    }
    // Director class
    class Blacksmith
    {   // Bulder uses a complex series of steps
        public void Construct(WeaponBuilder weaponBuilder)
        {
            weaponBuilder.BuildHilt();
            weaponBuilder.BuildBlade();
            weaponBuilder.BuildScabbard();
        }
    }
    // Product class
    class Weapon
    {
        private string _weaponType;
        private Dictionary<string, string> _parts = new Dictionary<string, string>();

        public Weapon(string weaponType)
        {
            this._weaponType = weaponType;
        }

        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Examine()
        {
            Console.WriteLine("\n=========================");
            Console.WriteLine("Weapon Type: {0}", _weaponType);
            Console.WriteLine("Hilt : {0}", _parts["hilt"]);
            Console.WriteLine("Blade: {0}", _parts["blade"]);
            Console.WriteLine("Scabbard: {0}", _parts["scabbard"]);
        }

    }


    // The 'Builder' abstract class / interface
    abstract class WeaponBuilder
    {
        protected Weapon weapon;

        // gets weapon instance
        public Weapon Weapon
        {
            get { return weapon; }
        }
        // Abstract build methods
        public abstract void BuildHilt();
        public abstract void BuildBlade();
        public abstract void BuildScabbard();
    }

    // The 'ConcrateBuilder1' class
    class SwordBuilder : WeaponBuilder
    {
        public SwordBuilder()
        {
            weapon = new Weapon("Greate Sword");
        }

        public override void BuildHilt()
        {
            weapon["hilt"] = "Greate Sword Hilt";
        }

        public override void BuildBlade()
        {
            weapon["blade"] = "Greate Sword Blade";
        }

        public override void BuildScabbard()
        {
            weapon["scabbard"] = "Greate Sword Scabbard made of leather";
        }
    }
    // The 'ConcrateBuilder2' class
    class DaggerBuilder : WeaponBuilder
    {
        public DaggerBuilder()
        {
            weapon = new Weapon("Rogue's Dagger");
        }

        public override void BuildHilt()
        {
            weapon["hilt"] = "Rogue's Dagger Hilt";
        }

        public override void BuildBlade()
        {
            weapon["blade"] = "Dagger's Steel Blade";
        }

        public override void BuildScabbard()
        {
            weapon["scabbard"] = "Dagger's Wooden Scabbard";
        }
    }
    // The 'ConcrateBuilder3' class
    class AxeBuilder : WeaponBuilder
    {
        public AxeBuilder()
        {
            weapon = new Weapon("Warrior's Axe");
        }

        public override void BuildHilt()
        {
            weapon["hilt"] = "Warrior's Heave Hilt";
        }

        public override void BuildBlade()
        {
            weapon["blade"] = "Sharp Blade";
        }

        public override void BuildScabbard()
        {
            weapon["scabbard"] = "Axe Scabbard";
        }



    }


}
