using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace FantasyFootball
{
    class FantasyPoints
    {
        public bool PPR { get; set; }

        public static bool GetPPR()
        {
            var isPPR = 1;
            do
            {
                Console.WriteLine("Is this PPR format?");
                Console.WriteLine("1) Yes");
                Console.WriteLine("0) No");
                isPPR = Convert.ToInt32(Console.ReadLine());
            } while (isPPR != 1 && isPPR != 0);

                return Convert.ToBoolean(isPPR); 
        }

        public static void PrintFantasyPoints(List<GeneralPlayer> list)
        {
            Console.WriteLine("Fantasy Points");
            Console.WriteLine("Name\t\tPoints");
            foreach (var a in list)
            {
                Console.WriteLine("{0}\t\t{1}", a.name, a.fantasyPts);
            }
        }

        public static void CalcFantasyPoints(List<GeneralPlayer> list, bool p)
        {
            //separating the list into sub lists of type
            var quarters = list.OfType<Quarterback>();
            var wrrbtes = list.OfType<WRRBTE>();
            var kicker = list.OfType<Kicker>();
            
            foreach (var q in quarters)
            {
                double total = 0;
                total += q.rushTDs * 6;
                total += q.passTDs * 4;
                total += q.passYds * .04;
                total += q.rushYds * .1;
                total += q.fumbles * -2;
                total += q.interc * -2;
                q.fantasyPts = Math.Round(total, 2);
            }

            foreach (var wr in wrrbtes)
            {
                double total = 0;
                
                total += wr.rushTDs * 6;
                total += wr.recTDs * 6;
                total += wr.rushYds * .1;
                total += wr.recYds * .1;
                total += wr.fumbles * -2;
                if (p)
                {
                    total += wr.rec * 1;
                    Console.WriteLine("p is {0}", p);
                }
                wr.fantasyPts = Math.Round(total, 2);

            }

            foreach (var k in kicker)
            {
                double total = 0;
                // not totally accurate because points are typically based on length of kick for fgs
                total += k.fgMade * 3;
                total += k.epMade * 1;
                total += ((k.fgAtt - k.fgMade) * -1);
                // subtracting for misses
                total += ((k.epAtt - k.epMade) * -1);
                k.fantasyPts = Math.Round(total, 2);
            }
        }
    }

    

}
