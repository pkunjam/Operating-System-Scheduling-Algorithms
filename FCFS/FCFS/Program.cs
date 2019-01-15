using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FCFS
{
    class Program
    {
        static void Main(string[] args)
        {
            int i,j,n;

            Console.WriteLine("Enter the total no. of process :");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine();

            int[] wTime = new int[n];
            int[] bTime = new int[n];
            int[] TATime = new int[n];
            int[] aTime = new int[n];
            int[] pId = new int[n];

            float avgWT = 0;
            float avgTAT = 0;

            Console.WriteLine("Enter the arrival time for corresponding processes :");
            Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                Console.Write("P" + (i + 1) + ": ");
                aTime[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            Console.WriteLine("Enter the burst time for corresponding processes :");
            Console.WriteLine();
            for (i = 0; i < n; i++)
            {
                Console.Write("P" + (i + 1) + ": ");
                bTime[i] = int.Parse(Console.ReadLine());
                pId[i] = i + 1;
            }

            Console.WriteLine();

            wTime[0] = 0;    //waiting time for first process is 0

            //calculating waiting time
            for (i = 1; i < n; i++)
            {
                wTime[i] = 0;
                for (j = 0; j < i; j++)
                    wTime[i] += bTime[j];
            }

            //calculating turnaround time
            for (i = 0; i < n; i++)
            {
                TATime[i] = bTime[i] + wTime[i];
                avgWT += wTime[i];
                avgTAT += TATime[i];
            }

            avgWT = avgWT / n;
            avgTAT = avgTAT / n;

            Console.WriteLine("Process" + "  " + "Arrival time" + "  " + "Burst time" + "  " + "Turn around time" + "  " + "Waiting time");
            Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                Console.WriteLine("P" + pId[i] + "\t     " + aTime[i] + "\t\t   " + bTime[i] + "\t\t" + TATime[i] + "\t\t" + wTime[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Average waiting time: " + avgWT);
            Console.WriteLine("Average turn around time: " + avgTAT);
        }
    }
}
