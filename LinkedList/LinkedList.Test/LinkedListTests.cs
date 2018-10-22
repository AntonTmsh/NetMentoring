using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LinkedList.Test
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void AddAtElementAt_Success_Cases()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddAt(1, 0);
            list.AddAt(2, 1);
            list.AddAt(3, 2);
            Assert.AreEqual(3, list.Length());
            Assert.AreEqual(list.HeadNode.Value, 1);
            Assert.AreEqual(list.TailNode.Value, 3);
            list.AddAt(4, 2);
            Assert.AreEqual(4, list.Length());
            Assert.AreEqual(list.TailNode.Value, 3);
            Assert.AreEqual(list.ElementAt(0), 1);
            Assert.AreEqual(list.ElementAt(2), 4);
            Assert.AreEqual(list.ElementAt(3), 3);
        }

        [Test, TestCaseSource("Add_Success_Cases")]
        public void AddFirst_Success_Cases(int[] testCase)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int value in testCase)
            {
                list.Add(value);
            }

            Assert.AreEqual(testCase.Length, list.Length(),
                "There was an unexpected number of list items");

            Assert.AreEqual(testCase.Last(), list.HeadNode.Value,
                "The first item value was incorrect");

            Assert.AreEqual(testCase.First(), list.TailNode.Value,
                "The last item value was incorrect");

            int[] reversed = testCase.Reverse().ToArray();
            int current = 0;

            foreach (int value in list)
            {
                Assert.AreEqual(reversed[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [Test]
        public void RemoveFirstPosition_Empty_Lists()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.AreEqual(0, list.Length());
            Assert.IsNull(list.HeadNode);
            Assert.IsNull(list.TailNode);

            list.RemoveAt(0);
            Assert.AreEqual(0, list.Length());
            Assert.IsNull(list.HeadNode);
            Assert.IsNull(list.TailNode);
        }

        [Test]
        public void RemoveFirst_One_Node()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Add(1);
            list.RemoveAt(0);
            Assert.AreEqual(0, list.Length());
            Assert.IsNull(list.HeadNode);
            Assert.IsNull(list.TailNode);

            list.Add(2);
            list.Remove(2);
            Assert.AreEqual(0, list.Length());
            Assert.IsNull(list.HeadNode);
            Assert.IsNull(list.TailNode);
        }

        [Test]
        public void RemoveFirstLast_Two_Node()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.Add(1);
            list.Add(2);

            list.RemoveAt(0);
            Assert.AreEqual(1, list.Length());
            Assert.AreEqual(1, list.HeadNode.Value);
            Assert.AreEqual(1, list.TailNode.Value);

            list.Add(3);
            list.RemoveAt(1);
            Assert.AreEqual(1, list.Length());
            Assert.AreEqual(3, list.HeadNode.Value);
            Assert.AreEqual(3, list.TailNode.Value);

            list.Add(4);
            list.Add(5);
            list.Add(6);
            Assert.AreEqual(4, list.Length());
            list.RemoveAt(2);
            Assert.AreEqual(3, list.Length());
            Assert.AreEqual(6, list.HeadNode.Value);
            Assert.AreEqual(3, list.TailNode.Value);
        }

        [Test]
        public void RemoveLast_Ten_Nodes()
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            for (int i = 10; i > 0; i--)
            {
                Assert.AreEqual(i, list.Length(), "Unexpected list count");
                //Remove Last
                list.RemoveAt(i - 1);
            }

            Assert.AreEqual(0, list.Length());
            Assert.IsNull(list.HeadNode);
            Assert.IsNull(list.TailNode);
        }


        [Test, TestCaseSource("Remove_Unsuccessful_Cases")]
        public void Remove_Missing(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.Add(data);
            }

            Assert.IsFalse(list.Remove(value), "Nothing should have been removed");
            Assert.AreEqual(testData.Length, list.Length(), "The list Length was incorrect");
        }

        [Test, TestCaseSource("Remove_Successful_Cases")]
        public void Remove_Found(int[] testData, int value)
        {
            LinkedList<int> list = new LinkedList<int>();
            foreach (int data in testData)
            {
                list.Add(data);
            }

            Assert.IsTrue(list.Remove(value), "A node should have been removed");
            Assert.AreEqual(testData.Length - 1, list.Length(), "The list Length was incorrect");
        }

        static object[] Add_Success_Cases =
        {
            new int[] {0},
            new int[] {0, 1},
            new int[] {0, 1, 2},
            new int[] {0, 1, 2, 3},
        };

        static object[] Remove_Unsuccessful_Cases =
        {
            new object[] {new int[] {0}, 10},
            new object[] {new int[] {0, 1}, 10},
            new object[] {new int[] {0, 1, 2}, 10},
            new object[] {new int[] {0, 1, 2, 3}, 10}
        };

        static object[] Remove_Successful_Cases =
        {
            new object[] {new int[] {10}, 10},
            new object[] {new int[] {10, 0}, 10},
            new object[] {new int[] {0, 10}, 10},
            new object[] {new int[] {0, 0, 10}, 10},
            new object[] {new int[] {0, 10, 0}, 10},
            new object[] {new int[] {10, 0, 0}, 10},
        };
    }
}