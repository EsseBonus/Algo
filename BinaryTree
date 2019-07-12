// Обычное двоичное дерево с различными вариантами обхода
class Program
{
    static void Main(string[] args)
    {
        Tree<string> tree = new Tree<string>();

        tree.TreeInsert(12, null);
        tree.TreeInsert(5, null);
        tree.TreeInsert(18, null);
        tree.TreeInsert(2, null);
        tree.TreeInsert(9, null);
        tree.TreeInsert(15, null);
        tree.TreeInsert(19, null);
        tree.TreeInsert(13, null);
        tree.TreeInsert(17, null);

        tree.TreeDelete(12);

        //tree.MyOrder();
        //Console.WriteLine();

        //tree.InOrder();
        //Console.WriteLine();

        //tree.InOrderMy();

        Console.WriteLine("done!");
    }
}

public class Node<T>
{
    public int key;
    public T value;
    public Node<T> Parent;
    public Node<T> Left;
    public Node<T> Right;

    public Node(int key, T value)
        : this(key)
    {
        this.value = value;
    }

    public Node(int key)
    {
        this.key = key;
    }
}

public class Tree<T>
{
    Node<T> root;

    public void TreeDelete(int key)
    {
        Node<T> z = TreeSearch(key);

        if (z.Left == null)
        {
            Transplant(z, z.Right);
        }
        else if (z.Right == null)
        {
            Transplant(z, z.Left);
        }
        else
        {
            Node<T> y = TreeMinimum(z.Right);

            if (y.Parent != z)
            {
                Transplant(y, y.Right);
                y.Right = z.Right;
                y.Right.Parent = y;
            }

            Transplant(z, y);
            y.Left = z.Left;
            y.Left.Parent = y;
        }
    }

    void Transplant(Node<T> u, Node<T> v)
    {
        if (u.Parent == null)
        {
            root = v;
        }
        else if (u == u.Parent.Left)
        {
            u.Parent.Left = v;
        }
        else
        {
            u.Parent.Right = v;
        }

        if (v != null)
        {
            v.Parent = u.Parent;
        }
    }

    // Это центрированный (симметричный) обход - из Кормена 
    public void InOrder()
    {
        Stack<Node<T>> S = new Stack<Node<T>>();
        Node<T> current = root;
        bool done = false;

        while (!done)
        {
            if (current != null)
            {
                S.Push(current);
                current = current.Left;
            }
            else
            {
                if (S.Count > 0)
                {
                    current = S.Pop();
                    Console.Write(current.key + "\t");
                    current = current.Right;
                }
                else
                {
                    done = true;
                }
            }
        }
    }

    // Это центрированный (симметричный) обход - моя версия
    public void InOrderMy()
    {
        Stack<Node<T>> S = new Stack<Node<T>>();
        Node<T> current = root;

        S.Push(current);

        while (S.Count > 0)
        {
            while (current.Left != null)
            {
                S.Push(current.Left);
                current = current.Left;
            }

            if (S.Count > 0)
            {
                current = S.Pop();
                Console.Write(current.key + "\t");
            }

            while (current.Right == null && S.Count > 0)
            {
                current = S.Pop();
                Console.Write(current.key + "\t");
            }

            if (current.Right != null)
            {
                S.Push(current.Right);
                current = current.Right;
            }
        }
    }

    public void MyOrder()
    {
        Queue<Node<T>> queue = new Queue<Node<T>>();

        Node<T> current = root;
        queue.Enqueue(current);

        while (queue.Count > 0)
        {
            current = queue.Dequeue();

            if (current.Left != null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null)
            {
                queue.Enqueue(current.Right);
            }

            Console.Write(current.key + "\t");
        }
    }

    public Node<T> TreeSearch(int key)
    {
        Node<T> x = root;
        return _TreeSearch(key, x);
    }

    Node<T> _TreeSearch(int key, Node<T> x)
    {
        if (x == null || key == x.key)
        {
            return x;
        }

        if (key < x.key)
        {
            return _TreeSearch(key, x.Left);
        }
        else
        {
            return _TreeSearch(key, x.Right);
        }
    }

    public Node<T> TreeSuccessor(Node<T> x)
    {
        if (x.Right != null)
        {
            return TreeMinimum(x.Right);
        }

        Node<T> y = x.Parent;

        while (y != null && x == y.Right)
        {
            x = y;
            y = y.Parent;
        }

        return y;
    }

    private Node<T> TreeMinimum(Node<T> x)
    {
        while (x.Left != null)
        {
            x = x.Left;
        }

        return x;
    }

    private Node<T> TreeMaximum(Node<T> x)
    {
        while (x.Right != null)
        {
            x = x.Right;
        }

        return x;
    }

    public void TreeInsert(int key, T value)
    {
        Node<T> z = new Node<T>(key, value);
        Node<T> y = null;
        Node<T> x = root;

        while (x != null)
        {
            y = x;

            if (z.key < x.key)
            {
                x = x.Left;
            }
            else
            {
                x = x.Right;
            }
        }

        z.Parent = y;

        if (y == null)
        {
            root = z;
        }
        else if (z.key < y.key)
        {
            y.Left = z;
        }
        else
        {
            y.Right = z;
        }
    }
}
