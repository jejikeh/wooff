package wooff

import (
	"testing"
)

func TestNewComponentDifferentIDs(t *testing.T) {
	c1 := NewComponent(&struct {
		Component
		X int
		Y int
	}{
		X: 1,
		Y: 2,
	})

	c2 := NewComponent(&struct {
		Component
		Speed float32
	}{
		Speed: 123,
	})

	type TestComponent struct {
		Component
		X int
		Y int
	}

	c3 := NewComponent(&TestComponent{
		X: 1,
		Y: 2,
	})

	c4 := NewComponent(&TestComponent{
		X: 3,
		Y: 4,
	})

	assertEqual(t, c1.ID, 0)
	assertEqual(t, c2.ID, 1)

	assertEqual(t, c3.ID, 2)
	assertEqual(t, c4.ID, 2)
}

func assertEqual[T comparable](t *testing.T, a, b T) {
	if a != b {
		t.Errorf("Expected %v, got %v", a, b)
	}
}
