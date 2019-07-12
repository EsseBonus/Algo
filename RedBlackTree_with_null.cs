class Program
{
    // красно-черное дерево, где листы - null
    static void Main(string[] args)
    {
        Tree<int, string> tree = new Tree<int, string>();

        tree.RBInsertion(26, null);
        tree.RBInsertion(56, null);
        tree.RBInsertion(34, null);
        tree.RBInsertion(98, null);
        tree.RBInsertion(21, null);
        tree.RBInsertion(14, null);
        tree.RBInsertion(28, null);
        tree.RBInsertion(92, null);
        tree.RBInsertion(12, null);
        tree.RBInsertion(45, null);

        Console.WriteLine("done");
    }
}

public class Tree<K, V> where K : IComparable<K>
{
    Node<K, V> root;

    public void RBInsertion(K key, V value)
    {
        Node<K, V> z = new Node<K, V>(key, value);

        Node<K, V> y = null;
        Node<K, V> x = root;

        if (root == null)
        {
            root = z;
            return;
        }

        while (x != null)
        {
            y = x;

            if (z.key.CompareTo(x.key) < 0)
            {
                x = x.Left;
            }
            else
            {
                x = x.Right;
            }
        }

        z.Parent = y;

        if (z.key.CompareTo(z.Parent.key) < 0)
        {
            y.Left = z;
        }
        else
        {
            y.Right = z;
        }

        z.color = Color.Red;

        RBInsertFixUp(z);
    }

    void RBInsertFixUp(Node<K, V> z)
    {
        Node<K, V> y = null;

        while (z.Parent != null && z.Parent.color == Color.Red)
        {
            if (z.Parent == z.Parent.Parent.Left)
            {
                y = z.Parent.Parent.Right;

                if (y != null && y.color == Color.Red)
                {
                    z.Parent.color = Color.Black;
                    y.color = Color.Black;
                    z.Parent.Parent.color = Color.Red;
                    z = z.Parent.Parent;
                }
                else
                {
                    if (z == z.Parent.Right)
                    {
                        z = z.Parent;
                        LeftRotate(z);
                    }

                    z.Parent.color = Color.Black;
                    z.Parent.Parent.color = Color.Red;

                    RightRotate(z.Parent.Parent);
                }
            }
            else
            {
                y = z.Parent.Parent.Left;

                if (y != null && y.color == Color.Red)
                {
                    z.Parent.color = Color.Black;
                    y.color = Color.Black;
                    z.Parent.Parent.color = Color.Red;
                    z = z.Parent.Parent;
                }
                else
                {
                    if (z == z.Parent.Left)
                    {
                        z = z.Parent;
                        RightRotate(z);
                    }

                    z.Parent.color = Color.Black;
                    z.Parent.Parent.color = Color.Red;

                    LeftRotate(z.Parent.Parent);
                }
            }
        }

        root.color = Color.Black;
    }

    void LeftRotate(Node<K, V> x)
    {
        Node<K, V> y = x.Right;

        x.Right = y.Left;

        if (y.Left != null)
        {
            y.Left.Parent = x;
        }

        y.Parent = x.Parent;

        if (x.Parent == null)
        {
            root = y;
        }
        else if (x == x.Parent.Left)
        {
            x.Parent.Left = y;
        }
        else
        {
            x.Parent.Right = y;
        }

        y.Left = x;

        x.Parent = y;
    }

    void RightRotate(Node<K, V> y)
    {
        Node<K, V> x = y.Left;

        y.Left = x.Right;

        if (x.Right != null)
        {
            x.Right.Parent = y;
        }

        x.Parent = y.Parent;

        if (y.Parent == null)
        {
            root = x;
        }
        else if (y == y.Parent.Right)
        {
            y.Parent.Right = x;
        }
        else
        {
            y.Parent.Left = x;
        }

        x.Right = y;
        y.Parent = x;
    }

