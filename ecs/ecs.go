package ecs

import (
	"reflect"

	"github.com/jejikeh/gomemory"
)

const MaxEntityCount = 1024

type ComponentID uint32

type EntityID uint32

type EntityInfo struct {
	ID            EntityID
	ComponentMask gomemory.BitSet[ComponentID]
}

type Layer struct {
	componentPool []*gomemory.Pool
	componentIDs  map[string]ComponentID

	entities *gomemory.TypedPool[EntityInfo]
}

func NewLayer() *Layer {
	return &Layer{
		// @Incomplete: We could store this data manually to give complete ownership of memory to Layer?
		componentPool: make([]*gomemory.Pool, gomemory.Bits[ComponentID](ComponentID(0))),
		componentIDs:  make(map[string]ComponentID, gomemory.Bits[ComponentID](ComponentID(0))),
		entities:      gomemory.NewTypedPool[EntityInfo](MaxEntityCount),
	}
}

func (l *Layer) NewEntity() EntityID {
	id := l.entities.Length()
	entity := l.entities.NewAt(id)
	entity.ID = EntityID(id)

	return EntityID(id)
}

func Attach[T any](layer *Layer, entityID EntityID) *T {
	entity, ok := layer.entities.GetAt(int(entityID))
	if !ok {
		return nil
	}

	componentID := GetComponentID[T](layer)
	if layer.componentPool[componentID] == nil {
		layer.componentPool[componentID] = gomemory.NewPool[T](MaxEntityCount)
	}

	componentPool := layer.componentPool[componentID]
	component := (*T)(componentPool.NewAt(int(entityID)))

	entity.ComponentMask.Set(componentID)

	return component
}

func GetComponent[T any](layer *Layer, entityID EntityID) (*T, bool) {
	entity, entityExists := layer.entities.GetAt(int(entityID))
	if !entityExists {
		return nil, false
	}

	componentID := GetComponentID[T](layer)
	if !entity.ComponentMask.Has(componentID) {
		return nil, false
	}

	componentPool := layer.componentPool[componentID]

	memPtr, ok := componentPool.GetAt(int(entityID))
	if !ok {
		return nil, false
	}

	return (*T)(memPtr), true
}

func GetComponentID[T any](layer *Layer) ComponentID {
	componentType := reflect.TypeOf(new(T)).String()
	if id, ok := layer.componentIDs[componentType]; ok {
		return id
	}

	layer.componentIDs[componentType] = ComponentID(len(layer.componentIDs))

	return layer.componentIDs[componentType]
}

// const maxSize = 1024 * 1024

// type Layer struct {
// 	Entities   map[EntityID]*Entity
// 	Components map[EntityID][]*Component
// 	Systems    []System

// 	componentsArena *gomemory.MallocArena
// }

// func NewECS() *Layer {
// 	ecs := &Layer{
// 		Entities:        make(map[EntityID]*Entity, 0),
// 		Components:      make(map[EntityID][]*Component, 0),
// 		Systems:         make([]System, 0),
// 		componentsArena: gomemory.NewMallocArena(maxSize),
// 	}

// 	return ecs
// }

// func (e *Layer) Free() {
// 	// @Check.
// 	e.componentsArena.Free()
// }
