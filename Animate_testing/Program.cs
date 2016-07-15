using Animate;
using System;
using System.Windows.Media.Animation;

namespace Animate_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Animate.DoubleAnimation animation = new Animate.DoubleAnimation();
            animation.Duration = TimeSpan.FromMilliseconds(2000);
            animation.From = 0;
            animation.To = 30;
            animation.EasingFunction = new BackEase() { Amplitude = 10 };
            animation.UpdateAction = new Action<double>((double value) =>
            {
                Console.Clear();
                for(int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < value; i++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();
                }
            });
            animation.BeginAnimation();

            Console.ReadLine();
        }
    }
}
