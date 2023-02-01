using Brain.Functions;
using Brain.Neurons;

namespace Brain
{
    public class NeuralNetwork
    {
        /// <summary>
        /// Список слоёв
        /// </summary>
        private readonly List<Layer> _layers;

        /// <summary>
        /// Инициализация нейронной сети
        /// </summary>
        public NeuralNetwork()
        {
            _layers = new List<Layer>();
        }

        /// <summary>
        /// Добавление слоя
        /// </summary>
        /// <param name="count">Число нейронов в слое</param>
        /// <param name="functionType">Тип функции активации для каждого нейрона в слое</param>
        /// <exception cref="Exception">Неожиданный тип функции активации</exception>
        public void AddLayer(int count, FunctionTypes functionType)
        {
            Function activationFunction = functionType switch
            {
                FunctionTypes.Linear => new LinearFunction(),
                FunctionTypes.ReLU => new ReLUFunction(),
                _ => throw new Exception("Неожиданный тип функции активации"),
            };

            var newLayer = new Layer(count, activationFunction);
            _layers.Add(newLayer);

            if (_layers.Count > 1)
            {
                var preLayer = _layers[^2];
                preLayer.Neurons.ForEach(_ => _.InitNextConnections(newLayer.Neurons));
            }
        }

        /// <summary>
        /// Запуск нейронной сети
        /// </summary>
        /// <param name="data">Входные данные</param>
        /// <exception cref="Exception">Несовпадение количества входных данных и числа входных нейронов</exception>
        public void Run(double[] data)
        {
            var firstLayer = _layers.First();

            if (data.Length != firstLayer.Neurons.Count)
                throw new Exception("Кол-во входных данных не равно количеству входных нейронов");

            var newData = MinMaxNormalization.Normalization(data);

            for (int i = 0; i < newData.Length; i++)
            {
                var neuron = firstLayer.Neurons[i];
                var input = newData[i];
                neuron.InputActivation(input);
            }

            for (int i = 0; i < _layers.Count; i++)
            {
                var layer = _layers[i];
                layer.StartPropagation();
            }

        }

        /// <summary>
        /// Получение выходов нейросети
        /// </summary>
        /// <returns>Выходы нейросети</returns>
        public List<double> GetOutput()
        {
            var result = new List<double>();

            var outputLayer = _layers.Last().Neurons;
            foreach (var outputNeuron in outputLayer)
                result.Add(outputNeuron.ActivationValue);

            return result;
        }
    }
}