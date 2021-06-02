using System;
using static System.Console;

namespace Buckets.Models
{
    public class ContainerEvents
    {
        public static void ContainerReachCapacity(object sender, int e) {
            var container = (Container)sender;
            WriteLine($"{container.Content} reached capacity event {e}");
        }

        public static void ContainerOverflowing(object sender, int e) {
            var container = (Container)sender;
            WriteLine($"{container.Content} overflowing event {e}");
        }

        public static void ContainerAmountChanged(object sender, int e) {
            var container = (Container)sender;
            WriteLine($"{container.Content} amount changed event, {e}");
        }
    }
}
