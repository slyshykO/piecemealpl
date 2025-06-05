#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include <SDL.h>

#define SCREEN_WIDTH    800
#define SCREEN_HEIGHT   600

int main() {
    if (SDL_Init(SDL_INIT_VIDEO) < 0)
    {
        printf("SDL could not be initialized!\n"
            "SDL_Error: %s\n", SDL_GetError());
        return 0;
    }

    SDL_Window* window = SDL_CreateWindow("Hello, world!",
        SDL_WINDOWPOS_UNDEFINED,
        SDL_WINDOWPOS_UNDEFINED,
        SCREEN_WIDTH, SCREEN_HEIGHT,
        SDL_WINDOW_SHOWN);

    if (!window)
    {
        printf("Window could not be created!\n"
            "SDL_Error: %s\n", SDL_GetError());
    }
    else
    {
        SDL_Surface* surface = SDL_GetWindowSurface(window);
        if (!surface)
        {
            printf("Surface could not be created!\n"
                "SDL_Error: %s\n", SDL_GetError());
        }
        else
        {
			SDL_FillRect(surface, NULL, 0);

            // Declare rect of square
            SDL_Rect rect = { 0, 0, 200, 200 };
			SDL_Color colour = { 255, 0, 255, 255 }; // Red color

			SDL_FillRect(surface, &rect, SDL_MapRGBA(surface->format, colour.r, colour.g, colour.b, colour.a));
            SDL_UpdateWindowSurface(window);

            // Event loop exit flag
            bool running = true;

            // Event loop
            while (running)
            {
                SDL_Event event;

                while (SDL_PollEvent(&event)) 
                {
                    if (event.type == SDL_QUIT)
                    {
                        running = false;
                        break;
                    }
                }

                SDL_Delay(33);
            }
        }
    }

    SDL_Quit();
    return 0;
}