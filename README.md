## About Arithm

Arithm is a tool which contains an interpreter for the simple programming language mainly designed to compute arithmetic expressions. It also has a long arithmetic and non-empty list libraries.
While all three modules can be used for developers, there are console interface of interpreter for users.

## Builds

GitHub Actions |
:---: |
[![GitHub Actions](https://github.com/kirillgarbar/Arithm/workflows/Build%20master/badge.svg)](https://github.com/kirillgarbar/Arithm/actions?query=branch%3Amaster) |
[![Build History](https://buildstats.info/github/chart/kirillgarbar/Arithm)](https://github.com/kirillgarbar/Arithm/actions?query=branch%3Amaster) |

## Getting Started

You can install the package with dotnet by following this steps:

* Add a source in your NuGet.config file
#
	dotnet nuget add source "https://nuget.pkg.github.com/kirillgarbar/index.json"
* Authorize with your github token
#
	paket config add-token "https://nuget.pkg.github.com/kirillgarbar/index.json" <token>
* Install the package
#
	dotnet add PROJECT package Arithm --version <version>

## Usage

Arithm contains a console application with interpreter for arithmetic expressions and some useful libraries such as BigInt for long arithmetic

## Documentation

The [docs](https://kirillgarbar.github.io/Arithm/) contains an overview of the tool and how to use it

## Requirements

* .NET 5.0 or greater

## Directory structure

```
Arithm
├── .config - dotnet tools
├── .github - GitHub Actions CI setup 
├── docs - site with documentation
├── docsSrc - documentation files in .md format
├── src - main code of the project
│   └── Arithm - Interpreter, MyList and BigInt libraries
├── tests - tests
│   └── Arithm.tests - tests for all modules
├── fsharplint.json - linter config
└── Arithm.sln - main solution file
```