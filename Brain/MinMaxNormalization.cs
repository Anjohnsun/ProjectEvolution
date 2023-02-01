namespace Brain
{
    internal static class MinMaxNormalization
    {
        private const double _from = -1;
        private const double _to = 1;

        public static double[] Normalization(double[] data)
        {
            var min = data.Min();
            var max = data.Max();

            double[] normData = data.Select(_ => New(_, min, max)).ToArray();

            return normData;
        }

        private static double New(double value, double min, double max) => (value - min) / (max - min) * (_to - _from) + _from;
    }
}
