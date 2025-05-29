#r "nuget: MathNet.Numerics, 5.0.0"
#r "nuget: MathNet.Numerics.FSharp, 5.0.0"

// Illustrates solving systems of simultaneous linear
// equations using the DenseMatrix and LUDecomposition classes 
// in the Numerics.NET.LinearAlgebra namespace of Numerics.NET.

#light

open System

open MathNet.Numerics
// The DenseMatrix and LUDecomposition classes reside in the 
// Numerics.NET.LinearAlgebra namespace.
open MathNet.Numerics.LinearAlgebra

// The license is verified at runtime. We're using a 30 day trial key here.
// For more information, see:
//     https://numerics.net/trial-key
//let licensed = Numerics.NET.License.Verify("64542-18980-57619-62268")

// A system of simultaneous linear equations is
// defined by a square matrix A and a right-hand
// side B, which can be a vector or a matrix.
//
// You can use any matrix type for the matrix A.
// The optimal algorithm is automatically selected.

module App =
    [<Literal>]
    let Baseline = 0
    [<Literal>]
    let SumStrings = 1
    [<Literal>]
    let ParseFloat = 2
    [<Literal>]
    let StrReverse = 3
    [<Literal>]
    let ToLower = 4
    [<Literal>]
    let StrEmpty = 5
    [<Literal>]
    let ArrayInit = 6
    [<Literal>]
    let CmdLineArgs = 7
    [<Literal>]
    let ReadFile = 8
    [<Literal>]
    let ZipFile = 9
    [<Literal>]
    let CreateFile = 10


module Components =
    [<Literal>] 
    let Runtime = 0
    [<Literal>]
    let SumStrings = 1
    [<Literal>]
    let ParseFloat = 2
    [<Literal>]
    let StrReverse = 3
    [<Literal>]
    let ToLower = 4
    [<Literal>]
    let StrEmpty = 5
    [<Literal>]
    let ArrayInit = 6
    [<Literal>]
    let CmdLineArgs = 7
    [<Literal>]
    let ReadFile = 8
    [<Literal>]
    let ZipFile = 9
    [<Literal>]
    let CreateFile = 10

let m = Matrix<float>.Build.Dense(11 (*apps*), 11 (*components*))
m[App.Baseline, Components.Runtime] <- 1.0
m[App.SumStrings,Components.Runtime] <- 1.0
m[App.SumStrings,Components.SumStrings] <- 1.0
m[App.ParseFloat,Components.Runtime] <- 1.0
m[App.ParseFloat,Components.ParseFloat] <- 1.0
m[App.StrReverse,Components.Runtime] <- 1.0
m[App.StrReverse,Components.StrReverse] <- 1.0
m[App.ToLower,Components.Runtime] <- 1.0
m[App.ToLower,Components.ToLower] <- 1.0
m[App.StrEmpty,Components.Runtime] <- 1.0
m[App.StrEmpty,Components.StrEmpty] <- 1.0
m[App.ArrayInit,Components.Runtime] <- 1.0
m[App.ArrayInit,Components.ArrayInit] <- 1.0
m[App.CmdLineArgs,Components.Runtime] <- 1.0
m[App.CmdLineArgs,Components.CmdLineArgs] <- 1.0
m[App.ReadFile,Components.Runtime] <- 1.0
m[App.ReadFile,Components.ReadFile] <- 1.0
m[App.ZipFile,Components.Runtime] <- 1.0
m[App.ZipFile,Components.CreateFile] <- 1.0
m[App.ZipFile,Components.ZipFile] <- 1.0
m[App.CreateFile,Components.Runtime] <- 1.0
m[App.CreateFile,Components.CreateFile] <- 1.0

// C values
let cParams = vector [
    10752.; // Baseline
    11776.; // SumStrings
    10752.; // ParseFloat
    10752.; // StrReverse
    11776.; // ToLower
    11264.; // StrEmpty
    10752.; // ArrayInit
    10752.; // CmdLineArgs
    11264.; // ReadFile
    201216.; // ZipFile
    10752.; // CreateFile
]

// Rust values
let rustParams = vector [
    138240.; // Baseline
    138752.; // SumStrings
    155648.; // ParseFloat
    139264.; // StrReverse
    155648.; // ToLower
    138240.; // StrEmpty
    138752.; // ArrayInit
    147456.; // CmdLineArgs
    151552.; // ReadFile
    1074176.; // ZipFile
    146432.; // CreateFile
]

// Naot values
let naotParams = vector [
    1105408.; // Baseline
    1105920.; // SumStrings
    1131520.; // ParseFloat
    1119744.; // StrReverse
    1107968.; // ToLower
    1105408.; // StrEmpty
    1108992.; // ArrayInit
    1105920.; // CmdLineArgs
    1228288.; // ReadFile
    2117632.; // ZipFile
    1210368.; // CreateFile
]

// Go values
let goParams = vector [
    1270272.; // Baseline
    1283584.; // SumStrings
    1288704.; // ParseFloat
    1272832.; // StrReverse
    1283584.; // ToLower
    1269760.; // StrEmpty
    1270784.; // ArrayInit
    1270272.; // CmdLineArgs
    1377792.; // ReadFile
    1610240.; // ZipFile
    1278464.; // CreateFile
]

Vector<float>.Build.Dense(6 (*components*))

let cComponents = m.Solve(cParams)
let rustComponents = m.Solve(rustParams)
let naotComponents = m.Solve(naotParams)
let goComponents = m.Solve(goParams)
let printComponents header (cComponents: Vector<float>) =
    printfn ""
    printfn "## %s" header
    printfn "| Component    | Size (B) |"
    printfn "| ------------ | -----: |"
    printfn "| Runtime    | %.0f |" cComponents[Components.Runtime]
    printfn "| SumStrings | %.0f |" cComponents[Components.SumStrings]
    printfn "| ParseFloat | %.0f |" cComponents[Components.ParseFloat]
    printfn "| StrReverse | %.0f |" cComponents[Components.StrReverse]
    printfn "| ToLower    | %.0f |" cComponents[Components.ToLower]
    printfn "| StrEmpty   | %.0f |" cComponents[Components.StrEmpty]
    printfn "| ArrayInit  | %.0f |" cComponents[Components.ArrayInit]
    printfn "| CmdLineArgs| %.0f |" cComponents[Components.CmdLineArgs]
    printfn "| ReadFile   | %.0f |" cComponents[Components.ReadFile]
    printfn "| ZipFile    | %.0f |" cComponents[Components.ZipFile]
    printfn "| CreateFile | %.0f |" cComponents[Components.CreateFile]

printComponents "C language basics" cComponents
printComponents "Rust language basics" rustComponents
printComponents "C# NativeAOT language basics" naotComponents
printComponents "Go language basics" goComponents
