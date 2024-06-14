package wooff

import (
	"testing"

	"github.com/jejikeh/gomemory"
)

func TestNewComponentDifferentIDs(t *testing.T) {
	a := gomemory.NewMallocArena(1024)
	defer a.Free()

	type TestComponent1 struct {
		Component
		X int
		Y int
	}

	c1 := NewComponent[TestComponent1](a)
	c1.X = 1
	c1.Y = 2

	type TestComponent2 struct {
		Component
		Speed float32
	}

	c2 := NewComponent[TestComponent2](a)
	c2.Speed = 123

	type TestComponent3 struct {
		Component
		X int
		Y int
	}

	c3 := NewComponent[TestComponent3](a)
	c3.X = 1
	c3.Y = 2

	c4 := NewComponent[TestComponent3](a)
	c4.X = 3
	c4.Y = 4

	assertEqual(t, GetComponentID[TestComponent1](), 0)
	assertEqual(t, GetComponentID[TestComponent2](), 1)
	assertEqual(t, GetComponentID[TestComponent3](), 2)

	assertEqual(t, c1.X, 1)
	assertEqual(t, c1.Y, 2)

	assertEqual(t, c2.Speed, 123)

	assertEqual(t, c3.X, 1)
	assertEqual(t, c3.Y, 2)

	assertEqual(t, c4.X, 3)
	assertEqual(t, c4.Y, 4)
}

func assertEqual[T comparable](t *testing.T, a, b T) {
	if a != b {
		t.Errorf("Expected %v, got %v", a, b)
	}
}
