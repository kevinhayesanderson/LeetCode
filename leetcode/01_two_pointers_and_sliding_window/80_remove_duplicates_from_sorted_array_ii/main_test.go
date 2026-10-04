package main

import (
	"reflect"
	"testing"
)

func TestRemoveDuplicates(t *testing.T) {
	tests := []struct {
		name      string
		nums      []int
		wantK     int
		wantSlice []int
	}{
		{
			name:      "Example 1",
			nums:      []int{1, 1, 1, 2, 2, 3},
			wantK:     5,
			wantSlice: []int{1, 1, 2, 2, 3},
		},
		{
			name:      "Example 2",
			nums:      []int{0, 0, 1, 1, 1, 1, 2, 3, 3},
			wantK:     7,
			wantSlice: []int{0, 0, 1, 1, 2, 3, 3},
		},
		{
			name:      "Short array already valid",
			nums:      []int{1, 1},
			wantK:     2,
			wantSlice: []int{1, 1},
		},
		{
			name:      "Three of the same element",
			nums:      []int{1, 1, 1},
			wantK:     2,
			wantSlice: []int{1, 1},
		},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			input := make([]int, len(tt.nums))
			copy(input, tt.nums)

			gotK := removeDuplicates(input)
			if gotK != tt.wantK {
				t.Errorf("removeDuplicates() k = %v, want %v", gotK, tt.wantK)
			}
			if gotK > len(input) {
				t.Fatalf("k = %d exceeds slice length %d", gotK, len(input))
			}
			if !reflect.DeepEqual(input[:gotK], tt.wantSlice) {
				t.Errorf("modified nums = %v, want %v", input[:gotK], tt.wantSlice)
			}
		})
	}
}
