package main

import (
	"fmt"
	"flag"
)

func main() {
	_ = flag.Int("i", 0, "help message for flag i")
	_ = flag.Int("l", 0, "help message for flag l")
	_ = flag.Int("r", 0, "help message for flag r")
	_ = flag.String("f", "", "help message for flag f")
	flag.Parse()
	flag.Visit (func(f *flag.Flag) {
		//fmt.Printf("Flag %s has value %q\n", f.Name, f.Value)
		fmt.Printf("Flag %s has value: %s\n", f.Name, f.Value.String())
	})
}
