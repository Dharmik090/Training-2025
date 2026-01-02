function method1(a)
{
    console.log("Method with one parameter called. a =", a);
    return 1;
}

function method1(a, b)
{
    console.log("Method with two parameters called. a =", a, ", b =", b);
    return 2;
}

method1(5);
method1(5, 10);