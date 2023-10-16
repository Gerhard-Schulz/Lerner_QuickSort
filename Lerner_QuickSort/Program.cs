Console.Write("Введите размерность массива: ");
int n =int.Parse(Console.ReadLine());
int[] array = new int[n];
Console.WriteLine("Исходный массив:\n{0}", string.Join(", ", GiveValuesToArray(array)));
Sort(array);
Console.WriteLine("\nУпорядоченный массив:\n{0}", string.Join(", ", array));

static void Sort(int[] array)
{
    QuickSort(array, 0, array.Length - 1);
}

static void QuickSort(int[] array, int low, int high)
{
    if (low < high)
    {
        int pivotIndex = GenerateRandomPivot(low, high);
        int pivotValue = array[pivotIndex];
        Swap(array, pivotIndex, high);
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (array[j] < pivotValue)
            {
                i++;
                Swap(array, i, j);
            }
        }
        Swap(array, i + 1, high);
        QuickSort(array, low, i);
        QuickSort(array, i + 2, high);
    }
}

static int GenerateRandomPivot(int low, int high)
{
    Random random = new Random();
    return low + random.Next(high - low + 1);
}

static int[] GiveValuesToArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = i;
    }
    ShuffleArray(array);
    return array;
}

static void ShuffleArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Random random = new Random();
        int index = random.Next(i + 1);
        int temp = array[i];
        array[i] = array[index];
        array[index] = temp;
    }
}

static void Swap(int[] arr, int i, int j)
{
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
}

//static int Partition(int[] array, int minIndex, int maxIndex)
//{
//    var pivot = minIndex - 1;
//    for (var i = minIndex; i < maxIndex; i++)
//    {
//        if (array[i] < array[maxIndex])
//        {
//            pivot++;
//            Swap(ref array[pivot], ref array[i]);
//        }
//    }
//    pivot++;
//    Swap(ref array[pivot], ref array[maxIndex]);
//    return pivot;
//}

//static int[] QuickSort(int[] array, int minIndex, int maxIndex)
//{
//    if (minIndex >= maxIndex)
//    {
//        return array;
//    }
//    var pivotIndex = Partition(array, minIndex, maxIndex);
//    QuickSort(array, minIndex, pivotIndex - 1);
//    QuickSort(array, pivotIndex + 1, maxIndex);
//    return array;
//}

//static void Swap(ref int x, ref int y)
//{
//    int temp = x;
//    x = y;
//    y = temp;
//}