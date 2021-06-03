using System;

namespace Buckets.Models
{
    public class ContainerFactory
    {
        public static Container AddContainer(Enum type, int capacity = -1, int content = -1)
        {
            // het is niet mooi, maar het was wel leerzaam en weinig lines of code
            switch (type) {
                case ContainerType.Bucket:
                    if (content == -1 && capacity == -1)
                        return Bucket.CreateDefault();
                    else if (content != -1)
                        return Bucket.CreateDefault(capacity, content);
                    else if (capacity != -1)
                        return Bucket.CreateDefault(capacity);
                    else
                        throw new ArgumentException("ContainerFactory Bucket Argument Exception\n");
                case ContainerType.RainBarrel:
                    return capacity switch {
                        int n when (n < 1) => RainBarrel.CreateDefault(),
                        int n when (n > 0) => (content > -1) ? RainBarrel.CreateDefault(capacity, content) : RainBarrel.CreateDefault(content),
                        _ => throw new ArgumentException("ContainerFactory RainBarrel Argument Exception\n")
                    };
                case ContainerType.OilBarrel:
                    return (capacity > 0) ? OilBarrel.CreateDefault(capacity) : OilBarrel.CreateDefault();
                default:
                    throw new ArgumentException("ContainerFactory Switch is all out of options\n");
            }
        }
    }
}
