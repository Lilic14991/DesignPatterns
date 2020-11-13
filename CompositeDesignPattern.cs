using System;
using System.Collections;
using System.Collections.Generic;

namespace CompositeDesignPattern
{
    class Program
    {
        static void Main()
        {
            // create a tree structure
            CompositeObject root = new CompositeObject("Scene");

            root.Add(new PrimitiveObject("Green Line"));
            root.Add(new PrimitiveObject("Yellow Circle"));
            root.Add(new PrimitiveObject("Red Box"));

            // create a branch
            CompositeObject comp = new CompositeObject("Two Lines");

            comp.Add(new PrimitiveObject("Black Line"));
            comp.Add(new PrimitiveObject("White Line"));
            root.Add(comp);

            // add and remove a Primitive Object
            PrimitiveObject po = new PrimitiveObject("Blue Line");
            root.Add(po);
            root.Remove(po);

            // Recursively display nodes
            root.Display(1);

            // Wait user
            Console.ReadKey();



        }
    }


    abstract class DrawingObject
    {
        protected string _name;
        


        public DrawingObject(string name)
        {
            this._name = name;
        }


        public abstract void Add(DrawingObject draw);
        public abstract void Remove(DrawingObject draw);
        public abstract void Display(int  indent);

    }


    class PrimitiveObject : DrawingObject
    {
        public PrimitiveObject(string name) : base(name)
        {
            
        }

        public override void Add(DrawingObject draw)
        {
            Console.WriteLine("Cannot add to a Primitive Object!");
        }

        

        public override void Remove(DrawingObject draw)
        {
            Console.WriteLine("Cannot remove from a Primitive Object!");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String(char.Parse("/"), indent) + " " + _name);
        }
    }


    class CompositeObject : DrawingObject
    {
        private List<DrawingObject> objects = new List<DrawingObject>();

        public CompositeObject(string name) : base (name)
        {

        }

        public override void Add(DrawingObject draw)
        {
            objects.Add(draw);
        }

        public override void Remove(DrawingObject draw)
        {
            objects.Remove(draw);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String(char.Parse("/"), indent) + "+ " + _name);


            foreach(DrawingObject draw in objects)
            {
                draw.Display(indent + 2);
            }
        }
    }

    

    
    



}
