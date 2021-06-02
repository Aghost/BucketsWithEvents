using System;
using Buckets.Models;
using Xunit;

namespace Buckets.Test
{
    public class BucketsTest
    {
        [Fact]
        public void BucketTest() {
            // Arrange
            Bucket[] buckets = new Bucket[] {
                Bucket.CreateDefault(),
                Bucket.CreateDefault(10),
                Bucket.CreateDefault(12, 10)
            };

            // Act
            int[] actual = new int[] {
                buckets[0].Capacity,
                buckets[1].Capacity,
                buckets[2].Capacity
            };
            int[] expected = new int[] { 12, 10, 12 };

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OilBarrelTest() {
            // Arrange
            OilBarrel[] oilBarrel = new OilBarrel[] {
                OilBarrel.CreateDefault(),
                OilBarrel.CreateDefault(159)
            };

            // Act
            int[] actual = new int[] {
                oilBarrel[0].Content,
                oilBarrel[1].Content
            };
            int[] expected = new int[] { 0, 159};

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RainBarrelTest() {
            // Arrange
            RainBarrel[] rainBarrel = new RainBarrel[] {
                RainBarrel.CreateDefault(99, 79),
                RainBarrel.CreateDefault(100, 99),
                RainBarrel.CreateDefault(130, 119),
                RainBarrel.CreateDefault(),
                RainBarrel.CreateDefault(0)
            };

            // Act
            int[] actual = new int[] {
                rainBarrel[0].Content,
                rainBarrel[1].Content,
                rainBarrel[2].Content,
                rainBarrel[3].Content,
                rainBarrel[4].Capacity
            };
            int[] expected = new int[] { 79, 99, 119, 0, 80};

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
