class Matrix
{
    private int[,] elements;

    public Matrix(int rows, int columns)
    {
        elements = new int[rows, columns];
    }

    public int Rows
    {
        get { return elements.GetLength(0); }
    }

    public int Columns
    {
        get { return elements.GetLength(1); }
    }

    public int this[int row, int column]
    {
        get
        {
            if (row < 0 || row >= elements.GetLength(0) || column < 0 || column >= elements.GetLength(1))
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            return elements[row, column];
        }
        set
        {
            if (row < 0 || row >= elements.GetLength(0) || column < 0 || column >= elements.GetLength(1))
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            elements[row, column] = value;
        }
    }
}

class Program
{
    static void Main()
    {
        Matrix matrix = new Matrix(2, 3);

        matrix[0, 0] = 1;
        matrix[0, 1] = 2;
        matrix[0, 2] = 3;
        matrix[1, 0] = 4;
        matrix[1, 1] = 5;
        matrix[1, 2] = 6;

        Console.WriteLine(matrix[0, 1]);
    }
}
