using System;

namespace Buckets.Models
{
    public sealed class RainBarrel : Container
    {
        private RainBarrel(int capacity, int content) : base(capacity, content) { }

        public static RainBarrel CreateDefault(int capacity = 100, int content = 0) {
            return capacity switch {
                int n when (n < 100) => Create(80, content),
                int n when (n < 120) => Create(100, content),
                int n when (n > 119) => Create(120, content),
                _ => Create(100, content)
            };
        }

        private static RainBarrel Create(int capacity, int content) {
            return new RainBarrel(capacity, content);
        }
    }
}
