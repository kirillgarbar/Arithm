namespace Arithm

module Interpreter =

    open System.Collections.Generic
    open BigInt

    let private newDataToConsole = Event<string>()

    let printed = newDataToConsole.Publish

    type Dicts = { VariablesDictionary: Dictionary<string, string>; InterpretedDictionary: Dictionary<AST.VName, AST.Expression> }

    let rec processExpr (vDict:Dictionary<AST.VName,AST.Expression>) expr =
        match expr with
        | AST.Num n -> n
        | AST.NVar nv ->
            let data =
                try
                    vDict.[nv]
                with
                | _ -> failwithf "Variable %A is not declared." nv
            processExpr vDict data
        | AST.Sum (x, y) -> sum (processExpr vDict x) (processExpr vDict y)
        | AST.Sub (x, y) -> sub (processExpr vDict x) (processExpr vDict y)
        | AST.Mul (x, y) -> mul (processExpr vDict x) (processExpr vDict y)
        | AST.Div (x, y) -> div (processExpr vDict x) (processExpr vDict y)
        | AST.Rem (x, y) -> rem (processExpr vDict x) (processExpr vDict y)
        | AST.Pow (x, y) -> power (processExpr vDict x) (processExpr vDict y)
        | AST.Abs x -> abs (processExpr vDict x)
        | AST.Bin x -> toBinary (processExpr vDict x)

    let processStmt (vDict:Dictionary<AST.VName,AST.Expression>) printString stmt =
        match stmt with
        | AST.Print v ->
            let data =
                try
                    vDict.[v]
                with
                | _ -> failwithf "Variable %A is not declared." v
            match data with
            | AST.Num n ->
                let num = bigIntToString n
                let str = (if num.[0] = '+' then num.[1..] else num) + "\n"
                newDataToConsole.Trigger str
                vDict, printString + str
            | _ -> failwith "Num expected"
        | AST.VDecl(v,e) ->
            if vDict.ContainsKey v
            then vDict.[v] <- AST.Num (processExpr vDict e)
            else vDict.Add(v, AST.Num (processExpr vDict e))
            vDict, printString

    let runVariables (startDicts: Dicts) ast =
        let startDict = startDicts.VariablesDictionary
        let variableDict = startDicts.InterpretedDictionary
        let vD, _ = List.fold (fun (d1, ps) stmt -> processStmt d1 ps stmt) (variableDict, "") ast
        for i in vD.Keys do
            match vD.[i] with
            | AST.Num n ->
                match i with
                | AST.Var k -> startDict.[k] <- bigIntToString n
            | _ -> failwith "impossible case"
        let dicts = { VariablesDictionary = startDict; InterpretedDictionary = vD }
        dicts

    let runPrint ast =
        let vDict = Dictionary<_,_>()
        let varDict = Dictionary<_,_>()
        let vD, printString = List.fold (fun (d1, ps) stmt -> processStmt d1 ps stmt) (vDict, "") ast
        for i in vD.Keys do
            match vD.[i] with
            | AST.Num n -> varDict.[string i] <- bigIntToString n
            | _ -> failwith "impossible case"
        printString

    let calculate (ast:AST.Stmt list) =
        match ast.[0] with
        | AST.VDecl (_, e) -> processExpr (Dictionary<_,_>()) e
        | _ -> failwith "unexpected statement"
