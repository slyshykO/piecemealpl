Example projects for measuring the code size of the different primitive software operations
==========================

The goal of this experiement is to measure, what primitive software concepts weight in the byte code.
I attempt to have more or less idiomatic code, and not something which people will use when they optimize for size.
Let's call it typical low effor code.

# How to run
```
./measure.ps1
```

# Results

## C language basics
| Component | Size |
| ------------ | -----: |
| Runtime | 10752B |
| SumStrings | 1024B |
| ParseFloat | 0B |
| StrReverse | 0B |
| ToLower | 1024B |
| StrEmpty | 512B |

## Rust language basics
| Component | Size |
| ------------ | -----: |
| Runtime | 138240B |
| SumStrings | 512B |
| ParseFloat | 17408B |
| StrReverse | 1024B |
| ToLower | 17408B |
| StrEmpty | 0B |