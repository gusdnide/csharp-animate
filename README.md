# csharp-animate

This is a tool which basically works as an extension to System.Windows.Media.Animation, where you can animate whatever you may please
using actions.

Example taken from animate_testing:

    DoubleAnimation animation = new Animate.DoubleAnimation();
    animation.Duration = TimeSpan.FromMilliseconds(3000);
    animation.From = 0;
    animation.To = 10;
    animation.UpdateAction = new Action<double>((double value) =>
    {
        Console.WriteLine(value);
    });

    animation.BeginAnimation();
    
    
    
The neat thing is that you can use WPF's Easing-functions, and that library is completely customizable.
    
I will update this in the future and add more types of animations, but I think you should be able to create your own easily based off of what's here.
