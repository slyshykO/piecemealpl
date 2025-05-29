#include <stdio.h>
#include <string.h>
#include <zip.h>

int main() {
    int errorp;
    zip_t* archive = zip_open("experiment.zip", ZIP_CREATE | ZIP_EXCL, &errorp);
    if (archive == NULL) {
        zip_error_t ziperror;
        zip_error_init_with_code(&ziperror, errorp);
        return 1;
    }

    const char* data = "Hello World!";
    struct zip_source* source = zip_source_buffer(archive, data, strlen(data), 0);
    if (source == NULL) {
        printf("failed to create source buffer. %s\n", zip_strerror(archive));
        return -1;
    }

    int index = (int)zip_file_add(archive, "hello.txt", source, ZIP_FL_OVERWRITE);
    if (index < 0) {
        printf("failed to add file to archive: %s\n", zip_strerror(archive));
        return -1;
    }

    zip_close(archive);
    printf("Hello, world!");
    return 0;
}