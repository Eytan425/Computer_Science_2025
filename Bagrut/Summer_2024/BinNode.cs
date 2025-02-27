using System;

class BinNode<T>
{
    private BinNode<T> left;
    private T value;
    private BinNode<T> right;

    public BinNode(T value)
    {
        this.value = value;
        this.left = null;
        this.right = null;
    }

    public BinNode(BinNode<T> left, T value, BinNode<T> right)
    {
        this.left = left;
        this.value = value;
        this.right = right;
    }
    
    public T GetValue()
    {
        return this.value; // Fixed implementation
    }
    
    public BinNode<T> GetRight()
    {
        return this.right;
    }
    
    public BinNode<T> GetLeft()
    {
        return this.left;
    }
    
    public void SetLeft(BinNode<T> left)
    {
        this.left = left;
    }
    
    public void SetRight(BinNode<T> right)
    {
        this.right = right;
    }
    
    public void SetValue(T value)
    {
        this.value = value;
    }
    
    public bool HasLeft()
    {
        return this.left != null;
    }
    
    public bool HasRight()
    {
        return this.right != null;
    }
}
