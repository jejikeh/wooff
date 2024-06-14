package main

import (
	"fmt"

	"github.com/jejikeh/gomemory"
	wooff "github.com/jejikeh/wooff/ecs"
)

type HelloComponent struct {
	wooff.Component

	Hello string
}

func NewHelloComponent(a gomemory.Arena, message string) *HelloComponent {
	c := wooff.NewComponent[HelloComponent](a)

	c.Hello = message

	return c
}

func main() {
	a := gomemory.NewMallocArena(1024)
	defer a.Free()

	h := NewHelloComponent(a, "Hello World!")

	fmt.Printf("%s\n", h.Hello)
}
