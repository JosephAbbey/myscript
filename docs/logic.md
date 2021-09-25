# Understanding how computers read/run code

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

## Lexing

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

## Parsing

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

## Visiting

A visitor can do many things, like:

- Interpreting, this is where the visitor runs the code as it is visiting each node (e.g. Python, JavaScript, etc.).
- Compiling, this is where the visitor generates assembly (native machine code, and web assembly) or bytecode (like a .jar file in java).
- Transpiling, this is where the visitor generates code in a different language (e.g. Python -> JavaScript (brython), TypeScript -> JavaScript, CoffeeScript -> JavaScript, etc.), usually used to make code run on the web.
- Prettifying, this is where the visitor generates nice looking code from the AST (minifying is the sane just generates minified code).
