from MarkdownPP.main import main
import markdown
import sys

sys.argv = ["compile.py", "index.md", "-o", "build/README.md"]

main()
