namespace Brain.Functions
{
    internal class ReLUFunction : Function
    {
        internal override double GetValue(double x) => x >= 0 ? x : 0;
    }
}
