using System;
using System.Collections.Generic;

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
            var balls = new List<int>()
            {
                Int16.Parse(drawnDto.ball_1),
                Int16.Parse(drawnDto.ball_2),
                Int16.Parse(drawnDto.ball_3),
                Int16.Parse(drawnDto.ball_4),
                Int16.Parse(drawnDto.ball_5),
            };

            var stars = new List<int>()
            {
                Int16.Parse(drawnDto.star_1),
                Int16.Parse(drawnDto.star_2),
            };

            var drawn = new EuromillionDrawn()
            {
                Date = drawnDate,
                Balls = balls,
                Stars = stars
            };
            return drawn;
        }


        private static DateTime ParseStringToDate(string date)
        {
            var dateSplit = date.Split('-');
            return new DateTime(Int16.Parse(dateSplit[0]), Int16.Parse(dateSplit[1]), Int16.Parse(dateSplit[2]));
        }
    }
}
