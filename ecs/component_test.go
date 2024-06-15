package wooff

import (
	"testing"
)

func TestNewComponentDifferentIDs(t *testing.T) {
	t.Parallel()

	ecs := NewECS()
	defer ecs.Free()

	type TestComponent1 struct {
		Component
		X int
		Y int
	}

	component1 := NewComponent[TestComponent1](ecs)
	component1.X = 1
	component1.Y = 2

	type TestComponent2 struct {
		Component
		Speed float32
	}

	component2 := NewComponent[TestComponent2](ecs)
	component2.Speed = 123

	type TestComponent3 struct {
		Component
		X int
		Y int
	}

	component3 := NewComponent[TestComponent3](ecs)
	component3.X = 1
	component3.Y = 2

	component4 := NewComponent[TestComponent3](ecs)
	component4.X = 3
	component4.Y = 4

	testAssertEqual(t, GetComponentID[TestComponent1](), 0)
	testAssertEqual(t, GetComponentID[TestComponent2](), 1)
	testAssertEqual(t, GetComponentID[TestComponent3](), 2)

	testAssertEqual(t, component1.X, 1)
	testAssertEqual(t, component1.Y, 2)

	testAssertEqual(t, component2.Speed, 123)

	testAssertEqual(t, component3.X, 1)
	testAssertEqual(t, component3.Y, 2)

	testAssertEqual(t, component4.X, 3)
	testAssertEqual(t, component4.Y, 4)
}

func testAssertEqual[T comparable](t *testing.T, a, b T) {
	t.Helper()

	if a != b {
		t.Errorf("Expected %v, got %v", a, b)
	}
}
