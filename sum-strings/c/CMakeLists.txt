cmake_minimum_required(VERSION 3.10)
project(sum_strings)

file(GLOB sources      main.c)

add_executable(sum_strings ${sources})

# just for example add some compiler flags
target_compile_options(sum_strings PUBLIC /std:c17)
