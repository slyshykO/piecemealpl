#include <stdio.h>
#include <string.h>

void method0(char* prefix);
void method1(char* prefix);
void method2(char* prefix);
void method3(char* prefix);
void method4(char* prefix);
void method5(char* prefix);
void method6(char* prefix);
void method7(char* prefix);
void method8(char* prefix);
void method9(char* prefix);

char* prefix = "Proxy: ";
void proxy_method0() {
    method0(prefix);
}
void proxy_method1() {
    method1(prefix);
}
void proxy_method2() {
    method2(prefix);
}
void proxy_method3() {
    method3(prefix);
}
void proxy_method4() {
    method4(prefix);
}
void proxy_method5() {
    method5(prefix);
}
void proxy_method6() {
    method6(prefix);
}
void proxy_method7() {
    method7(prefix);
}
void proxy_method8() {
    method8(prefix);
}
void proxy_method9() {
    method9(prefix);
}

