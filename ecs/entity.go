package ecs

// import (
// 	"errors"
// )

// var (
// 	ErrComponentAlreadyAttachedToEntity = errors.New("component already attached to entity")
// 	ErrComponentNotFound                = errors.New("component not found")
// )

// type EntityID uint32

// type Entity struct {
// 	components map[ComponentID]any
// }

// func NewEntity(addComponents ...func(*Entity)) *Entity {
// 	entity := &Entity{
// 		components: make(map[ComponentID]any, len(componentIDs)),
// 	}

// 	for _, addComponent := range addComponents {
// 		addComponent(entity)
// 	}

// 	return entity
// }

// func AttachToEntity[T any](entity *Entity, component T) {
// 	componentID := GetComponentID[T]()

// 	if _, ok := entity.components[componentID]; ok {
// 		panic(ErrComponentAlreadyAttachedToEntity)
// 	}

// 	entity.components[componentID] = component
// }

// func GetComponent[T any](entity *Entity) *T {
// 	componentID := GetComponentID[T]()
// 	if v, ok := entity.components[componentID]; !ok {
// 		panic(ErrComponentNotFound)
// 	} else {
// 		switch p := any(

// 		return c
// 	}
// }
