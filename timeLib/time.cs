using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeLib
{
    public class time
    {
        public int day { get; set; }
        public string stime { get; set; }
        public string etime { get; set; }
        public double hours { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int id { get; set; }


        public static DateTime convertTimeToDateTime(time lr, bool isStart)
        {
            if (isStart)
            {
                return DateTime.Parse($"{lr.month}/{lr.day}/{lr.year} {lr.stime}", new CultureInfo("en-US"));              
            }

            //DateTime teme = DateTime.Parse($"{lr.month}/{lr.day}/{lr.year} {lr.etime}");
            //DateTime end = new DateTime(lr.year, lr.month, lr.day, teme.Hour, teme.Minute, teme.Second);
            return DateTime.Parse($"{lr.month}/{lr.day}/{lr.year} {lr.etime}", new CultureInfo("en-US"));
        }
    }
}
