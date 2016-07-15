using System;

namespace Animate
{
    public class DoubleAnimation : Animation<double>
    {
        public override void BeginAnimation()
        {
            // do value check e.g if delta == 0 etc.
            base.BeginAnimation();
        }

        internal override void Update()
        {
            double deltaV = To - From;


            double easing = 1;
            if (EasingFunction != null) // <- that's important.
                easing = EasingFunction.Ease(Percentage);

            CurrentValue = From + (Percentage * deltaV * easing);


            base.Update(); // <- this too.
        }

        #region constructors
        public DoubleAnimation()
        {

        }
        public DoubleAnimation(double from, double to)
        {
            From = from;
            To = to;
        }
        public DoubleAnimation(double from, double to, TimeSpan duration)
        {
            From = from;
            To = to;
            Duration = duration;
        }
        public DoubleAnimation(double from, double to, Action<double> updateAction)
        {
            From = from;
            To = to;
            UpdateAction = updateAction;
        }
        public DoubleAnimation(double from, double to, TimeSpan duration, Action<double> updateAction)
        {
            From = from;
            To = to;
            Duration = duration;
            UpdateAction = updateAction;
        }
        #endregion
    }
}
