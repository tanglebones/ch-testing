namespace CH.Testing.T2.Interface
{
    internal interface ISource<out T>
    {
        T Value { get; }
    }
}