package wooff

type EntityID uint32

type Entity struct {
	ID         EntityID
	Components map[ComponentID]Component
}

func NewEntity() *Entity {
	return &Entity{}
}
