using System;

namespace ProxyDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Shinobi shinobi = new Shinobi();

            Console.WriteLine("Shinobi: Executing the shinobi's attacks with real Jutsu!\n");
            RealJutsu realJutsu = new RealJutsu();
            shinobi.ShinobiAttack(realJutsu);

            Console.WriteLine("Shinobi: Executing the shinobi's attacks with shadow clon!/KagebushiNoJutsu/\n");
            KagebushiNoJutsu kagebushiNo = new KagebushiNoJutsu(realJutsu);
            shinobi.ShinobiAttack(kagebushiNo);
        }
    }

    public interface IJutsu
    {
        void ThrowShuriken();
        void KunaiAttack();
        void SpecialJutsu();

    }

    class RealJutsu : IJutsu
    {
        public void KunaiAttack()
        {
            Console.WriteLine("Throw kunai at target!\n"); 
        }

        public void SpecialJutsu()
        {
            Console.WriteLine("Cast special jutsu on target!\n");
        }

        public void ThrowShuriken()
        {
            Console.WriteLine("Throw shuriken on target!\n");
        }
    }


    // proxy
    class KagebushiNoJutsu : IJutsu
    {
        private RealJutsu _realJutsu;

        public KagebushiNoJutsu(RealJutsu realJutsu)
        {
            this._realJutsu = realJutsu;
        }

        public void ThrowShuriken()
        {
            if(this.KagebushiAtacked())
            {
                this._realJutsu.ThrowShuriken();
                
                
            }

        }

        public void KunaiAttack()
        {
            if(this.KagebushiAtacked())
            {
                this._realJutsu.KunaiAttack();
                
            }
        }

        public void SpecialJutsu()
        {
            if(this.KagebushiAtacked())
            {
                this._realJutsu.SpecialJutsu();
                this.OutOfDuration();
            }
        }

        public bool KagebushiAtacked()
        {
            Console.WriteLine("Shinobi: attack with shadow clon!/KagebushiNoJutsu/");

            return true;
        }

        public void OutOfDuration()
        {
            Console.WriteLine("Kagebusi: Killed the target and disappeared! PUFF!!!");
        }

        
    }


    public class Shinobi
    {
        public void ShinobiAttack(IJutsu jutsu)
        {
            jutsu.KunaiAttack();
            jutsu.ThrowShuriken();
            jutsu.SpecialJutsu();

            
            
        }
    }


        

}
