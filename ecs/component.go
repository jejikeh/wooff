package wooff

import (
	"fmt"

	"github.com/jejikeh/gomemory"
)

type ComponentID uint32

var componentIDs = make(map[string]ComponentID)

type Component struct {
	Owner EntityID
	Index uint32
}

func NewComponent[T any](a gomemory.Arena) *T {
	c := gomemory.New[T](a)
	_, ok := componentIDs[fmt.Sprintf("%T", *c)]
	if !ok {
		id := ComponentID(len(componentIDs))
		componentIDs[fmt.Sprintf("%T", *c)] = id
	}

	return c
}

func GetComponentID[T any]() ComponentID {
	return componentIDs[fmt.Sprintf("%T", *new(T))]
}
