using SDL2;
using System;

unsafe
{
    // Initilizes SDL.
    if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
    {
        Console.WriteLine($"There was an issue initilizing SDL. {SDL.SDL_GetError()}");
    }

    // Create a new window given a title, size, and passes it a flag indicating it should be shown.
    var window = SDL.SDL_CreateWindow("Hello, world!", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

    if (window == IntPtr.Zero)
    {
        Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
    }

    var surface = SDL.SDL_GetWindowSurface(window);
    if (surface == IntPtr.Zero)
    {
        Console.WriteLine($"Surface could not be created. {SDL.SDL_GetError()}");
    }

    SDL.SDL_Rect rect = new SDL.SDL_Rect { x = 0, y = 0, w = 200, h = 200 };
    SDL.SDL_FillRect(surface, IntPtr.Zero, 0); // Fill the surface with red color
    SDL.SDL_FillRect(surface, (nint)(&rect), SDL.SDL_MapRGB(((SDL.SDL_Surface*)surface)->format, 0xFF, 0x00, 0xFF)); // Fill the surface with red color
    SDL.SDL_UpdateWindowSurface(window); // Update the window surface to show the changes

    var running = true;

    // Main loop for the program
    while (running)
    {
        // Check to see if there are any events and continue to do so until the queue is empty.
        while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    running = false;
                    break;
            }
        }

        SDL.SDL_Delay(33);
    }

    SDL.SDL_DestroyWindow(window);
    SDL.SDL_Quit();
}