.DEFAULT_GOAL := all
BUILD_DIR := bin

TITLE := wooff

fmt:
	@gofmt -w .

build: fmt
	@go build -o $(BUILD_DIR)/$(TITLE) .

test: fmt
	@go test -v ./...

all: test build

clean:
	rm -rf $(BUILD_DIR)

%/.:
	mkdir -p $@