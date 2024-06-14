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

type HelloComponent2 struct {
	wooff.Component

	Hello string
}

func NewHelloComponent2(a gomemory.Arena, message string) *HelloComponent2 {
	c := wooff.NewComponent[HelloComponent2](a)

	c.Hello = message

	return c
}

func main() {
	a := gomemory.NewMallocArena(1024)
	defer a.Free()

	h := NewHelloComponent(a, "Hello World!")

	fmt.Printf("%s\n", h.Hello)
	fmt.Printf("%v\n", wooff.GetComponentID[HelloComponent]())

	h2 := NewHelloComponent2(a, "Hello World2")

	fmt.Printf("%s\n", h2.Hello)
	fmt.Printf("%v\n", wooff.GetComponentID[HelloComponent2]())
}
