namespace generic_list;

public class GenericList<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;

        public Node(T t)
        {
            Value = t;
            Next = null;
        }
    }

    private Node? Head;
    private int Count;
    

    public GenericList()
    {
        Head = null;
    }

    public void Add(T input) 
    {   
        if (Head == null)
        {
            Head = new Node(input);            
        }
        else
        {
            //Encontra onde inserir o próximo nó na lista.
            Node lastNode = Head;
            while(lastNode.Next != null)   lastNode = lastNode.Next;

            lastNode.Next = new Node(input);                        
        }
    }

    public void Print()
    {
        Node? printNode = Head;
        while(printNode.Next != null)
        {
            Console.Write(printNode.Value + " ");
            printNode = printNode.Next;
        }
        Console.WriteLine(printNode.Value);
    }

    public T Index(int index)
    {
        Node? item = Head;

        if (index == null)
        {
            throw new InvalidOperationException("Não há elementos suficientes na lista");
        }

        for (int i = 0; i < index; i++)
        {
            if (item.Next == null)
            {
                throw new InvalidOperationException("Não há elementos suficientes na lista");
            }

            item = item.Next;
        }

        return item.Value;
    }

    public int Search(T element)
    {
        Node? item = Head;

        int index = 0;
        bool found = false;

        while (!found)
        {
            if (item.Value.Equals(element))
                found = true;
            else
            {
                item = item.Next;
                index++;
            }

            if (item == null)
                throw new InvalidOperationException("Elemento não está na lista");
        }

        return index;
    }
    
}