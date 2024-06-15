package wooff

import (
	"github.com/jejikeh/gomemory"
)

const maxSize = 1024 * 1024

type ECS struct {
	Entities   map[EntityID]Entity
	Components [][]*Component
	Systems    []System

	gomemory.MallocArena
}

func NewECS() *ECS {
	return &ECS{
		Entities:    make(map[EntityID]Entity, 0),
		Components:  make([][]*Component, 0),
		Systems:     make([]System, 0),
		MallocArena: *gomemory.NewMallocArena(maxSize),
	}
}
