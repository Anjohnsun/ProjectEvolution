using Brain.Neurons;

namespace Brain
{
    internal class Connection
    {
        /// <summary>
        /// Следующий нейрон
        /// </summary>
        internal Neuron NextNeuron { get; }

        /// <summary>
        /// Предыдёщий нейрон
        /// </summary>
        internal Neuron PrevNeuron { get; }

        /// <summary>
        /// Вес связи
        /// </summary>
        internal double Weight { get; }

        /// <summary>
        /// Инициализация связи
        /// </summary>
        /// <param name="weight">Вес связи</param>
        /// <param name="nextNeuron">Предыдущий нейрон</param>
        /// <param name="prevNeuron">Следующий нейрон</param>
        internal Connection(double weight, Neuron nextNeuron, Neuron prevNeuron)
        {
            NextNeuron = nextNeuron;
            PrevNeuron = prevNeuron;
            Weight = weight;
        }

        /// <summary>
        /// Распространение
        /// </summary>
        internal void Propagation()
        {
            NextNeuron.Activation();
        }
    }
}
