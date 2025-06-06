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
- [ZipFile](./archivefile) Archive string into single file packaged into ZIP file.
- [CreateFile](./createfile) Create empty file with the given name.

# Results

The 0 or negative numbers mean that I cannot reliably measure or guess that size. 
Obviosuly that feature have non zero size. Probably I overcalculate size of the runtime + minimal main functoin, and code which needed for that already alllocated.

## C language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 10,752 |
| SumStrings | 1,024 |
| ParseFloat | 0 |
| StrReverse | 0 |
| ToLower    | 1,024 |
| StrEmpty   | 512 |
| ArrayInit  | 0 |
| CmdLineArgs| 0 |
| ReadFile   | 512 |
| ZipFile    | 190,464 |
| CreateFile | 0 |
| Win32Window| 12,288 |

## Rust language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 138,240 |
| SumStrings | 512 |
| ParseFloat | 17,408 |
| StrReverse | 1,024 |
| ToLower    | 17,408 |
| StrEmpty   | 0 |
| ArrayInit  | 512 |
| CmdLineArgs| 9,216 |
| ReadFile   | 13,312 |
| ZipFile    | 927,744 |
| CreateFile | 8,192 |
| Win32Window| 134,656 |

## C# NativeAOT language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 1,105,408 |
| SumStrings | 512 |
| ParseFloat | 26,112 |
| StrReverse | 14,336 |
| ToLower    | 2,560 |
| StrEmpty   | 0 |
| ArrayInit  | 3,584 |
| CmdLineArgs| 512 |
| ReadFile   | 122,880 |
| ZipFile    | 907,264 |
| CreateFile | 104,960 |
| Win32Window| 1,157,632 |

## Go language basics
| Component    | Size (B) |
| ------------ | -----: |
| Runtime    | 1,270,272 |
| SumStrings | 13,312 |
| ParseFloat | 18,432 |
| StrReverse | 2,560 |
| ToLower    | 13,312 |
| StrEmpty   | -512 |
| ArrayInit  | 512 |
| CmdLineArgs| 0 |
| ReadFile   | 107,520 |
| ZipFile    | 331,776 |
| CreateFile | 8,192 |
| Win32Window| 1,304,064 |
