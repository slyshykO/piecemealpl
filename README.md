Example projects for measuring the code size of the different primitive software operations
==========================

The goal of this experiement is to measure, what primitive software concepts weight in the byte code.
I attempt to have more or less idiomatic code, and not something which people will use when they optimize for size.
Let's call it typical low effor code.

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

# Results

The 0 or negative numbers mean that I cannot reliably measure or guess that size. 
Obviosuly that feature have non zero size. Probably I overcalculate size of the runtime + minimal main functoin, and code which needed for that already alllocated.

## C language basics
| Component | Size |
| ------------ | -----: |
| Runtime | 10752B |
| SumStrings | 1024B |
| ParseFloat | 0B |
| StrReverse | 0B |
| ToLower | 1024B |
| StrEmpty | 512B |
| ArrayInit | 0B |

## Rust language basics
| Component | Size |
| ------------ | -----: |
| Runtime | 138240B |
| SumStrings | 512B |
| ParseFloat | 17408B |
| StrReverse | 1024B |
| ToLower | 17408B |
| StrEmpty | 0B |
| ArrayInit | 512B |

## C# NativeAOT language basics
| Component | Size |
| ------------ | -----: |
| Runtime | 1105408B |
| SumStrings | 512B |
| ParseFloat | 26112B |
| StrReverse | 14336B |
| ToLower | 2560B |
| StrEmpty | 0B |
| ArrayInit | 3584B |

## Go language basics
| Component | Size |
| ------------ | -----: |
| Runtime | 1270272B |
| SumStrings | 13312B |
| ParseFloat | 18432B |
| StrReverse | 2560B |
| ToLower | 13312B |
| StrEmpty | -512B |
| ArrayInit | 512B |