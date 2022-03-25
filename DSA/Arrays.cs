using System;
public class Arrays{
    private void PrintElements(int[] arr, int count)
    {
        int k=0;
        while(k<count)
        {
            Console.WriteLine(arr[k]);
            k++;
        }
    }
    public void selectionSort(int[] arr, int count)
    {
        //Gives the smallest element in the array in the first pass
        for(int i=0;i<count-1;i++)
        {
            int min=i;
            for(int j=i+1;j<count;j++)
            {
                if(arr[j]<arr[min])
                {
                    min=j;
                }
            }
            if(i!=min)
            {
                int temp=arr[i];
                arr[i]=arr[min];
                arr[min]=temp;
            }
        }
        PrintElements(arr, count);      
    }
    public void bubbleSort(int []arr, int count)
    {
        //Gives the largest element in the array in the first pass
        for(int i=0;i<count-1;i++)
        {
            for(int j=0;j<count-1-i;j++)
            {
                if(arr[j]>arr[j+1])
                {
                    int temp=arr[j+1];
                    arr[j+1]=arr[j];
                    arr[j]=temp;
                }
            }
        }
        PrintElements(arr, count);
    }
    public void insertionSort(int []arr, int count)
    {
       for(int i=1;i<count;i++)
       {
           int temp=arr[i];
           int j=i-1;
           while(j>=0 && arr[j]>temp)
           {
               arr[j+1]=arr[j];
               j--;
           }
           arr[j+1]=temp;
       }
        PrintElements(arr, count);
    }
    public static void Main(String[] args)
    {
        Arrays array=new Arrays();
        int []arr={3,5,2,6,8,1,9,13,16,0};
        int count=arr.Length;
        //array.selectionSort(arr, count);
        //array.bubbleSort(arr, count);
        array.insertionSort(arr, count);
        Console.ReadLine();
    }
}