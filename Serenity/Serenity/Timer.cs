using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace Serenity
{
    public class Timer
    {
        private readonly List<TimeSpan> _timeSpanList;
        private readonly Func<bool> _callback;

        private CancellationTokenSource _cancellationTokenSource;
        public event EventHandler Ticking;

        public Timer(List<TimeSpan> timeSpanList, Func<bool> callback)
        {
            _timeSpanList = timeSpanList;
            _callback = callback;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Start()
        {
            CancellationTokenSource cts = _cancellationTokenSource;
            foreach (var ts in _timeSpanList)
            {
                Device.StartTimer(ts, () =>
                {
                    if (cts.IsCancellationRequested)
                    {
                        return false;
                    }
                    var result = _callback.Invoke();
                    Ticking?.Invoke(null, EventArgs.Empty);
                    return result;
                });
            }
        }

        public void Stop()
        {
            Interlocked.Exchange(ref _cancellationTokenSource, new CancellationTokenSource()).Cancel();
        }
    }
}
