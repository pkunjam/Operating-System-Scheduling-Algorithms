using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Round_Robin
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, k, count, n, tq, len=0, front, rear, dec, found, ind;

            Console.WriteLine("Enter the total no. of process :");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine();

            int[] testBT = new int[n];
            int[] cTime = new int[n];
            int[] wTime = new int[n];
            int[] bTime = new int[n];
            int[] TATime = new int[n];
            int[] aTime = new int[n];
            int[] pId = new int[n];
            int[] rTime = new int[n];

            float avgWT = 0;
            float avgTAT = 0;

            Console.WriteLine("Enter the arrival time for corresponding processes :");
            Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                Console.Write("P" + (i + 1) + ": ");
                aTime[i] = int.Parse(Console.ReadLine());
                pId[i] = i + 1;
            }

            Console.WriteLine();

            Console.WriteLine("Enter the burst time for corresponding processes :");
            Console.WriteLine();
            for (i = 0; i < n; i++)
            {
                Console.Write("P" + (i + 1) + ": ");
                bTime[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();

            Console.WriteLine("Enter the time quanta: ");
            tq = int.Parse(Console.ReadLine());

            Console.WriteLine();
            for (i = 0; i < n; i++)
            {
                testBT[i] = bTime[i];
                len += bTime[i];
                rTime[i] = -1;
            }

            int[] ready = new int[len];

            // completion time
            count = 0;
            front = 0;
            rear = -1;
            dec = 0;
            j = 0;
            while (j < n)
            {
                found = 0;
                if (front > rear)
                {
                    for (i = 0; i < n; i++)
                    {
                        if (aTime[i] == count)
                        {
                            ready[++rear] = i;
                            found = 1;
                        }
                        if (found == 0)
                        {
                            if (dec == 0)
                            {
                                dec = 1;
                            }
                            count++;
                        }
                    }
                }
                else
                {
                    ind = ready[front++]; 
                    dec = 0;

                    if (rTime[ind] == -1)
                        rTime[ind] = count - aTime[ind];

                    if (testBT[ind] <= tq)
                    {
                        for (k = 0; k < testBT[ind]; k++)
                        {
                            count++;
                            for (i = 0; i < n; i++)
                            {
                                if (aTime[i] == count)
                                    ready[++rear] = i;
                            }
                        }
                        testBT[ind] = 0;
                        cTime[ind] = count;
                        j++;
                    }
                    else
                    {
                        for (k = 0; k < tq; k++)
                        {
                            count++;
                            for (i = 0; i < n; i++)
                            {
                                if (aTime[i] == count)
                                    ready[++rear] = i;
                            }
                        }
                        testBT[ind] -= tq;
                        ready[++rear] = ind;
                    }
                }
            }

            // turnaround time

            for (i = 0; i < n; i++)
            {
                TATime[i] = cTime[i] - aTime[i];
                avgTAT += TATime[i];
            }

            // waiting time

            for (i = 0; i < n; i++)
            {
                wTime[i] = TATime[i] - bTime[i];
                avgWT += wTime[i];
            }

            avgWT = avgWT / n;
            avgTAT = avgTAT / n;

            Console.WriteLine("Process" + "  " + "Completion time" + "  " + "Arrival time" + "  " + "Burst time" + "  " + "Turn around time" + "  " + "Waiting time" + "  " + "Response Time");
            Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                Console.WriteLine("P" + pId[i] + "\t    " + cTime[i] + "\t\t     " + aTime[i] + "\t\t   " + bTime[i] + "\t\t" + TATime[i] + "\t\t" + wTime[i] + "\t\t" + rTime[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Average waiting time: " + avgWT);
            Console.WriteLine("Average turn around time: " + avgTAT);
        }
    }
}
