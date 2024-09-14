namespace Iterator
{

    public class DataStack
    {
        private int[] items = new int[10];
        private int length;

        public DataStack() => length = -1;

        public DataStack(DataStack myStack)
        {
            this.items = myStack.items;
            this.length = myStack.length;
        }

        public int[] Items
        {
            get => items;
        }

        public int Length { get => length; }

        public void Push(int value)=> items[++length] = value;

        public int Pop() => items[length--];

        public static bool operator ==(DataStack myStack1, DataStack myStack2)
        {
            StackIterator it1 = new StackIterator(myStack1),
                it2 = new StackIterator(myStack2);

            while (it1.IsEnd() || it2.IsEnd())
            {
                if (it1.Get() != it2.Get()) break;
                it1++;
                it2++;
            }
            return !it1.IsEnd() && !it2.IsEnd();
        }

        public static bool operator !=(DataStack myStack1, DataStack myStack2)
        {
            StackIterator it1 = new StackIterator(myStack1),
                it2 = new StackIterator(myStack2);

            while (it1.IsEnd() || it2.IsEnd())
            {
                if (it1.Get() != it2.Get()) break;
                it1++;
                it2++;
            }
            return !(!it1.IsEnd() && !it2.IsEnd());
        }
    }

    public class StackIterator
    {
        private DataStack stack;
        private int index;

        public StackIterator(DataStack stack)
        {
            this.stack = stack;
            this.index = 0;
        }

        public static StackIterator operator ++(StackIterator s)
        {
            s.index++;
            return s;
        }

        public int Get()
        {
            if (index < stack.Length)
                return stack.Items[index];
            return 0;
        }

        public bool IsEnd() => index != stack.Length + 1;
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            DataStack myStack1 = new DataStack();
            for (int i = 1; i < 5; i++)
            {
                myStack1.Push(i);
            }

            DataStack myStack2 = new DataStack(myStack1);

            Console.WriteLine(myStack1 == myStack2);

            myStack2.Push(10);

            Console.WriteLine(myStack1 == myStack2);
        }
    }
}
