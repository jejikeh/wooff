package main

import (
	"fmt"

	"github.com/jejikeh/wooff/ecs"
)

type HelloComponent struct {
	ecs.Component

	Hello string
}

func NewHelloComponent(e *ecs.ECS, message string) *HelloComponent {
	c := ecs.NewComponent[HelloComponent](e)
	c.Hello = message

	return c
}

type HelloComponent2 struct {
	ecs.Component

	Hello string
}

func NewHelloComponent2(e *ecs.ECS, message string) *HelloComponent2 {
	c := ecs.NewComponent[HelloComponent2](e)
	c.Hello = message

	return c
}

func main() {
	mainECS := ecs.NewECS()
	defer mainECS.Free()

	h := NewHelloComponent(mainECS, "Hello World!")

	fmt.Printf("%s\n", h.Hello)
	fmt.Printf("%v\n", ecs.GetComponentID[HelloComponent]())

	h2 := NewHelloComponent2(mainECS, "Hello World2")

	fmt.Printf("%s\n", h2.Hello)
	fmt.Printf("%v\n", ecs.GetComponentID[HelloComponent2]())
}
