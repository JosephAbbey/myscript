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
