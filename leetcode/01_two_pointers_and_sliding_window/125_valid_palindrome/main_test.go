package main

import (
	"testing"
)

func TestIsPalindrome(t *testing.T) {
	tests := []struct {
		name string
		s    string
		want bool
	}{
		{
			name: "Example 1",
			s:    "A man, a plan, a canal: Panama",
			want: true,
		},
		{
			name: "Example 2",
			s:    "race a car",
			want: false,
		},
		{
			name: "Example 3",
			s:    " ",
			want: true,
		},
		{
			name: "Single character with punctuation",
			s:    "a.",
			want: true,
		},
		{
			name: "Digits and uppercase",
			s:    "0P",
			want: false,
		},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got := isPalindrome(tt.s)
			if got != tt.want {
				t.Errorf("isPalindrome(%q) = %v, want %v", tt.s, got, tt.want)
			}
		})
	}
}
