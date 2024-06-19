package main

// import (
// 	"fmt"

// 	"github.com/jejikeh/wooff/ecs"
// )

// type (
// 	EntityName string
// 	PlayerTag  struct{}
// )

// type Transform struct {
// 	X, Y, Z float64
// }

// type EngineTime struct {
// 	DeltaTime float64
// }

// func NewTransform(x, y, z float64) *Transform {
// 	return &Transform{x, y, z}
// }

// func main() {
// 	engineLayer := ecs.NewLayer()

// 	ecs.RegisterComponent[Transform](engineLayer)
// 	ecs.RegisterComponent[PlayerTag](engineLayer)

// 	ecs.RegisterSingleton[EngineTime](engineLayer)

// 	ecs.RegisterSystem()

// 	engineTime := ecs.NewEntity(&EngineTime{})
// 	player := ecs.NewEntity(NewTransform(1, 1, 1), &PlayerTag{}, EntityName("Player"))
// }

// type HandlePlayerMovement struct{}

// func (s *HandlePlayerMovement) Update(layer *ecs.Layer) {
// 	dt, _ := ecs.GetSingleton[EngineTime](layer)

// 	for _, entity := range ecs.GetEntitiesWith[PlayerTag, Transform]() {
// 		t := ecs.GetComponent[Transform](entity)
// 	}
// }
