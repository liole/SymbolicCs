# Symbolic C#
Library for symbolic computations in C# code

## Usage
For main functionality you need to add these usings to the preambule of your source file
```cs
using Symbolic;
using Symbolic.Expressions; // for e.g. Symbol or Cos
using Symbolic.Operations;  // for e.g. Simplify or Replace
```
It is prefered to import required functions into global namesapce with
```cs
using static Symbolic._;
```
Otherwise, use prefix ```_.``` before every command.

## Examples
* Symbolic variable, string representation
  ```cs
  var x = new Symbol("x");
  var res = x+2;
  Console.WrileLine(res.ToString()) // x+2
  ```
  
  *Comments, from now on, will represent the output of ToString()*
  
* Symbolic function (use square brackets to pass arguments)
  ```cs
  var x = new Symbol("x");
  var f = new SymbolFunction("f");
  var res = f[2*x]; // f[2*x]
  ```
* Find derivative (D)
  * Direct expressions
    ```cs
    var x = new Symbol("x");
    var res = D(Sqrt(2 - x)); // -1/(2*sqrt[2-x])
    ```
  * Containing symbolic functions
    ```cs
    var x = new Symbol("x");
    var f = new SymbolFunction("f");
    var res = D(Sin(f[2*x])); // 2*cos[f[2*x]]*f'[2*x]
    ```
* Do replacements (use ```>>``` to precify a rule)
  ```cs
  var x = new Symbol("x");
  var f = new SymbolFunction("f");
  var exp = Sin(f[2*x]) + Cos(f[x]);
  ```
  * Exact matches
    ```cs
    var res = exp.Replace(x >> x + 2); // sin[f[2*(x+2)]]+cos[f[x+2]]
    ```
  * With pattern matches (use tilde ```~``` as wildcard followed by its label)
    ```cs
    var res = exp.Replace(f[~x] >> x + 2); // sin[2*x+2]+cos[x+2]
    ```
    *Be carefull, without wildcard, replacement will be made only for exact matches*
    ```cs
    var res = exp.Replace(f[x] >> x + 2); // sin[f[2*x]]+cos[x+2]
    ```
* Simplification (quite limited for now)
  ```cs
  var x = new Symbol("x");
  var exp = Pow(x, x - x);
  var res = exp.Simplify(); // 1
  ```
* *For full range of examples see Unit tests*
