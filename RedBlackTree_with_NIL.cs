// Красно-черное дерево с NIL-sentinel, т.е. листы и родитель корня - NIL
public class Program
{
    static void Main(string[] args)
    {
        Tree<string> tree = new Tree<string>();

        tree.RBInsertion(26);
        tree.RBInsertion(56);
        tree.RBInsertion(34);
        tree.RBInsertion(98);
        tree.RBInsertion(21);
        tree.RBInsertion(14);
        tree.RBInsertion(28);
        tree.RBInsertion(92);
        tree.RBInsertion(12);
        tree.RBInsertion(45);

        Console.WriteLine();

        tree.RBDelete(6);

        Console.WriteLine("done");
    }
}

public enum Color
{
    Black,
    Red
}

public class Node<T>
{
    public int key;
    public T value;

    public Node<T> Parent;
    public Node<T> Left;
    public Node<T> Right;

    public Color color = Color.Red;

    // Для обычных узлов
    public Node(int key, T value)
        : this(key)
    {
        this.value = value;
    }

    public Node(int key)
    {
        this.key = key;
    }

    private static Node<T> _nil;

    public static Node<T> NIL
    {
        get
        {
            if (_nil == null)
            {
                return _nil = new Node<T>(int.MinValue, Color.Black);
            }
            else
            {
                return _nil;
            }
        }
    }

    // Конструктор для узла NIL
    private Node(int key, Color color)
        : this(key)
    {
        this.color = color;
    }
}

public class Tree<T>
{
    //root.Parent == NIL, а также левый и правый потомки любого листа == NIL
    private Node<T> NIL = Node<T>.NIL;
    public Node<T> root = Node<T>.NIL;

    public void RBDelete(int key)
    {
        //Найти удаляемый узел
        Node<T> z = FindNodeToDelete(key);

        Node<T> y = z;
        Color yOriginalColor = y.color;
        Node<T> x = NIL;

        if (z.Left == NIL)
        {
            x = z.Right;
            RBTransplant(z, z.Right);
        }
        else if (z.Right == NIL)
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

    Node<T> FindNodeToDelete(int key)
    {
        Node<T> x = root;

        while (x != NIL)
        {
            if (key < x.key)
            {
                x = x.Left;
            }
            else if (key > x.key)
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

    void RBDeleteFixup(Node<T> x)
    {
        Node<T> w = NIL;

        while (x != root && x.color == Color.Black)
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

        x.color = Color.Black;
    }

    void RBTransplant(Node<T> u, Node<T> v)
    {
        if (u.Parent == NIL)
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

        v.Parent = u.Parent;
    }

    public void RBInsertion(int key)
    {
        Node<T> z = new Node<T>(key);
        z.Parent = NIL;
        z.Left = NIL;
        z.Right = NIL;

        Node<T> y = NIL;
        Node<T> x = root;

        while (x != NIL)
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

        if (y == NIL)
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

        z.Left = NIL;
        z.Right = NIL;

        RBInsertFixUp(z);
    }

    void RBInsertFixUp(Node<T> z)
    {
        Node<T> y = NIL;

        while (z.Parent.color == Color.Red)
        {
            if (z.Parent == z.Parent.Parent.Left)
            {
                y = z.Parent.Parent.Right;

                if (y.color == Color.Red)
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

                if (y.color == Color.Red)
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

    void LeftRotate(Node<T> x)
    {
        Node<T> y = x.Right;
        x.Right = y.Left;

        if (y.Left != NIL)
        {
            y.Left.Parent = x;
        }

        y.Parent = x.Parent;

        if (x.Parent == NIL)
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

    void RightRotate(Node<T> y)
    {
        Node<T> x = y.Left;
        y.Left = x.Right;

        if (x.Right != NIL)
        {
            x.Right.Parent = y;
        }

        x.Parent = y.Parent;

        if (y.Parent == NIL)
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

    Node<T> TreeMinimum(Node<T> x)
    {
        while (x.Left != NIL)
        {
            x = x.Left;
        }

        return x;
    }

    Node<T> TreeMaximum(Node<T> x)
    {
        while (x.Right != NIL)
        {
            x = x.Right;
        }

        return x;
    }
}
