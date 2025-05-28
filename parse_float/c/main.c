#include <stdio.h>
#include <string.h>

int main() {
    const char* flt = "4.0800";
    float f;
    sscanf_s(flt, "%f", &f);
    printf("Hello, world!");
    return 0;
}