//==========================//
// Kscript Demo - Functions //
//==========================//

using Kscript;

//  an function needs a return type, a name

void foo1(){

}

//  to pass a set of parameters, use the following syntax
//  when writing parameters, you need to give specific types

void add(int a, int b){
    return a + b;
}

//  when your function only have one line of code,
//  you can use the following syntax (lambda expression)

void minus(int a, int b) => a - b;


//  to call functions

var result = add(1, 2);

Print(result);  //  3



