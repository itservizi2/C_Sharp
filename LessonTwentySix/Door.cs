using System;

namespace LessonTwentySix
{
    
    public interface IDoor
    {
        string Material { get; }
        string Size { get; }
        string Color { get; }
        void Display();
    }

    
    public class WoodenDoor : IDoor
    {
        public string Material => "Wood";
        public string Size { get; }
        public string Color { get; }

        public WoodenDoor(string size, string color)
        {
            Size = size;
            Color = color;
        }

        public void Display()
        {
            Console.WriteLine($"[Wooden Door] Material: {Material}, Size: {Size}, Color: {Color}");
        }
    }

    public class MetalDoor : IDoor
    {
        public string Material => "Metal";
        public string Size { get; }
        public string Color { get; }

        public MetalDoor(string size, string color)
        {
            Size = size;
            Color = color;
        }

        public void Display()
        {
            Console.WriteLine($"[Metal Door] Material: {Material}, Size: {Size}, Color: {Color}");
        }
    }

    
    public interface IDoorFactory
    {
        IDoor CreateDoor(string size, string color);
    }

    
    public class WoodenDoorFactory : IDoorFactory
    {
        public IDoor CreateDoor(string size, string color)
        {
            return new WoodenDoor(size, color);
        }
    }

    public class MetalDoorFactory : IDoorFactory
    {
        public IDoor CreateDoor(string size, string color)
        {
            return new MetalDoor(size, color);
        }
    }

    
    public class FactoryManager
    {
        private IDoorFactory _doorFactory;

        public FactoryManager(IDoorFactory doorFactory)
        {
            _doorFactory = doorFactory;
        }

        public IDoor BuildDoor(string size, string color)
        {
            return _doorFactory.CreateDoor(size, color);
        }
    }

    
    class DoorAbstractFactory
    {
        public static void Execute()
        {
            FactoryManager woodenManager = new FactoryManager(new WoodenDoorFactory());
            IDoor woodenDoor = woodenManager.BuildDoor("80x200", "Brown");
            woodenDoor.Display();

            Console.WriteLine();

            FactoryManager metalManager = new FactoryManager(new MetalDoorFactory());
            IDoor metalDoor = metalManager.BuildDoor("90x210", "Gray");
            metalDoor.Display();
        }
    }
}