
public class ItemStack
{
    public ItemData Item;
    public int Amount;
    public ItemStack(int amount, ItemData item) 
    {
        Item = item;
        Amount = amount;
    }
}
