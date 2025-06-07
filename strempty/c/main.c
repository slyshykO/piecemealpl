#include <stdio.h>
#include <string.h>

int main() {
    char str[] = "Hello, world!";
    const size_t b = strlen(str);
    if (b)
        printf("%s", str);
    return 0;
}