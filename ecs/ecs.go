package ecs

import (
	"github.com/jejikeh/gomemory"
)

const maxSize = 1024 * 1024

type ECS struct {
	Entities   map[EntityID]*Entity
	Components map[EntityID][]*Component
	Systems    []System

	componentsArena *gomemory.MallocArena
}

func NewECS() *ECS {
	ecs := &ECS{
		Entities:        make(map[EntityID]*Entity, 0),
		Components:      make(map[EntityID][]*Component, 0),
		Systems:         make([]System, 0),
		componentsArena: gomemory.NewMallocArena(maxSize),
	}

	return ecs
}

func (e *ECS) Free() {
	// @Check.
	e.componentsArena.Free()
}
