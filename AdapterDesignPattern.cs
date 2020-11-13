using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Compound unknown = new Compound("Unknown");
            unknown.Display();

            Compound water = new RichCompound("Water");
            water.Display();

            Compound benzene = new RichCompound("Benzene");
            benzene.Display();

            Compound ethanol = new RichCompound("Ethanol");
            ethanol.Display();

            Compound nitrogen = new RichCompound("Nitrogen");
            nitrogen.Display();

            Console.ReadKey();

        }
    }
    // Target class
    class Compound
    {
        protected string _chemical;
        protected float _boilingPoint;
        protected float _meltingPoint;
        protected double _molecularWeight;
        protected string _molecularFormula;


        public Compound(string chemical)
        {
            this._chemical = chemical;
        }

        public virtual void Display()
        {
            Console.WriteLine("\nCompound: {0} -------------",_chemical);
        }
    }


    //The Adapter class
    class RichCompound : Compound
    {
        private ChemicalDataBank _bank;


        public RichCompound(string name) : base (name)
        {

        }

        public override void Display()
        {
            // The Adaptee
            _bank = new ChemicalDataBank();

            _boilingPoint = _bank.GetCriticalPoint(_chemical, "B");
            _meltingPoint = _bank.GetCriticalPoint(_chemical, "M");
            _molecularWeight = _bank.GetMolecularWeight(_chemical);
            _molecularFormula = _bank.GetMolecularStructure(_chemical);

            base.Display();

            Console.WriteLine(" Formula: {0}", _molecularFormula);
            Console.WriteLine(" Weigth: {0}", _molecularWeight);
            Console.WriteLine(" Melting Point: {0}", _meltingPoint);
            Console.WriteLine(" Boiling Point: {0}", _boilingPoint);
        }
    }

    class ChemicalDataBank
    {
        public float GetCriticalPoint(string compound, string point)
        {
            // Melting Point
            if(point == "M")
            {
                switch(compound.ToLower())
                {
                    case "water": return 0.0f;
                    case "benzene": return 5.5f;
                    case "enthanol": return -114.1f;
                    case "nitrogen": return -210.00f;

                    default: return 0f;
                }
            }
            //Boiling Point
            else
            {
                switch(compound.ToLower())
                {
                    case "water": return 100f;
                    case "benzene": return 80.1f;
                    case "ethanol": return 78.3f;
                    case "nitrogen": return -195.79f;
                    default: return 0f;
                }
            }
        }

        public string GetMolecularStructure(string compound)
        {
            switch(compound.ToLower())
            {
                case "water": return "H20";
                case "benzene": return "C6H6";
                case "ethanol": return "C2H5OH";
                case "nitrogen": return "N2";
                default: return "";
            }
        }

        public double GetMolecularWeight(string compound)
        {
            switch(compound.ToLower())
            {
                case "water": return 18.015;
                case "benzene": return 78.1134;
                case "ethanol": return 46.0688;
                case "nitrogen": return 9.81;
                default: return 0d;
            }
        }

       




    }

}
