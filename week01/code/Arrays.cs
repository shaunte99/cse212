 public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN FOR MULTIPLES OF:
        // 1. Create an array of type double with size 'length'.
        // 2. Use a loop from i = 0 to i < length.
        // 3. At each index i, calculate the multiple: number * (i + 1).
        // 4. Store that result in the array at index i.
        // 5. After loop ends, return the array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 3 then 
    /// the result will be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// This function modifies the original list (in-place).
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // ✅ PLAN FOR ROTATE LIST RIGHT:
        // 1. Get the last 'amount' of items from the list using GetRange.
        // 2. Remove those last 'amount' items from the list.
        // 3. Insert the removed items at the front of the list using InsertRange at index 0.
        // 4. This modifies the list in-place.

        int count = data.Count;
        List<int> endSlice = data.GetRange(count - amount, amount); // Get the last 'amount' items
        data.RemoveRange(count - amount, amount);                   // Remove them from the end
        data.InsertRange(0, endSlice);                              // Insert them at the start
    }
}
