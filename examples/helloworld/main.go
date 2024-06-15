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

func NewHelloComponent(ecs gomemory.Arena, message string) *HelloComponent {
	c := wooff.NewComponent[HelloComponent](ecs)
	c.Hello = message

	return c
}

type HelloComponent2 struct {
	wooff.Component

	Hello string
}

func NewHelloComponent2(ecs gomemory.Arena, message string) *HelloComponent2 {
	c := wooff.NewComponent[HelloComponent2](ecs)
	c.Hello = message

	return c
}

func main() {
	ecs := wooff.NewECS()
	defer ecs.Free()

	h := NewHelloComponent(ecs, "Hello World!")

	fmt.Printf("%s\n", h.Hello)
	fmt.Printf("%v\n", wooff.GetComponentID[HelloComponent]())

	h2 := NewHelloComponent2(ecs, "Hello World2")

	fmt.Printf("%s\n", h2.Hello)
	fmt.Printf("%v\n", wooff.GetComponentID[HelloComponent2]())
}
