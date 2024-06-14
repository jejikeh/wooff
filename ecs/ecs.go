package wooff

type ECS struct {
	Entities   map[EntityID]Entity
	Components [][]*Component
	Systems    []System
}

func (e *ECS) CreateEntity() {

}

func (e *ECS) DestroyEntity(id EntityID) {

}
