using System;
using System.Collections.Generic;

public class Solution
{
    /*  https://leetcode.com/problems/two-sum/
        Given an array of integers, return indices of the two numbers such that they add up to a specific target.

        You may assume that each input would have exactly one solution, and you may not use the same element twice.

        Example:

        Given nums = [2, 7, 11, 15], target = 9,

        Because nums[0] + nums[1] = 2 + 7 = 9,
        return [0, 1].
    */
    public int[] TwoSum(int[] nums, int target)
    {
        // Brute Force = O(n^2)
        for (int i=0; i<nums.Length; i++) {
            //if (nums[i] > target) { // don't do this optimization, because it can include negative numbers
            //    continue;
            //}
            
            for (int j=i+1; j<nums.Length; j++) {
                //if (nums[j] > target) { // don't do this optimization, because it can include negative numbers
                //    continue;
                //}

                if (nums[i]+nums[j] == target) {
                    return new int[] {i,j};
                }
            }
        }
        return null;


        // Less-than-half / greater-than-half approach = O(n + 0.5n + 1 + 1) = O(n)
        // (half is out since can't use the same number twice)

        // build 2 lists of values and their original indices since that's what needs to be returned
        var numsLessThanHalf = new List<Pair>();
        var numsGreaterThanHalf = new Dictionary<int,int>(); // maps Nums to their Index (the Num is the key, the Index is the associated data to be stored)
        for (int i=0; i<nums.Length; i++) // O(n)
        {
            //if (nums[i] > target) // could optimize by cutting down dataset if there were no negative numbers
            //    continue;
            int half = target / 2;
            if (target % 2 == 0 && nums[i] == half) // half of an even target is out since can't use the same number twice
                continue;
            if (nums[i] < half) // (optimization of splitting dataset)
            {
                numsLessThanHalf.Add(new Pair(i, nums[i]));
                // could check if solution is already in Hash and return early (could finish in O(0.5n))
            }
            else
                numsGreaterThanHalf.Add(nums[i], i);
        }

        // loop numsLessThanHalf, find a partner in numsGreaterThanHalf
        foreach (Pair pair in numsLessThanHalf) // O(0.5n) = O(n)
        {
            int partner = target - pair.val;
            if (numsGreaterThanHalf.ContainsKey(partner)) // O(1)
            {
                return new int[] { pair.i, numsGreaterThanHalf[partner]}; // O(1)
            }
        }
        return null;
    }

    struct Pair
    {
        public int i;
        public int val;

        public Pair(int i, int val)
        {
            this.i = i;
            this.val = val;
        }
    }

}
