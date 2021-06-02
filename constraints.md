##
- containers
    - buckets
    - rainbarrels
    - oilbarrels

0. Container():
    constructors:
    create(int amount, int capacity)

    methods:
    fill(int amount)

    events:
    isfull 
    isoverflown(ing) (if overflowing)

1. Bucket(int capacity >= 10, <= 12):
    create(int amount = 12)

    fill(int amount)
    fill(Container container)
    empty()

2. Rainbarrel():
    create(int type = medium(100))
    create(80 or 100 or 120)

3. OilBarrel():
    create();

