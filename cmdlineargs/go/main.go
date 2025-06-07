package main

import (
	"fmt"
	"os"
)

func main() {
	for _, val := range os.Args {
		fmt.Println(val)
	}

	fmt.Println("Hello, World!")
}
