FROM golang:1.22.0 as build

WORKDIR /go/src/app
COPY ./main.go  .

RUN go mod init github.com/mydistroless && \
 go mod tidy && \
  go vet -v

RUN CGO_ENABLED=0 go build -o /go/bin/app

# Now copy the go binary into the base image.
FROM gcr.io/distroless/static-debian12

COPY --from=build /go/bin/app /

ENTRYPOINT ["/app"]