using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;  // Needed for InvalidOperationException

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and ensure Dequeue returns the highest priority first.
    // Expected Result: Items are dequeued in order of descending priority.
    // Defect(s) Found: None. The items dequeued in the correct order.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task A", 1); // Low priority
        priorityQueue.Enqueue("Task B", 3); // Highest priority
        priorityQueue.Enqueue("Task C", 2); // Medium

        var first = priorityQueue.Dequeue();  // Should be Task B
        var second = priorityQueue.Dequeue(); // Should be Task C
        var third = priorityQueue.Dequeue();  // Should be Task A

        Assert.AreEqual("Task B", first);
        Assert.AreEqual("Task C", second);
        Assert.AreEqual("Task A", third);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority. Dequeue should follow FIFO order.
    // Expected Result: Items are dequeued in the order they were added.
    // Defect(s) Found: None. FIFO order was correctly followed.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Alpha", 5);
        priorityQueue.Enqueue("Beta", 5);
        priorityQueue.Enqueue("Gamma", 5);

        var first = priorityQueue.Dequeue();  // Should be Alpha
        var second = priorityQueue.Dequeue(); // Should be Beta
        var third = priorityQueue.Dequeue();  // Should be Gamma

        Assert.AreEqual("Alpha", first);
        Assert.AreEqual("Beta", second);
        Assert.AreEqual("Gamma", third);
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown.
    // Defect(s) Found: None. Exception was correctly thrown.
    public void TestPriorityQueue_EmptyDequeueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}
