using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WeaponCraft wcraft = new WeaponCraft();
            GearCraft gcraft = new GearCraft();

            ICraftWeapon sword2h = new Sword2H(2300, 500, 300);
            ICraftWeapon dagger = new Dagger(1500, 250, 100);

            ICraftGear robe = new Robe(3000, 50, 600);
            ICraftGear legs = new Legs(1715, 550, 30);

            wcraft.CraftWeapon(sword2h);
            wcraft.WeaponIsReady(sword2h);

            wcraft.CraftWeapon(dagger);
            wcraft.WeaponIsReady(dagger);

            gcraft.CraftGear(robe);
            gcraft.GearIsReady(robe);

            gcraft.CraftGear(legs);
            gcraft.GearIsReady(legs);

            Console.ReadKey();
            



        }
    }

    public interface ICraftWeapon
    {
        int Money { get; set; }
        int Steel { get; set; }
        int Leather { get; set; }
        

        void CraftWeapon(int money, int steel, int leather);
        void WeaponIsReady();
    }
        
        
    public interface ICraftGear
    {
        int Money { get; set; }
        int Leather { get; set; }
        int Cloth { get; set; }

        void CraftGear(int money, int leather, int cloth);
        void GearIsReady();
    }



    public class WeaponCraft
    {
        public void CraftWeapon(ICraftWeapon craft)
        {
            craft.CraftWeapon(craft.Money, craft.Steel, craft.Leather);
        }

        public void WeaponIsReady(ICraftWeapon craft)
        {
            craft.WeaponIsReady();
        }
    }

    public class GearCraft
    {
        public void CraftGear(ICraftGear craft)
        {
            craft.CraftGear(craft.Money, craft.Leather, craft.Cloth);
        }

        public void GearIsReady(ICraftGear craft)
        {
            craft.GearIsReady();
        }
    }
        



    public class Sword2H : ICraftWeapon
    {
        public int Money { get; set; }
        public int Steel { get; set; }
        public int Leather { get; set; }

        public Sword2H(int money, int steel, int leather)
        {
            this.Money = money;
            this.Steel = steel;
            this.Leather = leather;
        }

        public void CraftWeapon(int money, int steel, int leather)
        {
            Console.WriteLine($"Crafting 2 handed Sword.....\n " +
                $"Resources used: money: {money}| steel: {steel}| leather: {leather}.");
        }

        public void WeaponIsReady()
        {
            Console.WriteLine("Sword completed!");
        }
    }

    public class Dagger : ICraftWeapon
    {
        public int Money { get; set; }
        public int Steel { get; set; }
        public int Leather { get; set; }

        public Dagger(int money, int steel, int leather)
        {
            this.Money = money;
            this.Steel = steel;
            this.Leather = leather;
        }

        public void CraftWeapon(int money, int steel, int leather)
        {
            Console.WriteLine($"Crafting Dagger.....\n " +
                $"Resources used: money: {money}| steel: {steel}| leather: {leather}.");
        }

        public void WeaponIsReady()
        {
            Console.WriteLine("Dagger completed!");
        }
    }


    public class Robe : ICraftGear
    {
        public int Money { get; set; }
        public int Leather { get; set; }
        public int Cloth { get; set; }

        public Robe(int money, int leather, int cloth)
        {
            this.Money = money;
            this.Leather = leather;
            this.Cloth = cloth;
        }


        public void CraftGear(int money, int leather, int cloth)
        {
            Console.WriteLine($"Crafting Robe....\n" +
                $"Resources used: money: {money}| leather: {leather}| cloth: {cloth}.");
        }

        public void GearIsReady()
        {
            Console.WriteLine("Robe completed!");
        }
    }

    public class Legs : ICraftGear
    {
        public int Money { get; set; }
        public int Leather { get; set; }
        public int Cloth { get; set; }

        public Legs(int money, int leather, int cloth)
        {
            this.Money = money;
            this.Leather = leather;
            this.Cloth = cloth;
        }


        public void CraftGear(int money, int leather, int cloth)
        {
            Console.WriteLine($"Crafting Legs....\n" +
                $"Resources used: money: {money}| leather: {leather}| cloth: {cloth}.");
        }

        public void GearIsReady()
        {
            Console.WriteLine("Legs completed!");
        }
    }
}
