using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace EuromillionsML
{
    public static class CsvHelper
    {
        public static void EuromillionDrawnsToCsv(IList<EuromillionDrawn> drawns, string path)
        {
            //write to csv
            using (var writer = new StreamWriter(path))
			{
                var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

                csv.WriteField("Date");
                csv.WriteField("Ball1");
                csv.WriteField("Ball2");
                csv.WriteField("Ball3");
                csv.WriteField("Ball4");
                csv.WriteField("Ball5");
                csv.WriteField("Star1");
                csv.WriteField("Star2");
                csv.NextRecord();
                foreach (var drawn in drawns)
                {
                    csv.WriteField(drawn.Date.GetUnixEpoch());
                    csv.WriteField(drawn.Balls);
                    csv.WriteField(drawn.Stars);
                    csv.NextRecord();
                }
                writer.Flush();
			}
        }

        private static double GetUnixEpoch(this DateTime dateTime)
        {
            var unixTime = dateTime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return unixTime.TotalSeconds;
        }
    }
}
