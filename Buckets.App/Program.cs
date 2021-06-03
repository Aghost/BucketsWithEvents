using System;
using Buckets.Models;

using static System.Console;
using static Buckets.Models.ContainerFactory;

namespace Buckets.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Demonstratie van ContainerFactory
            // newb = new barrel,
            // newrb2 = new rainbarrel-2
            Bucket newb = (Bucket)AddContainer(ContainerType.Bucket, 12, 12);
            Bucket newb2 = (Bucket)AddContainer(ContainerType.Bucket, 10, 9);

            RainBarrel newrb = (RainBarrel)AddContainer(ContainerType.RainBarrel);
            RainBarrel newrb2 = (RainBarrel)AddContainer(ContainerType.RainBarrel, 100, 99);

            OilBarrel newob = (OilBarrel)AddContainer(ContainerType.OilBarrel);
            OilBarrel newob2 = (OilBarrel)AddContainer(ContainerType.OilBarrel, 100);

            // Subscribe containers to events
            newb.SubscribeToEvents();
            newb2.SubscribeToEvents();
            newob.SubscribeToEvents();
            newrb.SubscribeToEvents();

            // new functionality test
            WriteLine($"---\n{newb2.Capacity} {newb2.Content}");
            WriteLine(newb2.Fill(2) ? "Success" : "Fail");
            WriteLine($"{newb2.Capacity} {newb2.Content}\n---\n");

            // for loop test
            int stepsize = 10;
            WriteLine($"container-content: {newrb.Content}, stepsize ={stepsize}\nPress any key to start...");
            ReadLine();
            for (int i = 1; i <= 100; i++) {
                WriteLine(newrb.Content);
                if (!newrb.Fill(stepsize)) {
                    WriteLine($"stopped at: {i}");
                    break;
                }
                //WriteLine(newrb.Fill(i) ? $"yes{i}" : $"no{i}");
            }
            newrb.Fill(1);
            WriteLine($"--- container-content: {newrb.Content}\n");
            ReadLine();

            // all container values
            WriteLine("All container values:"); 
            WriteLine($"{newb.Capacity} {newb.Content}");
            WriteLine($"{newb2.Capacity} {newb2.Content}");

            WriteLine($"{newrb.Capacity} {newrb.Content}");
            WriteLine($"{newrb2.Capacity} {newrb2.Content}");

            WriteLine($"{newob.Capacity} {newob.Content}");
            WriteLine($"{newob2.Capacity} {newob2.Content}");

            // Dit werkt ook nog steeds
            //AddContainer(ContainerType.RainBarrel);
            //AddContainer(ContainerType.OilBarrel);
        }
    }
}
