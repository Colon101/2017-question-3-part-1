using System;
using System.Reflection.Metadata.Ecma335;

namespace Question6
{
    public class Program
    {

        public static bool Exist(BinNode<int>? t,int x)
        {
            if (t == null) return false;
            if (t.GetValue() == x) return true;
            return Exist(t.GetLeft(),x) || Exist(t.GetRight(),x);
        }
        public static Node<int>? Check(BinNode<int> t1, BinNode<int> t2)
        {
            Node<int> first = new(-1);
            first = Check(t1, t2,first);
            return first.GetNext();
        }
        public static Node<int> Check(BinNode<int>? t1, BinNode<int> t2,Node<int> lst)
        {
            if (t1 != null)
            {
                int x = t1.GetValue();
                if (!Exist(t2, x))
                {
                    lst.SetNext(new Node<int> (x,lst.GetNext()));
                }
                lst = Check(t1.GetLeft(), t2, lst);
                lst = Check(t1.GetRight(),t2, lst);
            }
            return lst;
        }
        public static void Main()
        {
            BinNode<int> bn1 = new(1);
            bn1.SetRight(new BinNode<int> (2));
            bn1.SetLeft(new BinNode<int> (3));
            bn1.GetRight()?.SetRight(new BinNode<int>(6));
            BinNode<int> bn2 = new(2);
            bn2.SetRight(new BinNode<int>(5));
            bn2.SetLeft(new BinNode<int>(3));
            bn2.GetRight()?.SetRight(new BinNode<int>(7));
            Node<int>? result = Check(bn1, bn2);
            while (result != null)
            {
                Console.WriteLine(result.GetValue());
                result = result.GetNext();
            }
        }
    }
    public class BinNode<T>
    {
        public T Value;
        public BinNode<T>? Left;
        public BinNode<T>? Right;
        public BinNode(T value)
        {
            Value = value;
        }
        public BinNode(BinNode<T> left, T value,BinNode<T> right)
        {
            Left = left;
            Right = right;
            Value = value;
        }
        public T GetValue()
        {
            return Value;
        }
        public BinNode<T>? GetLeft()
        {
            return Left;
        }
        public BinNode<T>? GetRight()
        {
            return Right;
        }
        public void SetValue(T value)
        {
            Value = value;
        }
        public void SetRight(BinNode<T> right)
        {
            Right = right;
        }
        public void SetLeft(BinNode<T> left)
        {
            Left = left;
        }
        public bool HasLeft()
        {
            return (Left != null);
        }
        public bool HasRight()
        {
            return (Right != null);
        }
        public override string? ToString()
        {
            return Value?.ToString();
        }
    }
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
        public Node(T value, Node<T>? next)
        {
            Value = value;
            Next = next;
        }
        public T GetValue() => Value;
        public T SetValue(T value)
        {
            return Value = value;
        }

        public Node<T>? GetNext() { return Next; }
        public bool HasNext() { return Next != null; }
        public override string? ToString() => Value?.ToString();
        public void SetNext(Node<T> next) => Next = next;
    }

}