using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuromillionsML
{
    public static class EuromillionServiceHelper
    {
        public static EuromillionDrawns EuromillionDrawnsConverter(EuromillionDrawnsDto euromillionDrawnsDto)
        {
            var euromillionDrawns = new EuromillionDrawns()
            {
                drawns = new List<EuromillionDrawn>()
            };

            foreach (var drawnDto in euromillionDrawnsDto.drawns)
            {
                var euromillionDraw = EuromillionServiceHelper.EuromillionDrawnConverter(drawnDto);
                euromillionDrawns.drawns.Add(euromillionDraw);
            }

            return euromillionDrawns;
        }

        public static EuromillionDrawn EuromillionDrawnConverter(EuromillionDrawnDto drawnDto)
        {
            DateTime drawnDate = ParseStringToDate(drawnDto.date);
            var balls = ParseNumbers(drawnDto.balls);
            var stars = ParseNumbers(drawnDto.stars);

            var drawn = new EuromillionDrawn()
            {
                Date = drawnDate,
                Balls = balls,
                Stars = stars
            };
            return drawn;
        }

        private static List<int> ParseNumbers(string balls)
        {
            var ballsSplit = balls.Split(' ');
            var res = new List<int>();
            ballsSplit.ToList().ForEach(x => res.Add(Int16.Parse(x)));
            return res;
        }

        private static DateTime ParseStringToDate(string date)
        {
            var dateSplit = date.Split('-');
            return new DateTime(Int16.Parse(dateSplit[0]), Int16.Parse(dateSplit[1]), Int16.Parse(dateSplit[2]));
        }
    }
}
