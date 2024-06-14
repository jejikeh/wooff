package wooff

import (
	"reflect"

	"github.com/jejikeh/gomemory"
)

type ComponentID uint32

var componentIDs = make(map[reflect.Type]ComponentID)

type Component struct {
	Owner EntityID
	Index uint32
}

func NewComponent[T any](a gomemory.Arena) *T {
	c := gomemory.New[T](a)
	_, ok := componentIDs[reflect.TypeOf(c)]
	if !ok {
		id := ComponentID(len(componentIDs))
		componentIDs[reflect.TypeOf(c)] = id
	}

	return c
}
