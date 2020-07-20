using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    abstract class Component
    {
        public string Name { get; protected set; }
        public abstract void Operation();
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return false;
        }
    }
    class Computer : Component
    {
        private List<Component> children = new List<Component>();
        public Computer(string name)
        {
            Name = name;
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }
        public override void Remove(Component component)
        {
            children.Remove(component);
        }
        public override void Operation()
        {
            Console.WriteLine("Computer: " + Name + ", contains:");
            foreach(Component c in children)
            {
                c.Operation();
            }
        }
        public override bool IsComposite()
        {
            return true;
        }
    }

    class Processor : Component
    {
        public Processor(string name)
        {
            Name = name;
        }
        public override void Operation()
        {
            Console.WriteLine(Name);
        }
    }
    class GPU : Component
    {
        public GPU(string name)
        {
            Name = name;
        }
        public override void Operation()
        {
            Console.WriteLine(Name);
        }
    }
    class Motherboard : Component
    {
        public Motherboard(string name)
        {
            Name = name;
        }
        public override void Operation()
        {
            Console.WriteLine(Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Component computer = new Computer("ASUS");
            computer.Add(new Processor("Core i5"));
            computer.Add(new GPU("GTX 1050"));
            computer.Add(new Motherboard("Gigabyte"));

            computer.Operation();

            Console.Read();
        }
    }
}
