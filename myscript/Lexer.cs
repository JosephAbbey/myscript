namespace myscript
{
    enum Tokens
    {

    }

    class Token
    {
        Tokens type;
        string text;
        float value;
        object pos;
        public Token(Tokens type, string text, object pos)
        {
            this.type = type;
            this.text = text;
            this.pos = pos;
        }
        public Token(Tokens type, string text, float value, object pos)
        {
            this.type = type;
            this.text = text;
            this.value = value;
            this.pos = pos;
        }
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