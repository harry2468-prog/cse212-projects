public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // PLAN:
        // Step 1: Create a new fixed array of doubles with the specified 'length'.
        // Step 2: Use a for-loop to iterate 'length' times (from index 0 to length - 1).
        // Step 3: Inside the loop, calculate the multiple by multiplying the 'number' by (index + 1).
        // Step 4: Store that calculated value into the array at the current index.
        // Step 5: Return the fully populated array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // PLAN:
        // Step 1: Calculate the split index. Since we are rotating right, the last 'amount' of items 
        //         will move to the front. The split index is (total count - amount).
        // Step 2: Create a copy of the back part of the list (the items moving to the front).
        // Step 3: Create a copy of the front part of the list (the items shifting to the right).
        // Step 4: Clear the original list so it is empty.
        // Step 5: Add the back part back into the list first.
        // Step 6: Add the front part back into the list second.

        int splitIndex = data.Count - amount;

        // Get the two slices of the list using GetRange(startingIndex, count)
        List<int> backPart = data.GetRange(splitIndex, amount);
        List<int> frontPart = data.GetRange(0, splitIndex);

        // Clear the original list
        data.Clear();

        // Rebuild the list in the rotated order using AddRange
        data.AddRange(backPart);
        data.AddRange(frontPart);
    }
}
