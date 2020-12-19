using Microsoft.ML.Data;

namespace EuromillionsML.ML
{
    public class EuroDrawnPrediction
    {
        [ColumnName("bola1")]
        public float Ball1;

        [ColumnName("bola2")]
        public float Ball2;

        [ColumnName("bola3")]
        public float Ball3;

        [ColumnName("bola4")]
        public float Ball4;

        [ColumnName("bola5")]
        public float Ball5;

        [ColumnName("estrela1")]
        public float Star1;

        [ColumnName("estrela2")]
        public float Star2;
    }
}
