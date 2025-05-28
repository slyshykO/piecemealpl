cmake_minimum_required(VERSION 3.10)
project(baseline)

file(GLOB sources      main.c)

add_executable(baseline ${sources})

# just for example add some compiler flags
target_compile_options(baseline PUBLIC /std:c17)
