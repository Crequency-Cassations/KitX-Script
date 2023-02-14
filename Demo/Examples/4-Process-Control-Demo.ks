//================================//
// Kscript Demo - Process Control //
//================================//

var condition = true;

if (condition) {
    //  Do something.
}

if (condition) {
    //  Do something.
} else {
    //  Do something else.
}

if (condition) {
    //  Do something.
} else if (condition) {
    //  Do something else.
} else {
    //  Do something else.
}

if (condition) {
    //  Do something.
} else if (condition) {
    //  Do something else.
} else if (condition) {
    //  Do something else.
} else {
    //  Do something else.
}

var loopCount = 0;

while (condition) {
    //  Do something.

    //  If condition is false, break the loop.

    ++loopCount;

    //  loop 10 times and break the loop.
    //  and you also can use `break;` to break the loop.
    //  at everywhere inside the loop first layer,
    //  `continue;` can be used to skip current loop and continue on next loop.

    if (loopCount == 10)
        condition = false;
}

//  `for(;;)` syntax for loop

for (var i = 0; i < 10; ++i) {
    //  Do something.
}

//  `for(<e1>;<e2>;<e3>)`
//  in for styled loop, `<e1>` is executed before the loop starts.
//  `<e2>` defines the condition for running the loop
//  if it returns false, the loop will stop.
//  `<e3>` is executed each time after the loop code has been executed.

//  `foreach (var <item> in <list>)` syntax for loop

foreach (var i in [1, 2, 3, 4, 5]) {
    Print(i);
}

//  if `<list>` is type of `array`, `turple` or `string`,
//  `<item>` will be assigned to each element in `<list>`.



