namespace CH.Testing.T3.Interface
{
    interface ISource<out T>
    {
        T Value { get; }
    }
}