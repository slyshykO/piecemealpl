#include <stdio.h>
#include <string.h>

int main(int argc, char* argv[]) {
    for (int i = 0; i < argc; i++) {
        printfn(argv[i]);
    }
    printfn("Hello, world!");
    return 0;
}