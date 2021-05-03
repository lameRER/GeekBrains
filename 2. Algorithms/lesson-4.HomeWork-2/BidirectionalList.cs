using System.Text;

namespace lesson_4.HomeWork_2
{
    public class BidirectionalList : ILinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }
        private int Count { get; set; }

        public int GetCount()
        {
            return Count;
        }

        public void AddNode(int value)
        {
            var node = new Node(value);
            AddNodeAfter(node, value);
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.NextNode = node;
                node.PrevNode = Tail;
            }

            Tail = node;
            Count++;
        }

        public void RemoveNode(int index)
        {
            var node = Head;
            var indexNode = 0;
            while (node != null)
            {
                if (indexNode == index) RemoveNode(node);
                node = node.NextNode;
                indexNode++;
            }
        }

        public void RemoveNode(Node node)
        {
            if (node.PrevNode == null) Head = node.NextNode;
            else node.PrevNode.NextNode = node.NextNode;
            if (node.NextNode == null)
            {
                if (node.PrevNode != null)
                {
                    node.PrevNode.NextNode = null;
                    Tail = node.PrevNode;
                }
            }
            else
            {
                node.NextNode.PrevNode = node.PrevNode;
            }

            Count--;
        }

        public Node FindNode(int searchValue)
        {
            var node = Head;
            while (node != null)
            {
                if (node.Value == searchValue) return node;
                node = node.NextNode;
            }

            return null;
        }

        public override string ToString()
        {
            const string nString = "NULL";
            var builder = new StringBuilder();
            var node = Head;
            var indexNode = 0;
            builder.AppendLine($"Count: {GetCount()}");
            while (node != null)
            {
                if (node == Head) builder.AppendLine($"Head node: idx({indexNode} value: {node.Value.ToString()})");
                builder.AppendLine($"idx: ({indexNode}) Pre.: ({(node.PrevNode == null ? nString : node.PrevNode.Value.ToString())}) <- Value: ({node.Value.ToString()}) -> Next: ({(node.NextNode == null ? nString : node.NextNode.Value.ToString())})");
                if (node == Tail) builder.AppendLine($"tail node: idx({indexNode}) Value: ({node.Value.ToString()})");
                node = node.NextNode;
                indexNode++;
            }

            return builder.ToString();
        }
    }
}