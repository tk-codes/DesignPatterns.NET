# Interpreter Pattern

Given a language, define a representation for its grammar along with an interpreter that users the representation to interpret sentences in the language.

## Problem

- Implementing many different search expressions directly into **one** class is inflexible because it is impossible to specify new expressions or change existing ones without having to change the class.
- A grammar for a simple language should be defined so that sentences in the language can be interpreted.
  - `Note`: For complex languages, tools such as parser generators are a better alternative.

## Solution

- Define a grammar for a simple language by defining an `Expression` class hierarchy and implementing an `interpret()` operation.
- Represent a sentence in the language by an abstract syntax tree (AST) made up of `Expression` instances.
- Interpret a sentence by calling `interpret()` on the AST.

## Common Structure

![Common structure of Interpreter pattern](img/structure.jpg)

* AbstractExpression (RegularExpression)
  * declares an abstract Interpret operation that is common to all nodes in the AST.
* TerminalExpression (LiteralExpression)
  * implements an Interpret operation associated with terminal symbols in the grammar.
  * an instance is required for every terminal symbol in a sentence.
* NonTerminalExpression (AlternationExpression, RepetitionExpressioni, SequenceExpression)
  * one such class is required for every rule `R ::= R1 R2 ... Rn` in the grammar
  * maintains instance variables of type AbstractExpression for each of the symbol R1 through Rn.
  * implements an Interpret operation for nonterminal symbols in the grammar. Interpret typically calls itself recursively on the variables representing R1 through Rn.
* Context
  * contains information that's global to the interpreter

## Collaboration

* Client builds or is given an AST. Then the client initializes the context and invokes the `Interpret` operation.
* The `Interpret` operations at each node use the context to store and access the state of the interpreter.

## Benefits

* *It's easy to change and extend the grammar.*
* *Implementing the grammar is easy, too.* Classes defining nodes in the AST have similar implementations and they can be automated with a compiler or parser generator.
* *Adding new ways to interpret expressions*. You can support pretty printing or type-checking an expression.
  * Consider using `Visitor` pattern, if you keep creating new ways of interpreting expression in order to avoid changing the grammar classes.

## Drawbacks

* *Complex grammars are hard to maintain.* The Interpreter pattern defines at least one class for every rule in the grammar. Hence grammars containing many rules can be hard to manage and maintain.

## Example

**Definition**

**Usage**

## Comparison with other patterns

* **Composite** - The abstract syntax tree is an instance of the Composite pattern.
* **Flyweight** - shows how to share terminal symbols within the AST.
* **Iterator** - can be used to traverse the structure.
* **Visitor** - can be used to maintain the behavior in each node in the AST in one class.