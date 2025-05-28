Example projects for measuring the code size of the different primitive software operations
==========================

The goal of this experiement is to measure, what primitive software concepts weight in the byte code.
I attempt to have more or less idiomatic code, and not something which people will use when they optimize for size.
Let's call it typical low effor code.

Right now I have only lowlevel operation in the code. But really would like to measure different level of abstractions.
Let's say what it take to ZIP archive, how much code needed to make 1 HTTP request, how much code needed to create empty UI window,
what code takes to make button, etc. It can be ambiguous, but if start with simple things, and craft sentences more detailed we can 
probably capture enough interesting information to guess why our software sometimes can take hundreds of megabytes, and why 
our dependencies in some languages can take gigabytes even for relatively simple applications. To have more concrete explanation, 
and not abstract "because we don't care about dependencies". That's not actionable IMO.

If you agree to help with this very mundane process, please submit PR.

[Українською](./README_uk.md)

# How to run
```
./measure.ps1
```

# Components

- [SumStrings](./sum_strings) The perform concatenation of two string types in the language.
- [ParseFloat](./parse_float) Parse string with float value into float32 datatype.
- [StrReverse](./strreverse) Reverse constant string
- [ToLower](./tolower) Convert string to lowercase using default locale parameters in the langugage.
- [StrEmpty](./strempty) Check that string is empty.
- [ArrayInit](./arrayinit) Initialize array of 100 bytes and print all 100 of them.
- [CmdLineArgs](./cmdlineargs) Printing all passed command line args
- [ReadFile](./readfile) Read file to the console

# Results

The 0 or negative numbers mean that I cannot reliably measure or guess that size. 
Obviosuly that feature have non zero size. Probably I overcalculate size of the runtime + minimal main functoin, and code which needed for that already alllocated.

## C language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 10752 |
| SumStrings | 1024 |
| ParseFloat | 0 |
| StrReverse | 0 |
| ToLower    | 1024 |
| StrEmpty   | 512 |
| ArrayInit  | 0 |
| CmdLineArgs| 0 |
| ReadFile   | 512 |

## Rust language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 138240 |
| SumStrings | 512 |
| ParseFloat | 17408 |
| StrReverse | 1024 |
| ToLower    | 17408 |
| StrEmpty   | 0 |
| ArrayInit  | 512 |
| CmdLineArgs| 9216 |
| ReadFile   | 13312 |

## C# NativeAOT language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 1105408 |
| SumStrings | 512 |
| ParseFloat | 26112 |
| StrReverse | 14336 |
| ToLower    | 2560 |
| StrEmpty   | 0 |
| ArrayInit  | 3584 |
| CmdLineArgs| 512 |
| ReadFile   | 122880 |

## Go language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 1270272 |
| SumStrings | 13312 |
| ParseFloat | 18432 |
| StrReverse | 2560 |
| ToLower    | 13312 |
| StrEmpty   | -512 |
| ArrayInit  | 512 |
| CmdLineArgs| 0 |
| ReadFile   | 129024 |
