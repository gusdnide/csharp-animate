using Animate;
using System;

namespace Animate_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleAnimation animation = new Animate.DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(20);
            animation.From = 0;
            animation.To = 10;
            animation.UpdateAction = new Action<double>((double value) =>
            {
                Console.WriteLine(value);
                
            });

            animation.BeginAnimation();

            Console.ReadLine();
        }
    }
}
