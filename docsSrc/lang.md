# Language guide

RuFS uses simple programming language to define complex arithmetic expressions.

## Code structure

Each arithmetic expression is defined as variable which can be used in other expressions. Result of each expression can be printed in console

## Defining an expression

* Variables are declared by this construction 
#
	let <vname> = <expression>
* `<vname>` starts with a Latin character, which can be followed by numbers or other letters
* `<expression>` consists of numbers, other variables and arithmetic operators such as `+, -, *, /, %, ^, ~, (, ), |`

## Operators

* `+` - sum
* `-` - subtract; also acts as unary minus if immediatly followed by number
* `*` - multiply
* `/` - integer division
* `%` - remainder division
* `^` - power
* `~` - converts a number to its binary representation
* `(`, `)` - brackets to control operation priority
* `|` - acts as brackets while returning an absolute value of expression


## Functions

The only function supported in this language is 
#
	print <vname>
which prints a result of arithmetic expression corresponding to a given variable

## Code example

	let x = |12 - 7 * 8| / -3
	let y = 8 - x
	print y

* All code can be written in a single string

