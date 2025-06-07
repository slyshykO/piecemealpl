cmake_minimum_required(VERSION 3.10)
project(proxycall C)

file(GLOB sources      main.c basefun.c proxy.c)

add_compile_options("$<$<NOT:$<CONFIG:Debug>>:/Zi>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/DEBUG>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:REF>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:ICF>")

add_executable(proxycall ${sources})

# just for example add some compiler flags
target_compile_options(proxycall PUBLIC /std:c17)
