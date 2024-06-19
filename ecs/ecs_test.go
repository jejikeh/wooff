package ecs

import (
	"testing"
)

func TestGetComponentID(t *testing.T) {
	t.Parallel()

	type Transform3D struct {
		X, Y, Z float64
	}

	type Transform2D struct {
		X, Y float64
	}

	layer := NewLayer()

	transform3DID := GetComponentID[Transform3D](layer)
	if transform3DID != GetComponentID[Transform3D](layer) {
		t.Error("component id for the same type should be equal")
	}

	transform2DID := GetComponentID[Transform2D](layer)
	if transform2DID == transform3DID {
		t.Error("component id for the different types should be different")
	}
}

func TestAssignComponent(t *testing.T) {
	t.Parallel()

	type Transform struct {
		X, Y, Z int32
	}

	layer := NewLayer()
	entity := layer.NewEntity()

	if layer.entities.Length() != 1 {
		t.Error("entity should be in ecs layer")
	}

	entityTransform := Attach[Transform](layer, entity)
	entityTransform.X = 1
	entityTransform.Y = 2
	entityTransform.Z = 3

	if layer.componentPool[GetComponentID[Transform](layer)] == nil {
		t.Errorf("component pool %d wasnt initialized", GetComponentID[Transform](layer))
	}

	transform, ok := GetComponent[Transform](layer, entity)
	if !ok || transform == nil {
		t.Fail()
	}

	if transform.X != 1 || transform.Y != 2 || transform.Z != 3 {
		t.Fail()
	}
}

// func TestNewComponent(t *testing.T) {
// 	layer := NewECS()

// 	type Transform struct {
// 		X, Y, Z float64
// 	}

// 	transform := NewComponent[Transform](layer)
// 	if transform == nil {
// 		t.Fail()
// 	} else if GetComponentID[Transform](layer) == 0 {
// 		t.Errorf("component id expected to be %d, but got %d", 0, GetComponentID[Transform]())
// 	}
// }

// func TestNewLayer(t *testing) {
// 	if testLayer := NewLayer(); testLayer.ID != 0 {
// 		t.Error("First layer")
// 	}
// }.
