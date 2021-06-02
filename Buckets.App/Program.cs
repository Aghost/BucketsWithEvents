using System;
using static System.Console;
using Buckets.Models;
using static Buckets.Models.ContainerFactory;

namespace Buckets.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Bucket newb = (Bucket)AddContainer(ContainerType.Bucket, 12, 12);
            Bucket newb2 = (Bucket)AddContainer(ContainerType.Bucket, 10);

            RainBarrel newrb = (RainBarrel)AddContainer(ContainerType.RainBarrel);
            RainBarrel newrb2 = (RainBarrel)AddContainer(ContainerType.RainBarrel, 100, 99);

            OilBarrel newob = (OilBarrel)AddContainer(ContainerType.OilBarrel);

            newb.SubscribeToEvents();
            newob.SubscribeToEvents();

            //newb.Content = 10;

            WriteLine($"{newb.Capacity} {newb.Content}");
            WriteLine($"{newb2.Capacity} {newb2.Content}");

            WriteLine($"{newrb.Capacity} {newrb.Content}");
            WriteLine($"{newrb2.Capacity} {newrb2.Content}");

            WriteLine($"{newob.Capacity} {newob.Content}");

            //AddContainer(ContainerType.RainBarrel);
            //AddContainer(ContainerType.OilBarrel);
        }
    }
}
