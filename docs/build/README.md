# Writing a language

1\.  [Understanding how computers read/run code](#understandinghowcomputersread/runcode)  
1.1\.  [Lexing](#lexing)  
1.2\.  [Parsing](#parsing)  
1.3\.  [Visiting](#visiting)  
2\.  [Coding](#coding)  
2.1\.  [The syntax](#thesyntax)  
2.2\.  [Lexer](#lexer)  

<a name="understandinghowcomputersread/runcode"></a>

## 1\. Understanding how computers read/run code

When a computer reads/runs code there are 3 major steps:

- Lexing
- Parsing
- Visiting:
  - Interpreting
  - Compiling
  - Transpiling (similar to compiling)
  - Prettifying

I should mention that I am writing about a programming language not a markup language but for a markup language it would be pretty similar just for the visiting step it would compile to a string (e.g. markdown) or produce an object (e.g. XML, YML, JSON, etc.).

Here is some example js code, I will be using it throughout this section:

```js
function main() {
  console.log("hello world");
}

main();
```

<a name="lexing"></a>

### 1.1\. Lexing

A lexer scans through the code really quickly, classifying it into tokens that a computer can understand more easily. In this example the first token would be something like:

```json
{
  "type": "function",
  "value": "function",
  "position": { "line": 0, "char": 0 }
}
```

then:

```json
{
  "type": "string",
  "value": "main",
  "position": { "line": 0, "char": 10 }
}
```

<a name="parsing"></a>

### 1.2\. Parsing

A parser groups the token stream into a tree structure known as an AST (or Abstract Syntax tree). In this example we might end up with something like this:

```json
{
  "type": "code",
  "children": [
    {
      "type": "function_definition",
      "children": [
        {
          "type": "name",
          "node": {
            "type": "string",
            "value": "main",
            "position": { "line": 0, "char": 10 }
          }
        },
        {
          "type": "parameters",
          "children": []
        },
        {
          "type": "code",
          "children": [
            {
              "type": "function_call",
              "children": [
                {
                  "type": "function_name",
                  "children": [
                    {
                      "type": "name",
                      "node": {
                        "type": "string",
                        "value": "console",
                        "position": { "line": 1, "char": 3 }
                      }
                    },
                    {
                      "type": "dot",
                      "node": {
                        "type": "dot",
                        "value": ".",
                        "position": { "line": 1, "char": 10 }
                      }
                    },
                    {
                      "type": "name",
                      "node": {
                        "type": "string",
                        "value": "console",
                        "position": { "line": 1, "char": 11 }
                      }
                    },
                    ...
                  ]
                }
              ]
            }
          ]
        }
      ]
    },
    ...
  ]
}
```

As you can see it is basically just a tree represented as an object (json in this case).

<a name="visiting"></a>

### 1.3\. Visiting

A visitor can do many things, like:

- Interpreting, this is where the visitor runs the code as it is visiting each node (e.g. Python, JavaScript, etc.).
- Compiling, this is where the visitor generates assembly (native machine code, and web assembly) or bytecode (like a .jar file in java).
- Transpiling, this is where the visitor generates code in a different language (e.g. Python -> JavaScript (brython), TypeScript -> JavaScript, CoffeeScript -> JavaScript, etc.), usually used to make code run on the web.
- Prettifying, this is where the visitor generates nice looking code from the AST (minifying is the sane just generates minified code).
<a name="coding"></a>

## 2\. Coding

I will make:

- An interpreter
- A transpiler (myscript -> python) with the same syntax
- A prettifier for the syntax

Now with the logic out of the way time to start coding! I will be writing it in csharp (a language written by microsoft dotnet) but I will be explaining as I go along so it should be simple enough for developers in other languages to follow along too.

Here is my code for the cli:

```csharp
using System;
using System.IO;

namespace myscript
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: myscript <function> <file>");
                return;
            }

            if (args.Length < 2)
            {
                string code = File.ReadAllText(args[0]);
                Lexer lexer = new Lexer(code);
                Parser parser = new Parser(lexer);
                Interpreter interpreter = new Interpreter(parser);

                interpreter.interpret();
            }
            else
            {
                string code = File.ReadAllText(args[0]);
                if (args[0] == "interpret")
                {
                    Lexer lexer = new Lexer(code);
                    Parser parser = new Parser(lexer);
                    Interpreter interpreter = new Interpreter(parser);

                    interpreter.interpret();
                }
                else if (args[0] == "transpile")
                {
                    Lexer lexer = new Lexer(code);
                    Parser parser = new Parser(lexer);
                    Transpiler transpiler = new Transpiler(parser);

                    transpiler.transpile();
                }
                else if (args[0] == "prettify")
                {
                    Lexer lexer = new Lexer(code);
                    Parser parser = new Parser(lexer);
                    Prettifier prettifier = new Prettifier(parser);

                    prettifier.prettify();
                }
            }
        }
    }
}
```

<a name="thesyntax"></a>

### 2.1\. The syntax

A syntax is the structure of the code.

Here is an example of some myscript:

<!---
I use js hear because it is close enough to the syntax of myscript to not matter.
-->

```js
age = console.input("age: ");
if (age < 13) {
    console.log("You are a child");
} else if (age < 18) {
    console.log("You are a Teenager");
} else {
    console.log("You are an adult");
}
```

For the example I will keep it simple, here is a list of features:

- variables
- if/else/else if
- add/subtract/multiply/divide/compare/and/or
- function call (no definitions or scope, too complicated for this post but I will cover them in a follow up post)
- console

<a name="lexer"></a>

### 2.2\. Lexer

I will start with the lexer as it is needed for the other steps.

The Lexer class takes 1 argument `string str`, this will contain the source code.

I also need an enum for the Tokens and a Token class.

```csharp
namespace myscript
{
    enum Tokens
    {

    }

    class Token
    {

    }

    class Lexer
    {
        string str;
        public Lexer(string str)
        {
            this.str = str;
        }
    }
}
```

<style>
    :root {
        scroll-behavior: smooth;
    }
</style>
