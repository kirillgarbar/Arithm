# Arithm

Arithm is a library which contains an interpreter for the simple programming language mainly designed to compute arithmetic expressions.

## Installing

You can install the package with dotnet by following this steps:

* Add a source in your NuGet.config file
#
	dotnet nuget add source https://nuget.pkg.github.com/kirillgarbar/index.json
* Authorize with your github token
#
	paket config add-token https://nuget.pkg.github.com/kirillgarbar/index.json <token>
* Install the package
#
	dotnet add PROJECT package Arithm --version <version>