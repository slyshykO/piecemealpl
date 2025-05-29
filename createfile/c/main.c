#include <stdio.h>
#include <string.h>

int main() {
    FILE* fp = fopen("output.txt", "wb");
    if (fp) {
		fclose(fp);
	}
    printf("Hello, world!");
    return 0;
}