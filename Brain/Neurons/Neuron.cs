using Brain.Functions;

namespace Brain.Neurons
{
    internal partial class Neuron
    {
        /// <summary>
        /// Функция активации
        /// </summary>
        private readonly Function _activationFunction;

        /// <summary>
        /// Сумматор
        /// </summary>
        private readonly Summator _summator;

        /// <summary>
        /// Список последующих соединений
        /// </summary>
        internal List<Connection> PrevConnections { get; private set; }

        /// <summary>
        /// Список предыдущих соединений
        /// </summary>
        internal List<Connection> NextConnections { get; private set; }

        private double? _activationValue = null;

        /// <summary>
        /// Активационное значение
        /// </summary>
        internal double ActivationValue
        {
            get
            {
                if (_activationValue == null)
                    throw new Exception("Нейрону не присвоено значение активации");
                return (double)_activationValue;
            }
            private set
            {
                _activationValue = value;
            }
        }

        /// <summary>
        /// Инициализация нейрона
        /// </summary>
        /// <param name="activationFunction">Функция активации</param>
        internal Neuron(Function activationFunction)
        {
            _activationFunction = activationFunction;
            _summator = new Summator(this);
            PrevConnections = new List<Connection>();
            NextConnections = new List<Connection>();
        }

        /// <summary>
        /// Инициализация последующих связей
        /// </summary>
        /// <param name="nextNeurons">Следующие нейроны</param>
        public void InitNextConnections(List<Neuron> nextNeurons)
        {
            var randomGenerator = new Random();
            foreach (var neuron in nextNeurons)
            {
                var weight = randomGenerator.NextDouble() * 2 - 1;
                var connection = new Connection(weight, neuron, this);
                NextConnections.Add(connection);
                neuron.PrevConnections.Add(connection);
            }
        }

        /// <summary>
        /// Функция активации
        /// </summary>
        internal void Activation()
        {
            double summ = _summator.Summation();
            InputActivation(summ);
        }

        /// <summary>
        /// Функция активации для входных нейронов
        /// </summary>
        /// <param name="data">Входные данные</param>
        internal void InputActivation(double data)
        {
            ActivationValue = _activationFunction.GetValue(data);
        }
    }
}
