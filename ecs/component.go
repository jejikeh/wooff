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
	component := gomemory.New[T](a)
	cName := fmt.Sprintf("%T", *component)

	_, ok := componentIDs[cName]
	if !ok {
		id := ComponentID(len(componentIDs))
		componentIDs[cName] = id
	}

	return component
}

func GetComponentID[T any]() ComponentID {
	return componentIDs[fmt.Sprintf("%T", *new(T))]
}
