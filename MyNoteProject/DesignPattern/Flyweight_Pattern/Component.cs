using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Flyweight_Pattern
{
    public abstract class Component
    {
        protected string mName;

        public Component(string name)
        {
            mName = name;
        }
        public abstract void setLocation(int x, int y);
    }
    public class ConcreteComponent : Component
    {
        public ConcreteComponent(string name) : base(name) { }

        public override void setLocation(int x, int y)
        {
            Console.WriteLine($"Place {mName} at ({x},{y})");
        }
    }
    public static class ComponentFactory
    {
        static Dictionary<string, Component> mMap = new Dictionary<string, Component>();

        public static Component createComponent(string key)
        {
            Component component;
            mMap.TryGetValue(key, out component);

            if (component == null)
            {
                component = new ConcreteComponent(key);
                mMap.Add(key, component);
            }
            return component;
        }
    }
}