    Node<K, V> TreeMinimum(Node<K, V> x)
    {
        while (x.Left != null)
        {
            x = x.Left;
        }

        return x;
    }

    Node<K, V> TreeMaximum(Node<K, V> x)
    {
        while (x.Right != null)
        {
            x = x.Right;
        }

        return x;
    }

    Node<K, V> FindNodeToDelete(int key)
    {
        Node<K, V> x = root;

        while (x != null)
        {
            if (key.CompareTo(x.key) < 0)
            {
                x = x.Left;
            }
            else if (key.CompareTo(x.key) > 0)
            {
                x = x.Right;
            }
            else
            {
                return x;
            }
        }

        return x;
    }

    void RBTransplant(Node<K, V> u, Node<K, V> v)
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

    public void RBDelete(int key)
    {
        //Найти удаляемый узел
        Node<K, V> z = FindNodeToDelete(key);

        Node<K, V> y = z;
        Color yOriginalColor = y.color;
        Node<K, V> x = null;

        if (z.Left == null)
        {
            x = z.Right;
            RBTransplant(z, z.Right);
        }
        else if (z.Right == null)
        {
            x = z.Left;
            RBTransplant(z, z.Left);
        }
        else
        {
            y = TreeMinimum(z.Right);
            yOriginalColor = y.color;
            x = y.Right;

            if (y.Parent == z)
            {
                x.Parent = y;
            }
            else
            {
                RBTransplant(y, y.Right);
                y.Right = z.Right;
                y.Right.Parent = y;
            }

            RBTransplant(z, y);

            y.Left = z.Left;
            y.Left.Parent = y;
            y.color = z.color;
        }

        if (yOriginalColor == Color.Black)
        {
            RBDeleteFixup(x);
        }
    }

    void RBDeleteFixup(Node<K, V> x)
    {
        Node<K, V> w = null;

        while (x != null && x != root && x.color == Color.Black)
        {
            if (x == x.Parent.Left)
            {
                w = x.Parent.Right;

                if (w.color == Color.Red)
                {
                    w.color = Color.Black;
                    x.Parent.color = Color.Red;

                    LeftRotate(x.Parent);

                    w = x.Parent.Right;
                }

                if (w.Left.color == Color.Black && w.Right.color == Color.Black)
                {
                    w.color = Color.Red;
                    x = x.Parent;
                }
                else
                {
                    if (w.Right.color == Color.Black)
                    {
                        w.Left.color = Color.Black;
                        w.color = Color.Red;

                        RightRotate(w);

                        w = x.Parent.Right;
                    }

                    w.color = x.Parent.color;
                    x.Parent.color = Color.Black;
                    w.Right.color = Color.Black;

                    LeftRotate(x.Parent);

                    x = root;
                }
            }
            else
            {
                w = x.Parent.Left;

                if (w.color == Color.Red)
                {
                    w.color = Color.Black;
                    x.Parent.color = Color.Red;

                    RightRotate(x.Parent);

                    w = x.Parent.Left;
                }

                if (w.Right.color == Color.Black && w.Left.color == Color.Black)
                {
                    w.color = Color.Red;
                    x = x.Parent;
                }
                else
                {
                    if (w.Left.color == Color.Black)
                    {
                        w.Right.color = Color.Black;
                        w.color = Color.Red;

                        LeftRotate(w);

                        w = x.Parent.Left;
                    }

                    w.color = x.Parent.color;
                    x.Parent.color = Color.Black;
                    w.Left.color = Color.Black;

                    RightRotate(x.Parent);

                    x = root;
                }
            }
        }

        if (x != null)
        {
            x.color = Color.Black;
        }
    }
}

public enum Color
{
    Black,
    Red
}

public class Node<K, V>
{
    public K key;
    public V value;

    public Node<K, V> Parent;
    public Node<K, V> Left;
    public Node<K, V> Right;

    public Color color;

    public Node(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}
