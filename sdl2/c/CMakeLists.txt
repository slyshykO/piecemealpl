cmake_minimum_required(VERSION 3.10)
project(sdl2 C)

file(GLOB sources      main.c)

add_compile_options("$<$<NOT:$<CONFIG:Debug>>:/Zi>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/DEBUG>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:REF>")
add_link_options("$<$<NOT:$<CONFIG:Debug>>:/OPT:ICF>")

find_package(SDL2 CONFIG REQUIRED)
include_directories(${SDL2_INCLUDE_DIRS})

add_executable(sdl2 WIN32 ${sources})

# just for example add some compiler flags
target_compile_options(sdl2 PUBLIC /std:c17)
target_link_libraries(sdl2 ${SDL2_LIBRARIES})
