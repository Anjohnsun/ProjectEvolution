using Brain.Functions;
using Brain.Neurons;
using System.Runtime.InteropServices;

namespace Brain
{
    public class Layer
    {
        /// <summary>
        /// Список нейронов в слое
        /// </summary>
        internal List<Neuron> Neurons { get; }

        /// <summary>
        /// Инициализация слоя
        /// </summary>
        /// <param name="count">Число нейронов в слое</param>
        /// <param name="activationFunction">Функция активации для каждого нейрона</param>
        internal Layer(int count, Function activationFunction)
        {
            Neurons = new List<Neuron>();
            for (int i = 0; i < count; i++)
            {
                var neuron = new Neuron(activationFunction);
                Neurons.Add(neuron);
            }
        }

        /// <summary>
        /// Запуск распространения
        /// </summary>
        public void StartPropagation()
        {
            foreach (var neuron in Neurons)
            {
                foreach (var connection in neuron.NextConnections)
                {
                    connection.Propagation();
                }
            }
        }
    }
}
