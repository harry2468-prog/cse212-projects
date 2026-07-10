using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("Low Priority", 1);
        pq.Enqueue("High Priority", 5);
        pq.Enqueue("Medium Priority", 3);

        Assert.AreEqual("High Priority", pq.Dequeue());
        Assert.AreEqual("Medium Priority", pq.Dequeue());
        Assert.AreEqual("Low Priority", pq.Dequeue());
    
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();

        pq.Enqueue("First Urgent Task", 3);
        pq.Enqueue("Low Priority Task", 1);
        pq.Enqueue("Second Urgent Task", 3);

        Assert.AreEqual("First Urgent Task", pq.Dequeue()); // "First" should come out before "Second"
        Assert.AreEqual("Second Urgent Task", pq.Dequeue());
        Assert.AreEqual("Low Priority Task", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}