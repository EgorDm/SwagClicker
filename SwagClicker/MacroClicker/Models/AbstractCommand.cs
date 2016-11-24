using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagClicker.Models
{
    abstract class AbstractCommand
    {
        protected TimeSpan Time;

        protected AbstractCommand(TimeSpan time)
        {
            this.Time = time;
        }

        public TimeSpan GetTime()
        {
            return Time;
        }

        public abstract bool Play(TimeSpan currTimeSpan);
    }
}
