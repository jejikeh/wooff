package ecs

// import (
// 	"fmt"

// 	"github.com/jejikeh/gomemory"
// )

// type ComponentID uint32

// // @Incomplete.
// var componentIDs = make(map[string]ComponentID)

// type Component interface{}

// func NewComponent[T Component](ecs *ECS) *T {
// 	component := gomemory.New[T](ecs.componentsArena)
// 	cName := fmt.Sprintf("%T", *component)

// 	_, ok := componentIDs[cName]
// 	if !ok {
// 		id := ComponentID(len(componentIDs))
// 		componentIDs[cName] = id
// 	}

// 	return component
// }

// func GetComponentID[T Component]() ComponentID {
// 	return componentIDs[fmt.Sprintf("%T", *new(T))]
// }
