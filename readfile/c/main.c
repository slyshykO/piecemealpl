#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() {
    FILE* fptr = fopen("README.md", "r");

    // Buffer to store 50 characters at a time
    char buff[50];

    // Reading strings till fgets returns NULL
    while (fgets(buff, 50, fptr)) {
        printf("%s", buff);
    };

    fclose(fptr);

    printf("Hello, world!");
    return 0;
}