cmake_minimum_required(VERSION 3.10)
project(cmdlineargs2 C)

file(GLOB sources      main.c)

# this is heuristically generated, and may not be correct
find_package(unofficial-getopt-win32 REQUIRED)

add_compile_options("$<$<NOT:$<CONFIG:Debug>>:/Zi>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/DEBUG>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:REF>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:ICF>")

add_executable(cmdlineargs2 ${sources})

# just for example add some compiler flags
target_compile_options(cmdlineargs2 PUBLIC /std:c17)
target_link_libraries(cmdlineargs2 PRIVATE unofficial::getopt-win32::getopt)
