cmake_minimum_required(VERSION 3.10)
project(archivefile C)

file(GLOB sources      main.c)

# this is heuristically generated, and may not be correct
find_package(libzip CONFIG REQUIRED)

add_compile_options("$<$<NOT:$<CONFIG:Debug>>:/Zi>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/DEBUG>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:REF>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:ICF>")

add_executable(archivefile ${sources})

# just for example add some compiler flags
target_compile_options(archivefile PUBLIC /std:c17)
target_link_libraries(archivefile PRIVATE libzip::zip)
