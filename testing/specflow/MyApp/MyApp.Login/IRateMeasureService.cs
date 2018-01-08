using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Login
{
    public interface IRateMeasureService
    {
        void Increment(string username);
        bool InsideLimit(string username, int minutes, int limit);
    }
}
