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
        //// Brute Force approach O(2n)
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    if (nums[i] > target)
        //    {
        //        continue;
        //    }

        //    for (int j = i + 1; j < nums.Length; j++)
        //    {
        //        if (nums[j] > target)
        //        {
        //            continue;
        //        }

        //        if (nums[i] + nums[j] == target)
        //        {
        //            return new int[] { i, j };
        //        }
        //    }
        //}
        //return null;


        // Less-than-half / greater-than-half approach
        var numsLessThanHalf = new List<int>();
        var numsGreaterThanHalf = new HashSet<int>();
        foreach (int num in nums) // build 2 lists
        {
            if (num > target) // assuming no negatives (optimization of cutting down dataset)
                continue;
            int half = target / 2;
            if (target % 2 == 0 && num == half) // half of an even target is out since can't use the same number twice
                continue;
            if (num < half) // (optimization of splitting dataset)
            {
                numsLessThanHalf.Add(num);
                // could check if solution is already in Hash and return early (could finish in O(0.5n))
            }
            else
                numsGreaterThanHalf.Add(num);
        }
        foreach (int num in numsLessThanHalf) // O(n)
        {
            int partner = target - num;
            if (numsGreaterThanHalf.Contains(partner)) // O(1)
            {
                return new int[] { num, partner };
            }
        }
        return null;
    }
}