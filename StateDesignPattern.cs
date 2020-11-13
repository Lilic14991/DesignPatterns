using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new ConcrateStateA());
            context.Request1();
            context.Request2();

            Console.ReadKey();
        }
    }

    class Context
    {
        private State _state = null;

        public Context(State state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}");
            this._state = state;
            this._state.SetContext(this);
        }

        public void Request1()
        {
            this._state.Handle1();
        }

        public void Request2()
        {
            this._state.Handle2();
        }
    }

    abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }

    class ConcrateStateA : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcrateStateA handles request1.");
            Console.WriteLine("ConcrateStateA wants to change the state of the context.");
            this._context.TransitionTo(new ConcrateStateB());
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcrateStateA handles request2.");
        }
    }

    class ConcrateStateB : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcrateStateB handles request1.");
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcrateStateB handles request2.");
            Console.WriteLine("ConcrateStateB wants to change the state of the context.");
            this._context.TransitionTo(new ConcrateStateA());
        }
    }
}
