# Usage

Arithm can be used both for developers and users

## Developers

To interpretate your code, at first you need to create an abstract sytax tree by using the following function
#
 	Main.parse <string of code>
Then you can run the 
#
	Interpreter.run <ast> 
funtion that returns three dictionaries. The first contains values of all variables in `AST.Expression` format,the second contains variables in `string` format, the third has only one key - `"print"` with string of result of interpretation.
You can also get a dot file which contains a syntax tree by using
# 
	DrawTree.drawTree <ast> <output file path>

Example:
#
	let x = "let x = 5 print x"
	let ast = parse x
	let _, _, pDict = Interpreter.run ast
	printfn "%s" pDict.["print"]
Given code prints "5" into console

## Users

There are only four console commands in Arithm

* `--inputfile <file path>` - enter a file with code
* `--inputstring <string>` - enter a string with code
* `--compute` - return the result of interpretation of the code
* `--todot <file path>` - return dot code of syntax tree to the given file
	
Just run "Arithm.exe" from console with given commands