# Lesson 10 

## Challenge 1: `UniqueSum` (10 points)

Given an array nums of integers and an integer target, find the number of unique pairs in the array that add up to the target.

## Challenge 2: `ClosestSum` (10 points)

Given an array nums of n integers and an integer target, return the sum of the three integers in the array such that the sum is closest to the target.

## Challenge 3: `LongestSubstringWithKDistinct` (10 points)

Given a string s and an integer k, find the length of the longest substring that contains at most k distinct characters.

## Challenge 4: `MaxProfit` (10 points)

Given an array prices representing stock prices on consecutive days, find the maximum profit that could be obtained by buying and selling stocks.

## Challenge 5: Sliding Window (40 points)

Optimize the `DisplayLocationAtScreen` method at the `Renderer` class. It stores of a grid of size 9 x 9, but can only display a 3 x 3 screen and each load to subgrid takes 1 second to process (`LoadPixelsFromGridToScreen` method). 

Issue is setting elements of the screen is expensive in this exercise. You can't set or access the pixels in the screen or the grid; you must use the existing methods; 

You must use the `LoadPixelsFromGridToScreen` method to load the values from the grid.

Also, there is an unused `MovePixelsAcrossScreen` method, which is left by a previous developer as a potential way to optimize this. Perhaps you could utilize it...

Tests also have a time limit, so returning the correct answer without any optimization will not be sufficient.

## Challenge 6: `DetermineMeetingRoomCount` (20 points)

Given a list of meeting dates, determine the minimum amount of meeting rooms required to host all meetings.

## Challenge 7: Optimise Methods (Extension)

Rest of the methods given in `Challenges.cs` are implemented poorly, albeit in performance or readability. Can you improve them?