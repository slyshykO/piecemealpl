package main

import (
    "fmt"
    "log"
    "os"
)

func main() {
    content, err := os.ReadFile("README.md")
    if err != nil {
        log.Fatal(err)
    }
	fmt.Println(content)
	fmt.Println("Hello, World!")
}