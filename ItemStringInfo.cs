using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum ItemType : int
{
    heart,
    money
}

class ItemStringInfo
{
    public string ItemIndexToName(int itemIndex, int itemCount)
    {
        var itemType = (ItemType)itemIndex;

        Item item = null;

        switch (itemType)
        {
            case ItemType.heart:
                {
                    item = new Heart(itemCount);
                    //return "하트";
                }
                break;
            case ItemType.money:
                {
                    Iterm = new Money();
                }
                break;

        }

        return item;
    }
}

