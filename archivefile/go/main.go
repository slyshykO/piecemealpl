package main

import (
	"fmt"
	"os"
	"io"
	"archive/zip"
)

func main() {
	archive,err := os.Create("experiment.zip")
	if err != nil{
        panic(err)
    }
	defer archive.Close()

	zipWriter := zip.NewWriter(archive)
	f1, err := os.Open("test.csv")
	if err != nil {
		panic(err)
	}
	defer f1.Close()

	w1,err := zipWriter.Create ("hello.txt")
	if err!=nil {
		panic(err)
	}

	data := "Hello World!"
	_, err = io.WriteString(w1, data)
	if err != nil {
		panic(err)
	}

	zipWriter.Close()

	fmt.Println("Hello, World!")
}