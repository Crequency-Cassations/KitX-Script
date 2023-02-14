//=================================//
// Kscript Demo - Remote Functions //
//=================================//

using Kscript;

//  know we have a function `add` in plugin `Add` on device `A`

//  define device A through `Kscript.Devices.Find` function
//  if KitX found no this device, it will throw an error

var A = Devices.Find("DESKTOP-MAIN", "049226CDA4FE");

//  call remote device's plugin's function to get result

var result = A.Add.add(1, 2);

Print(result);  //  3

