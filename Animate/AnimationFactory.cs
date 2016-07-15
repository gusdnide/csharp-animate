using System;
using System.Collections.Generic;
using System.Threading;

namespace Animate
{
    public static class AnimationFactory
    {
        private static List<Animation> _CurrentAnimations = new List<Animation>();
        private static TimeSpan _Updaterate = TimeSpan.FromSeconds(1d / 60d);
        private static Timer _UpdateTimer = new Timer(Callback, null, (int)_Updaterate.TotalMilliseconds, Timeout.Infinite);
        private static DateTime _LastUpdate = DateTime.Now;

        private static bool _isEnabled = false;

        public static TimeSpan Updaterate
        {
            get { return _Updaterate; }
            set { _Updaterate = value; }
        }



        public static void BeginAnimation<T>(Animation<T> animation)
        {
            _CurrentAnimations.Add(animation);

            _isEnabled = true;
            _UpdateTimer.Change((int)_Updaterate.TotalMilliseconds, Timeout.Infinite);
        }


        private static void Callback(object stateInfo)
        {
            DateTime now = DateTime.Now;
            TimeSpan dt = now - _LastUpdate;

            for (int i = 0; i < _CurrentAnimations.Count; i++)
            {
                var ani = _CurrentAnimations[i];

                ani.CurrentTime += dt;
                ani.Percentage = ani.CurrentTime.TotalMilliseconds / ani.Duration.TotalMilliseconds;

                if (ani.Percentage >= 1)
                {
                    ani.HasFinished = true;
                    ani.OnComplete();
                }
                else
                    ani.Update();
            }

            _CurrentAnimations.RemoveAll(x => x.HasFinished);

            if (_CurrentAnimations.Count == 0)
                _isEnabled = false;

            _LastUpdate = now;

            if (_isEnabled)
                _UpdateTimer.Change((int)_Updaterate.TotalMilliseconds, Timeout.Infinite);
        }

    }
}
