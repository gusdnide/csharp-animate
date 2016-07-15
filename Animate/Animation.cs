using System;
using System.Windows.Media.Animation;

namespace Animate
{
    public class Animation
    {
        public event EventHandler OnAnimationComplete;
        private TimeSpan _Duration = TimeSpan.FromMilliseconds(0);
        public TimeSpan Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        internal TimeSpan CurrentTime = TimeSpan.FromMilliseconds(0);
        internal double Percentage = 0;
        internal bool HasFinished = false;

        internal void OnComplete()
        {
            OnAnimationComplete?.Invoke(this, new EventArgs());
        }

        internal virtual void Update()
        {
            
        }
    }
    public class Animation<T> : Animation
    {
        public virtual Action<T> UpdateAction { get; set; }
        public EasingFunctionBase EasingFunction { get; set; }
        public T CurrentValue { get; internal set; }


        public T To { get; set; }
        public T From { get; set; }


        internal override void Update()
        {
            UpdateAction?.Invoke(CurrentValue);
        }


        public virtual void BeginAnimation()
        {
            if (Duration.TotalMilliseconds <= 0)
                throw new InvalidOperationException("You need a duration greater than 0 seconds.");

            if (EasingFunction.CanFreeze)
                EasingFunction.Freeze();

            AnimationFactory.BeginAnimation(this);
        }
    }
}
