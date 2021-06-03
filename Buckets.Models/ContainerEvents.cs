using System;
using static System.Console;

namespace Buckets.Models
{
    public class ContainerEvents
    {
        public static void ContainerReachCapacity(object sender, int e) {
            var container = (Container)sender;
            WriteLine($"[reached-capacity-event]{container.Content}, {e}");
        }

        public static void ContainerOverflowing(object sender, int e) {
            var container = (Container)sender;
            WriteLine($"[overflow-event]{container.Content}, {e}");
        }

        public static void ContainerAmountChanged(object sender, int e) {
            var container = (Container)sender;
            WriteLine($"[amount-changed-event]{container.Content}, +{e}");
        }
    }
}
