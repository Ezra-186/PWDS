using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, then dequeue all.
    // Expected Result: Highest priority first each time: "C", "A", "B".
    // Defect(s) Found: Dequeue didn't remove item; same highest value returned repeatedly.
    public void TestPriorityQueue_BasicHighestWins()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 9);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: All priorities are equal (tie) and inserted in order A,B,C.
    // Expected Result: FIFO among ties: "A", then "B", then "C".
    // Defect(s) Found: Tie logic used >= and returned the last tied item first.
    public void TestPriorityQueue_TiesUseFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 7);
        priorityQueue.Enqueue("B", 7);
        priorityQueue.Enqueue("C", 7);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: The highest priority item is at the last index.
    // Expected Result: Return and remove "Z" first, then "B", then "A".
    // Defect(s) Found: Loop stopped at Count-1 and skipped comparing the last element.
    public void TestPriorityQueue_HighestAtEnd()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("Z", 99);

        Assert.AreEqual("Z", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Interleave enqueues and dequeues; tie at highest priority.
    // Expected Result: "H1", "H2", "M1", "L1" in order.
    // Defect(s) Found: Same as above if removal not performed or ties mishandled.
    public void TestPriorityQueue_InterleavedOperations()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("M1", 5);
        priorityQueue.Enqueue("L1", 1);
        priorityQueue.Enqueue("H1", 9);
        Assert.AreEqual("H1", priorityQueue.Dequeue());

        priorityQueue.Enqueue("H2", 9);
        Assert.AreEqual("H2", priorityQueue.Dequeue());
        Assert.AreEqual("M1", priorityQueue.Dequeue());
        Assert.AreEqual("L1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue on an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None after fix; message must match exactly.
    public void TestPriorityQueue_EmptyThrows()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}