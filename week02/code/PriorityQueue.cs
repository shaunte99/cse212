public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Remove and return the item with the highest priority.
    /// If multiple items have the same highest priority, return the one that was added first (FIFO).
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highPriorityIndex = 0;

        // Loop through the full list
        for (int index = 1; index < _queue.Count; index++)
        {
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); // remove the selected item from the list
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
