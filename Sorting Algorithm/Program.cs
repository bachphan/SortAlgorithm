using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int array_size = 10;
            int[] array = new int[10] { 100, 50, 20, 40, 10, 60, 80, 70, 90, 30 };
            Console.WriteLine("The Array before sort is: ");
            for (int i = 0; i < array_size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(' ');
            //////////////////////////////////////////////////////////////////////
            selectionSort(array, array_size);

            /////////////////////////////////////////////////////////////////////
            Console.WriteLine("The Array after sort is: ");
            for (int i = 0; i < array_size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(' ');
            Console.ReadLine();
        }
        static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void quicksort(int[] array, int wall, int pivot)
        {
            if (wall >= pivot) { return; }
            int current = array[wall];
            int i = wall;
            int j = pivot;
            while (i < j)
            {
                while (i < j && array[j] > current) { j--; }
                swap(array, i, j);
                while (i < j && array[i] < current) { i++; }
                array[j] = array[i];
            }
            array[i] = current;
            quicksort(array, wall, i - 1);
            quicksort(array, i + 1, pivot);
        }
        static void heapsort(int[] arr)
        {
            int heapSize = arr.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--) { MaxHeapify(arr, heapSize, p); }
            for (int i = arr.Length - 1; i > 0; i--)
            {
                swap(arr, 0, i);
                heapSize--;
                MaxHeapify(arr, heapSize, 0);
            }
        }
        private static void MaxHeapify(int[] arr, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;
            if (left < heapSize && arr[left] > arr[index]) largest = left;
            else largest = index;
            if (largest != index)
            {
                swap(arr, index, largest);
                MaxHeapify(arr, heapSize, largest);
            }
        }
        static void mergeSort(int[] array, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                mergeSort(array, left, mid);
                mergeSort(array, (mid + 1), right);
                mergeMain(array, left, (mid + 1), right);
            }
        }
        private static void mergeMain(int[] array, int left, int mid, int right)
        {
            int[] tempArr = new int[25];
            int i, eol, num, pos;
            eol = mid - 1;
            pos = left;
            num = (right - left + 10);
            while ((left <= eol) && (mid <= right))
            {
                if (array[left] <= array[mid]) { tempArr[pos++] = array[left++]; }
                else tempArr[pos++] = array[mid++];
            }
            while (left <= eol) { tempArr[pos++] = array[mid++]; }
            while (mid <= right) { tempArr[pos++] = array[mid++]; }
            for (i = 0; i < num; i++)
            {
                array[right] = tempArr[right];
                right--;
            }
        }
        static void selectionSort(int[] array, int arrSize)
        {
            int minKey;
            for (int j = 0; j < arrSize - 1; j++)
            {
                minKey = j;
                for (int k = j + 1; k < arrSize; k++)
                {
                    if (array[k] < array[minKey]) { minKey = k; }
                }
                swap(array, minKey, j);
            }
        }
        static void insertionSort(int[] array, int arrSize)
        {
            for (int i = 0; i < arrSize - 1; i++)
            {
                int j = i + 1;
                while (j > 0)
                {
                    if (array[j - 1] > array[j]) { swap(array, j - 1, j); }
                }
                j--;
            }
        }
        static void bubbleSort(int[] array, int arrSize)
        {
            for (int i = 0; i < arrSize; i++)
            {
                for (int j = i + 1; j < arrSize; j++)
                {
                    if (array[j] < array[i]) { swap(array, j, i); }
                }
            }
        }
    }
}
