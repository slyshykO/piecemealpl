#include <stdio.h>
#include <ctype.h>
#include <string.h>

void toLowercase(char* str) {
    for (int i = 0; str[i] != '\0'; i++) {
        str[i] = tolower((unsigned char)str[i]);
    }
}
int main() {
    char str[] = "Hello, World!";
    toLowercase(str);
    printf(str);
    return 0;
}