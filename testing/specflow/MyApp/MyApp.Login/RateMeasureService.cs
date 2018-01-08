using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login
{
    // this is not an efficient, scalable, thread safe, or distributed rate counting algorithm
    // just a toy for the purposes of this SpecFlow tutorial
    public class RateMeasureService : IRateMeasureService
    {
        private Dictionary<string, Queue<DateTime>> _rateCounter;

        public RateMeasureService()
        {
            _rateCounter = new Dictionary<string, Queue<DateTime>>();
        }

        public void Increment(string username)
        {
            Queue<DateTime> q = null;
            if(_rateCounter.TryGetValue(username, out q))
            {
                q.Enqueue(DateTime.UtcNow);
            }
            else
            {
                q = new Queue<DateTime>();
                q.Enqueue(DateTime.UtcNow);
                _rateCounter.Add(username, q);
            }
        }

        public bool InsideLimit(string username, int limitPeriodSeconds, int limit)
        {
            var limitDt = DateTime.UtcNow.AddSeconds(-limitPeriodSeconds);
            var q = _rateCounter[username];

            // remove entries outside limit period
            bool cleaning = true;
            while (cleaning)
            {
                var attempt = q.Peek();
                if (attempt < limitDt)
                    q.Dequeue();
                else
                    cleaning = false;
            }

            // check the number inside the range is less than the limit
            return q.Count <= limit;
        }
    }
}
