﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HRRN
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, k, count,max,n,RR;

            Console.WriteLine("HRRN");
            Console.WriteLine();
            Console.WriteLine("Enter the total no. of process :");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine();

            int[] cTime = new int[n];
            int[] wTime = new int[n];
            int[] bTime = new int[n];
            int[] TATime = new int[n];
            int[] aTime = new int[n];
            int[] pId = new int[n];
            int[] check = new int[n];

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

            for (i = 0; i < n; i++)
            {
                check[i] = 0;
            }

            // completion time
            count = 0;
            j = 0;
            while (j < n)
            {
                max = 0;
                k = -1;
                for (i = 0; i < n; i++)
                {
                    RR = (count - aTime[i] + bTime[i]) / bTime[i];
                    if (RR == max)
                    {
                        if (aTime[i] < aTime[k])
                        {
                            k = i;
                        }
                    }

                    if (RR > max)
                    {
                        if (aTime[i] <= count && check[i]==0)
                        {
                            max = RR;
                            k = i;
                        }
                    }
                }

                if (k != -1)
                {
                    cTime[k] = bTime[k] + count;
                    count += bTime[k];
                    j++;
                    check[k] = 1;
                }
                else
                {
                    count += 1;
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

            Console.WriteLine("Process" + "  " + "Completion time" + "  " + "Arrival time" + "  " + "Burst time" + "  " + "Turn around time" + "  " + "Waiting time");
            Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                Console.WriteLine("P" + pId[i] + "\t    " + cTime[i] + "\t\t     " + aTime[i] + "\t\t   " + bTime[i] + "\t\t" + TATime[i] + "\t\t" + wTime[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Average waiting time: " + avgWT);
            Console.WriteLine("Average turn around time: " + avgTAT);
        }
    }
}
