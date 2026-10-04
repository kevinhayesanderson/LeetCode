package main

import (
	"reflect"
	"sort"
	"testing"
)

// normalizeTriplets sorts each triplet and the outer list of triplets for consistent equality checks.
func normalizeTriplets(triplets [][]int) [][]int {
	res := make([][]int, len(triplets))
	for i, t := range triplets {
		clone := make([]int, len(t))
		copy(clone, t)
		sort.Ints(clone)
		res[i] = clone
	}

	sort.Slice(res, func(i, j int) bool {
		for k := 0; k < len(res[i]) && k < len(res[j]); k++ {
			if res[i][k] != res[j][k] {
				return res[i][k] < res[j][k]
			}
		}
		return len(res[i]) < len(res[j])
	})

	return res
}

func TestThreeSum(t *testing.T) {
	tests := []struct {
		name string
		nums []int
		want [][]int
	}{
		{
			name: "Example 1",
			nums: []int{-1, 0, 1, 2, -1, -4},
			want: [][]int{{-1, -1, 2}, {-1, 0, 1}},
		},
		{
			name: "Example 2",
			nums: []int{0, 1, 1},
			want: [][]int{},
		},
		{
			name: "Example 3",
			nums: []int{0, 0, 0},
			want: [][]int{{0, 0, 0}},
		},
		{
			name: "All zeroes",
			nums: []int{0, 0, 0, 0},
			want: [][]int{{0, 0, 0}},
		},
		{
			name: "Multiple duplicates",
			nums: []int{-2, 0, 1, 1, 2},
			want: [][]int{{-2, 0, 2}, {-2, 1, 1}},
		},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got := threeSum(tt.nums)
			normGot := normalizeTriplets(got)
			normWant := normalizeTriplets(tt.want)

			if !reflect.DeepEqual(normGot, normWant) {
				t.Errorf("threeSum() = %v, want %v", normGot, normWant)
			}
		})
	}
}
