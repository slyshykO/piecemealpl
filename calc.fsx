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

let m = Matrix<float>.Build.Dense(7 (*apps*), 7 (*components*))
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

// C values
let cParams = vector [
    10752.; // Baseline
    11776.; // SumStrings
    10752.; // ParseFloat
    10752.; // StrReverse
    11776.; // ToLower
    11264.; // StrEmpty
    10752.; // ArrayInit
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
]

Vector<float>.Build.Dense(6 (*components*))

let cComponents = m.Solve(cParams)
let rustComponents = m.Solve(rustParams)
let naotComponents = m.Solve(naotParams)
let goComponents = m.Solve(goParams)
let printComponents header (cComponents: Vector<float>) =
    printfn ""
    printfn "## %s" header
    printfn "| Component | Size |"
    printfn "| ------------ | -----: |"
    printfn "| Runtime | %.0fB |" cComponents[Components.Runtime]
    printfn "| SumStrings | %.0fB |" cComponents[Components.SumStrings]
    printfn "| ParseFloat | %.0fB |" cComponents[Components.ParseFloat]
    printfn "| StrReverse | %.0fB |" cComponents[Components.StrReverse]
    printfn "| ToLower | %.0fB |" cComponents[Components.ToLower]
    printfn "| StrEmpty | %.0fB |" cComponents[Components.StrEmpty]
    printfn "| ArrayInit | %.0fB |" cComponents[Components.ArrayInit]

printComponents "C language basics" cComponents
printComponents "Rust language basics" rustComponents
printComponents "C# NativeAOT language basics" naotComponents
printComponents "Go language basics" goComponents
