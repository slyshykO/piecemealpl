cmake_minimum_required(VERSION 3.10)
project(win32_window C)

file(GLOB sources      main.c)

add_compile_options("$<$<NOT:$<CONFIG:Debug>>:/Zi>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/DEBUG>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:REF>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:ICF>")

add_executable(win32_window WIN32 ${sources})

# just for example add some compiler flags
target_compile_options(win32_window PUBLIC /std:c17)
