package wooff

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

func TestAttachComponent(t *testing.T) {
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

func TestDetachComponent(t *testing.T) {
	t.Parallel()

	type someComponent struct {
		x    int
		y    int
		name string
	}

	layer := NewLayer()
	entity := layer.NewEntity()

	component := Attach[someComponent](layer, entity)
	component.x = 1
	component.y = 2
	component.name = "hello, world"

	e, ok := GetComponent[someComponent](layer, entity)
	if !ok {
		t.Fail() // @Cleanup.
	}

	if e != component {
		t.Fail()
	}

	Detach[someComponent](layer, entity)

	if _, ok := GetComponent[someComponent](layer, entity); ok {
		t.Fail()
	}

	if HasComponent[someComponent](layer, entity) {
		t.Fail()
	}
}

func TestRequestEntititesWith(t *testing.T) {
	t.Parallel()

	type Transform struct {
		X, Y, Z float64
	}

	type PlayerTag struct{}

	type EnemyTag struct{}

	layer := NewLayer()

	entity1 := layer.NewEntity()
	Attach[Transform](layer, entity1)
	Attach[PlayerTag](layer, entity1)

	entity2 := layer.NewEntity()
	Attach[Transform](layer, entity2)
	Attach[EnemyTag](layer, entity2)

	entity3 := layer.NewEntity()
	Attach[EnemyTag](layer, entity3)

	transformEntities := layer.Request(GetComponentID[Transform](layer))

	if len(transformEntities) != 2 {
		t.Fail()
	}

	if transformEntities[0] != entity1 {
		t.Fail()
	}

	if transformEntities[1] != entity2 {
		t.Fail()
	}

	transformEnemies := layer.Request(
		GetComponentID[EnemyTag](layer),
		GetComponentID[Transform](layer),
	)

	if len(transformEnemies) != 1 {
		t.Fail()
	}

	if transformEnemies[0] != entity2 {
		t.Fail()
	}

	enemies := layer.Request(GetComponentID[EnemyTag](layer))

	if len(enemies) != 2 {
		t.Fail()
	}

	if enemies[0] != entity2 || enemies[1] != entity3 {
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
