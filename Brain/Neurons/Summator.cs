namespace Brain.Neurons
{
    internal partial class Neuron
    {
        internal class Summator
        {
            /// <summary>
            /// Нейрон
            /// </summary>
            public Neuron Neuron { get; private set; }

            /// <summary>
            /// Инициализация сумматора
            /// </summary>
            /// <param name="neuron">Нейрон</param>
            public Summator(Neuron neuron)
            {
                Neuron = neuron;
            }

            /// <summary>
            /// Процесс суммации
            /// </summary>
            /// <returns>Результат суммации</returns>
            public double Summation()
            {
                double result = 0;

                foreach (var prevConnection in Neuron.PrevConnections)
                {
                    var value = prevConnection.Weight * prevConnection.PrevNeuron.ActivationValue;
                    result += value;
                }

                return result;
            }
        }
    }
}
