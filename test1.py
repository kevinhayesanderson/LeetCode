from typing import List, DefaultDict

class Solution: 
    def maximumGap(self, nums: List[int]) -> int:
        mmin = min(nums)
        mmax = max(nums)
        n = len(nums)

        if n < 2:
            return 0

        bucketSize = max(1, (mmax - mmin) // (n - 1))
        buckets = DefaultDict(list)  # [max, min]

        for num in nums:
            key = (num - mmin) // bucketSize
            if not buckets[key]:
                buckets[key] = [num, num]
            else:
                buckets[key] = [max(buckets[key][0], num), min(buckets[key][1], num)]
        
        ans = 0
        preKey = -1
        for key in sorted(buckets.keys()):
            if preKey != -1:
                ans = max(ans, buckets[key][1] - buckets[preKey][0])
            
            preKey = key
        
        return ans
    
    # https://leetcode.com/problems/spiral-matrix/
    def spiralOrder(self, matrix: List[List[int]]) -> List[int]:
        res = []
        left, right = 0, len(matrix[0])
        top, bottom = 0, len(matrix)

        while left < right and top < bottom:
            # get every i in top row
            # end of range in exclusive
            for i in range(left, right):
                res.append(matrix[top][i])
            top += 1
            # get every i in right col
            for i in range(top, bottom):
                res.append(matrix[i][right - 1])
            right -= 1

            # for row matrix and column matrix
            if not (left < right and top < bottom):
                break

            # get every i in bottom row
            # -1 reverse order
            for i in range(right - 1, left - 1, -1):
                res.append(matrix[bottom - 1][i])
            bottom -= 1

            # get every i in left col
            for i in range(bottom - 1, top - 1, -1):
                res.append(matrix[i][left])
            left += 1

        return res
        
    # https://leetcode.com/problems/spiral-matrix-ii/
    def generateMatrix(self, n: int) -> List[List[int]]:
        res = [[0] * n for _ in range(n)]

        left, right = top, bottom = 0, n - 1
        val = 1

        while left <= right and top <= bottom:
            # left to right
            for i in range(left, right + 1):
                res[top][i] = val
                val += 1
            top += 1

            # top to bottom
            for i in range(top, bottom + 1):
                res[i][right] = val
                val += 1
            right -= 1

            # right to left
            for i in range(right, left - 1, -1):
                res[bottom][i] = val
                val += 1
            bottom -= 1

            # bottom to top
            for i in range(bottom, top - 1, -1):
                res[i][left] = val
                val += 1
            left += 1

        return res

sol = Solution()
sol.maximumGap(nums=[3,6,9,1])