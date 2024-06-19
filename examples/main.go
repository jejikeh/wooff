package main

import (
	"fmt"
	"time"
	"github.com/jejikeh/wooff"
)

type Info struct {
	Name string
	Job string
}

type Speed float64

func speedIncrease(layer *wooff.Layer) {
	for _, entity := range layer.Request(wooff.GetComponentID[Speed](layer)) {
		speed, _ := wooff.GetComponent[Speed](layer, entity)
		if *speed < 0 {
			*speed += 0.01
		}
	}
}

func speak(layer *wooff.Layer) {
	entities := layer.Request(
		wooff.GetComponentID[Speed](layer), 
		wooff.GetComponentID[Info](layer),
	)
	
	for _, entity := range entities {
		info, _ := wooff.GetComponent[Info](layer, entity)
		speed, _ := wooff.GetComponent[Speed](layer, entity)
		fmt.Printf("title: %s\n description: %s\n speed: %f\n----------------\n", info.Name, info.Job, *speed)
		_ = info
		_ = speed
	}
}

func main() {
	layer := wooff.NewLayer()
	
	for range 100 {
		jon := layer.NewEntity()
		
		jonSpeed := wooff.Attach[Speed](layer, jon)
		*jonSpeed = -10
		
		jonInfo := wooff.Attach[Info](layer, jon)
		jonInfo.Name = "Jon"
		jonInfo.Job = "Miner"
		
		mark := layer.NewEntity()
		
		markSpeed := wooff.Attach[Speed](layer, mark)
		*markSpeed = 100
		
		markInfo := wooff.Attach[Info](layer, mark)
		markInfo.Name = "Mark"
		markInfo.Job = "Football Player"
	}
	
	start := time.Now()
	
	for range 100 {
		speak(layer)
		speedIncrease(layer)
	}
	
	duration := time.Since(start)	
	fmt.Println(duration.Milliseconds())
}