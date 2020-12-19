using Microsoft.ML.Data;

namespace EuromillionsML.ML
{
    public class EuroDrawnData
    {
        [LoadColumn(0)]
        public float Date;

        [LoadColumn(1)]
        public float Ball1;

        [LoadColumn(2)]
        public float Ball2;

        [LoadColumn(3)]
        public float Ball3;

        [LoadColumn(4)]
        public float Ball4;

        [LoadColumn(5)]
        public float Ball5;

        [LoadColumn(6)]
        public float Star1;

        [LoadColumn(7)]
        public float Star2;
    }
}
