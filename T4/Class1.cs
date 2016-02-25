namespace T4
{
    public sealed class Stack : IStack
    {
        private StackNode _top;

        void IStack.Push(StackNode node)
        {
            node.Next = _top;
            _top = node;
        }

        StackNode IStack.Pop()
        {
            var result = _top;
            _top = _top.Next;
            return result;
        }
    }

    public interface IStack
    {
        void Push(StackNode node);
        StackNode Pop();
    }

    public class StackNode
    {
        internal StackNode Next;
    }

    public sealed class MyData : StackNode
    {
        // public ... actual data here;
    }
}