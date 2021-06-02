using System;

namespace Buckets.Models
{
    public sealed class Bucket : Container
    {
        private Bucket(int capacity, int content) : base(capacity, content) { }

        public static Bucket CreateDefault(int capacity = 12, int content = 0) {
            return Create(capacity, content);
        }

        private static Bucket Create(int capacity, int content) {
            if (capacity < 10 || capacity > 12) {
                throw new ArgumentOutOfRangeException("max", $"bucket minimum: 10, maximum: 12\n");
            }

            return new Bucket(capacity, content);
        }
    }
}
