package main

import (
	"fmt"
	"os"
)

func main() {
	f,err := os.Create("output.txt")
	if err != nil{
        panic(f)
    }
	defer f.Close()
	fmt.Println("Hello, World!")
}