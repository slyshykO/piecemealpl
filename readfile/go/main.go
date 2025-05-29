package main

import (
    "fmt"
    "os"
)

func main() {
    content, err := os.ReadFile("README.md")
    if err != nil {
        panic(err)
    }
	fmt.Println(content)
	fmt.Println("Hello, World!")
}