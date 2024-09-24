using System;

public class ItemCodeParse
{
    public static bool TryParse(string input, out ItemCode itemCode)
    {
        if (Enum.TryParse(input, out itemCode))
        {
            if (Enum.IsDefined(typeof(ItemCode), itemCode))
            {
                return true;
            }
        }

        itemCode = default;
        return false;
    }

    public static ItemCode Parse(string input)
    {
        ItemCode itemCode = (ItemCode)Enum.Parse(typeof(ItemCode), input);

        if (!Enum.IsDefined(typeof(ItemCode), itemCode))
        {
            throw new ArgumentException($"'{input}' is not an enum ItemCode.");
        }

        return itemCode; 
    }
}
