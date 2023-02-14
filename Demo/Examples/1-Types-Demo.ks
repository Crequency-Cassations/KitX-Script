//======================//
// Kscript Demo - Types //
//======================//

//  use `using` keyword to import a library.

using Kscript;

//  declare a variable with `var` key word, and assign a value to it.
//  any variable lives in `{}` and its sub `{}`.
//  kscript supports interger, double, string, boolean, array.
//  string quotes by two `"`, and boolean is `true` or `false`.

var Interger = 0;   //  64 bits interger type
var Double = 0.1;   //  64 bits float type
var String = "!";   //  string type
var Bool = false;   //  boolean type

var Array = [  ];   //  array type, if any elements type difference, error thrown.

var Turple = (Interger, Double);    //  turple type, support different types but specific order and count.

//  or you can also use type name to declare variable.

int     a = 0;
double  b = 0.1;
string  c = "!";
bool    d = false;

array   e = [  ];

turple  f = (a, b);

//  next, we use `Print` function to verify are them equals.
//  double `=` (`==`) means to check if two variables are equals.
//  one `=` only means to assign a value to a variable.

Print(Interger == a);   //  true
Print(Double == b);     //  true
Print(String == c);     //  true
Print(Bool == d);       //  true

Print(Array == e);      //  true
//  for array with no elements, it's always true.
//  two not empty same arrays must have same elements count and same elements order.

Print(Turple == f);     //  true
//  for turple with no elements, it's always true.
//  two not empty same turples must have same elements count and same elements order.
