namespace CH.Testing.T3.Interface
{
    internal interface ISource<out T>
    {
        T Value { get; }
    }
}