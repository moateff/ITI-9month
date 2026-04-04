using System;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GroundDirector director = new GroundDirector();

            GroundBuilder groundBuilder = new GroundBuilder();
            Ground ground = director.Construct(groundBuilder);
            
            ground.Display();
        }
    }
}
