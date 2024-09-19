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
    
sol = Solution()
sol.maximumGap(nums=[3,6,9,1])