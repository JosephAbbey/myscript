from MarkdownPP.main import main
import markdown
import sys

sys.argv = ["compile.py", "main.md", "-o", "README.md"]

main()
