using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User_77_Lib.dll
{
    public class Calculations
    {
        public List<string> AvailablePeriods(
            TimeSpan[] startTimes,
            int[] durations,
            TimeSpan
            beginWorkingTime,
            TimeSpan endWorkingTime,
            int consultationTime
            )
        {
            List<string> periods = new List<string>();
            TimeSpan currectTime = beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime));

            for(int i = 0; i< startTimes.Length; i++)
            {
                while (currectTime  < endWorkingTime)
                {
                    if (startTimes[i] >= beginWorkingTime && startTimes[i] < currectTime)
                    {
                       beginWorkingTime = startTimes[i].Add(TimeSpan.FromMinutes(durations[i]));
                        currectTime = beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime));
                        break;
                    }
                    else
                    {
                        periods.Add(beginWorkingTime.ToString(@"hh\:mm") + "-" + currectTime.ToString());
                        beginWorkingTime = currectTime;
                        currectTime.Add(TimeSpan.FromMinutes(consultationTime));
                    }
                }


            }


            while (currectTime <= endWorkingTime)
            {
                periods.Add(beginWorkingTime.ToString(@"hh\:mm") + "-" + currectTime.ToString());
                beginWorkingTime = currectTime;
                currectTime.Add(TimeSpan.FromMinutes(consultationTime));
            }

            return new List<string>();
        }




    }
}
