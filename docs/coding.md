# Coding

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

## The syntax

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

## Lexer

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
