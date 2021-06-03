using System;

namespace Buckets.Models
{
    public sealed class OilBarrel : Container
    {
        private OilBarrel(int capacity, int content) : base(capacity, content) { }

        public static OilBarrel CreateDefault(int content = 0) {
            return new OilBarrel(159, content);
        }
    }
}
