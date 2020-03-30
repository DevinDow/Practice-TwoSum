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
        /*// Brute Force = O(n^2)
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
        return null;*/


        // Less-than-half / greater-than-half approach = O(n + 0.5n + 1 + 1) = O(n)

        // build 2 dictionaries of values and their original indices since that's what needs to be returned
        // dictionaries map Nums to their Index (the Num is the key, the Index is the associated data to be stored)
        var numsLessThanHalf = new Dictionary<int, int>();
        var numsGreaterThanEqualHalf = new Dictionary<int,int>();
        for (int i=0; i<nums.Length; i++) // O(n)
        {
            //if (nums[i] > target) // could optimize by cutting down dataset if there were no negative nums
            //    continue;
            int half = target / 2;
            if (target % 2 == 0 && nums[i] == half) // Special Case: half of an even target in the list twice (since can't reuse a num)
            {
                // if half already in Dictionary then success
                if (numsGreaterThanEqualHalf.ContainsKey(half)) // O(1)
                {
                    return new int[] { i, numsGreaterThanEqualHalf[half] }; // O(1)
                }
                // otherwise add half to Dictionary
                numsGreaterThanEqualHalf.Add(half, i);
                continue;
            }
            if (nums[i] < half) // (optimization of splitting dataset)
            {
                // skip duplicates
                if (numsLessThanHalf.ContainsKey(nums[i])) // O(1)
                    continue;
                numsLessThanHalf.Add(nums[i], i); // O(1)
                // TODO: could check if solution is already in Hash and return early (could finish in O(0.5n))
            }
            else
            {
                // skip duplicates
                if (numsGreaterThanEqualHalf.ContainsKey(nums[i])) // O(1)
                    continue;
                numsGreaterThanEqualHalf.Add(nums[i], i); // O(1)
            }
        }

        // loop numsLessThanHalf, find a partner in numsGreaterThanHalf
        foreach (int num in numsLessThanHalf.Keys) // O(0.5n) = O(n)
        {
            int partner = target - num;
            if (numsGreaterThanEqualHalf.ContainsKey(partner)) // O(1)
            {
                return new int[] { numsLessThanHalf[num], numsGreaterThanEqualHalf[partner]}; // O(1)
            }
        }
        return null;
    }
}
