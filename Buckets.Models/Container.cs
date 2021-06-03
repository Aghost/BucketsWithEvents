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
                    case int i when (i < _Capacity): // When not overflowing
                        _Content = value;
                        OnAmountChanged?.Invoke(this, value);
                        break;
                    case int i when (i >= _Capacity):  // overflowing
                        OnReachCapacity?.Invoke(this, value);
                        if (i > Capacity) {
                            OnOverflowing?.Invoke(this, value);
                        } else {
                            _Content = value;
                            OnAmountChanged?.Invoke(this, value);
                        }
                        break;
                    default: break;
                }
            }
        }

        public bool Fill(int amount) {
            switch (amount) {
                case int i when (i <= 0):
                    return false;
                case int i when (i + Content < _Capacity): // When not overflowing
                    _Content += amount;
                    this.OnAmountChanged?.Invoke(this, amount);
                    return true;
                case int i when (i + Content >= _Capacity):  // overflowing
                    this.OnReachCapacity?.Invoke(this, amount);
                    if (i + Content > Capacity) {
                        //TODO: if overflowing, OnCustomEvent etc..
                        this.OnOverflowing?.Invoke(this, amount);
                        return false;
                    } else {
                        _Content += amount;
                        this.OnAmountChanged?.Invoke(this, amount);
                        return false;
                    }
                default: return false;
            }
        }

        public void Fill(int amount, Container container) {
            Content += amount;
        }


        public void SubscribeToEvents() {
            this.OnReachCapacity += ContainerEvents.ContainerReachCapacity;
            this.OnOverflowing += ContainerEvents.ContainerOverflowing;
            this.OnAmountChanged += ContainerEvents.ContainerAmountChanged;
        }

        public void Empty() {
            Content = 0;
        }

    }
}
