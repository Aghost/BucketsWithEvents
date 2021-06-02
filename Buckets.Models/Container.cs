using System;

namespace Buckets.Models
{
    public abstract class Container
    {
        private readonly int _Capacity;
        private int _Content;

        public event EventHandler<int> OnReachCapacity;
        public event EventHandler<int> OnOverflowing;
        public event EventHandler<int> OnAmountChanged;

        protected Container(int capacity, int content) {
            if (content < 0) {
                throw new ArgumentOutOfRangeException("content", "content below 0");
            }
            if (content > capacity ) {
                throw new ArgumentOutOfRangeException("content", "content above capacity");
            }

            _Capacity = capacity;
            Content = content;
        }

        public int Capacity {
            get => this._Capacity;
            //set => this._Capacity = value;
        }
        public int Content {
            get => this._Content;
            set {
                switch (value) {
                    case int i when (i <= 0):
                        break;
                    case int i when (i + Content <= _Capacity): // When not overflowing
                        this._Content = value;
                        this.OnAmountChanged?.Invoke(this, value);
                        break;
                    case int i when (i + Content >= _Capacity):  // overflowing
                        this.OnReachCapacity?.Invoke(this, value);
                        if ((i + Content) > Capacity) {
                            this.OnOverflowing?.Invoke(this, value);
                        } else {
                            this._Content = value;
                        }
                        /*
                        */
                        break;
                    default: break;
                }
            }
        }

        public bool Fill(int amount) {
            if ((amount + Content) < Capacity) {
                Content += amount;
            } else {
                //Raiseoverflow event?
                return false;
            }

            return true;
        }

        public void SubscribeToEvents() {
            this.OnReachCapacity += ContainerEvents.ContainerReachCapacity;
            this.OnOverflowing += ContainerEvents.ContainerOverflowing;
            this.OnAmountChanged += ContainerEvents.ContainerAmountChanged;
        }

        public void Fill(int amount, Container container) {
            Content += amount;
        }

        public void Empty() {
            Content = 0;
        }

    }
}
