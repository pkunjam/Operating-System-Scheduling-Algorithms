using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Preemptive_
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, count, n, len = 0, dec, choice, prev;

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
            int[] pR = new int[n];
            int[] PR = new int[n];

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

            Console.WriteLine("Priority: ");
            for (i = 0; i < n; i++)
            {
                PR[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            for (i = 0; i < n; i++)
            {
                testBT[i] = bTime[i];
                pR[i] = PR[i];
                rTime[i] = -1;
            }

            // completion time
            count = 0;
            dec = 0;
            j = 0;
            prev = -1;

            Console.WriteLine("1.Lowest number highest priority ");
            Console.WriteLine("2.Lowest number lowest priority ");
            Console.WriteLine();
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    while (j < n)
                    {
                        int min = 1000, ind = -1;
                        for (i = 0; i < n; i++)
                        {
                            if (pR[i] == min && testBT[i] > 0)
                            {
                                if (aTime[i] < aTime[ind])
                                    ind = i;
                            }

                            else if (pR[i] < min && testBT[i] > 0)
                            {
                                if (aTime[i] <= count)
                                {
                                    min = pR[i];
                                    ind = i;
                                }
                            }

                        }

                        if (ind != -1)
                        {
                            testBT[ind] -= 1;
                        }
                        else
                        {
                            dec = 1;
                        }

                        if (ind != prev && rTime[ind] == -1)
                            rTime[ind] = count - aTime[ind];

                        count++;

                        if (testBT[ind] == 0 && ind != -1)
                        {
                            cTime[ind] = count;
                            j++;
                            dec = 0;
                        }
                        prev = ind;
                    }
                    break;
                case 2:
                    while (j < n)
                    {
                        int max = -10, ind = -1;
                        for (i = 0; i < n; i++)
                        {
                            if (pR[i] == max && testBT[i] > 0)
                            {
                                if (aTime[i] < aTime[ind])
                                    ind = i;
                            }

                            else if (pR[i] > max && testBT[i] > 0)
                            {
                                if (aTime[i] <= count)
                                {
                                    max = pR[i];
                                    ind = i;
                                }
                            }

                        }

                        if (ind != -1)
                        {
                            testBT[ind] -= 1;
                        }
                        else
                        {
                            dec = 1;
                        }


                        if (ind != prev && rTime[ind] == -1)
                            rTime[ind] = count - aTime[ind];

                        count++;

                        if (testBT[ind] == 0 && ind != -1)
                        {
                            cTime[ind] = count;
                            j++;
                            dec = 0;
                        }
                        prev = ind;
                    }
                    break;
                default:
                    Console.WriteLine("wrong choice");
                    break;
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
