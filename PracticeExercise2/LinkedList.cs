using System.Runtime.CompilerServices;

namespace PracticeExercise2;

public class LinkedListNode<T>
{
   public T Data {get;set;}
   public LinkedListNode<T> Next {get;set;}

   public LinkedListNode(T data=default, LinkedListNode<T> next=null)
    {
        Data = data;
        Next = next;
    }

    public override string ToString()
    {
        return Data==null? "null" : Data.ToString();
    }
}


public class LinkedList<T> : IList<T>
{
    private LinkedListNode<T>? Head {get;set;}
    private LinkedListNode<T>? Tail {get;set;}

    public LinkedList()
    {
        Head = null;
        Tail = null;
    }

    // TODO
    /// <summary>
    /// Returns first element in list, null if empty.
    /// </summary>
    public T? First => IsEmpty ? default : Head.Data;

    // TODO
    /// <summary>
    /// Returns last element in list, null if empty.
    /// </summary>
    public T? Last => IsEmpty ? default : Tail.Data;

    // TODO
    /// <summary>
    /// Returns true if list is has no elements; false otherwise.
    /// </summary>
    public bool IsEmpty => Head is null;

    /// <summary>
    /// Number of elements in list.
    /// </summary>
    public int Length
    {
        get;
        private set;
    }

    // TODO 
    /// <summary>
    /// Adds given item to end of list.
    /// </summary>
    /// <param name="item">item to add to the list</param>
    public void Append(T item)
    {
        var newNode = new LinkedListNode<T>(item);
        if (IsEmpty)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }

        Length++;
    }

    /// <summary>
    /// Remove all elements from list
    /// </summary>
    public void Clear()
    {
        Head = null;
        Tail = null;
        Length = 0;
    }

    /// <summary>
    /// Checks if the list contains the given value.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>true if item is in list; false otherwise</returns>
    public bool Contains(T item)
    {
        var currentNode = Head;
        for(int i=0; i<Length; i++)
        {
            if(currentNode.Data.Equals(item))
            {
                return true;
            }
            currentNode=currentNode.Next;
        }
        return false;
    }

    // TODO
    /// <summary>
    /// Find index of first element with matching value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Index of first element with value; -1 if element is not found</returns>
    public int FirstIndexOf(T item)
    {
        var currentNode = Head;
        for(int i=0; i<Length; i++)
        {
            if(currentNode.Data.Equals(item))
            {
                return i;
            }
            currentNode=currentNode.Next;
        }
        return -1;
    }

    /// <summary>
    /// Return the element at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>The element at the given index.</returns>
    public T Get(int index)
    {
        if (index >= Length||index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        var currentNode = Head;
        for(int i = 0; i <= index; i++)
        {
            if (i == index)
            {
                return currentNode.Data;
            }
            currentNode = currentNode.Next;
        }
        return default;
    }

    // TODO
    /// <summary>
    /// Insert new value after first instance of existing value.
    /// If existingValue is not in list, then add new value to end of list.
    /// </summary>
    /// <param name="newValue"></param>
    /// <param name="existingValue"></param>
    public void InsertAfter(T newItem, T existingItem)
    {
        if (IsEmpty)
        {
            Append(newItem);
            return;
        }
        var index = FirstIndexOf(existingItem);
        var currentNode = Head;
        var newNode = new LinkedListNode<T>(newItem);
        if (index == Length - 1||index == -1)
        {
            Append(newItem);
            return;
        }
        else
        {
            for(int i = 0; i<=index; i++)
            {
                if (i == index)
                {
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }
        Length++;
    }

    // TODO
    /// <summary>
    /// Insert value at given index 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="index"></param>
    public void InsertAt(T item, int index)
    {
        if (index > Length || index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        if (IsEmpty)
            {
                Append(item);
                return;
            }
        var currentNode = Head;
        var newNode = new LinkedListNode<T>(item);
        if (index == Length)
        {
            Append(item);
            return;
        }
        else if (index == 0)
        {
            Prepend(item);
            return;
        }
        else
        {
            for(int i = 0; i<=index-1; i++)
            {
                if (i == index-1)
                {
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
        }
        Length++;
    }

    // TODO
    /// <summary>
    /// Add value to beginning of list
    /// </summary>
    /// <param name="value"></param>
    public void Prepend(T item)
    {
        var newNode = new LinkedListNode<T>(item);
        if (IsEmpty)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }

        Length++;
    }

    // TODO
    /// <summary>
    /// Remove first item with given value
    /// </summary>
    /// <param name="value">value of item to be removed</param>
    public void Remove(T item)
    {
        int index = FirstIndexOf(item);
        var ItemBefore = new LinkedListNode<T>();
        var ItemAfter = new LinkedListNode<T>();
        var currentNode = Head;
        if (index >= 0)
        {
            if (index == 0)
            {
                if (Head == Tail)
                {
                    Clear();
                }
                else
                {
                    Head = Head.Next;
                    Length--;
                }
            }
            else
            {
                if(index == Length - 1)
                {
                    for(int i = 0; i<=index; i++)
                    {
                        if(i == index - 1)
                        {
                            currentNode.Next = null;
                            Tail = currentNode;
                            Length--;
                            return;
                        }
                        currentNode=currentNode.Next;
                    }
                }
                for(int i = 0; i<=index+1; i++)
                {
                    if (i == index - 1)
                    {
                        ItemBefore = currentNode;
                    }
                    if (i == index + 1)
                    {
                        ItemAfter = currentNode;
                    }
                    currentNode=currentNode.Next;
                }
                ItemBefore.Next = ItemAfter;
                Length--;
            }
            
        }
    }

    // TODO
    /// <summary>
    /// Removed item at specififed index.
    /// </summary>
    /// <param name="index"></param>
    public void RemoveAt(int index)
    {
        if (index >= Length||index < 0)
        {
            throw new IndexOutOfRangeException();
        }
        if (IsEmpty)
        {
            return;
        }
        var ItemBefore = new LinkedListNode<T>();
        var ItemAfter = new LinkedListNode<T>();
        var currentNode = Head;
        if (index == 0)
            {
                if (Head == Tail)
                {
                    Clear();
                    return;
                }
                else
                {
                    Head = Head.Next;
                    Length--;
                    return;
                }
            }
        if(index == Length - 1)
                {
                    for(int i = 0; i<=index; i++)
                    {
                        if(i == index - 1)
                        {
                            currentNode.Next = null;
                            Tail = currentNode;
                            Length--;
                            return;
                        }
                        currentNode=currentNode.Next;
                    }
                }
        for(int i = 0; i<=index+1; i++)
                {
                    if (i == index - 1)
                    {
                        ItemBefore = currentNode;
                    }
                    if (i == index + 1)
                    {
                        ItemAfter = currentNode;
                    }
                    currentNode=currentNode.Next;
                }
                ItemBefore.Next = ItemAfter;
                Length--;
    }

    // TODO
    /// <summary>
    /// Return a new copy of list in reverse order
    /// </summary>
    /// <returns></returns>
    public IList<T> Reverse()
    {
        var newlist = new LinkedList<T>();
        var current = Head;
        while(current != null)
        {
            newlist.Prepend(current.Data);
            current = current.Next;
        }
        return newlist;
    }

    private LinkedListNode<T> GetNode(T item)
    {
        return null;
    }
    

    public override string ToString()
    {
        string str = "[ ";
        var currentNode = Head;
        while (currentNode != null)
        {
            str += currentNode.Data.ToString();

            if (currentNode != Tail)
            {
                str += ", ";
            }
            currentNode = currentNode.Next;
        }
        str += "]";
        return str;
    }
}
