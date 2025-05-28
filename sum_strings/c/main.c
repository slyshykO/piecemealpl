#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int main() {
    char s1[] = "Hello, ";
    char s2[] = "world!";
	int buffer_size = sizeof(s1) + sizeof(s2);
	char* s3 = malloc(buffer_size);

    // Concatenate str2 to str1
    if (s3 == NULL) {
        fprintf(stderr, "Memory allocation failed\n");
        return 1;
	}

	strcpy_s(s3, sizeof(s1), s1);
    strcat_s(s3, buffer_size, s2);

    printf("%s\n", s3);
    return 0;
}