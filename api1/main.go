package main

import (
    "encoding/json"
    "fmt"
	"net/http"
)

func main() {
	http.HandleFunc("/", Handler)
	http.HandleFunc("/abc", Handler2)
	http.ListenAndServe(":8080", nil)
}

func Handler(w http.ResponseWriter, r *http.Request) {
	response := Response{One:"test1", Two:	10, Three: true}
	jsonResponse, err := json.Marshal(response)
	if err != nil {
		panic(err)
	}

	fmt.Fprintf(w, string(jsonResponse))
}

func Handler2(w http.ResponseWriter, r *http.Request) {
	response := Response{One:"abc", Two:	10, Three: true}
	jsonResponse, err := json.Marshal(response)
	if err != nil {
		panic(err)
	}

	fmt.Fprintf(w, string(jsonResponse))
}
type Response struct {
	One string
	Two int
	Three bool
}