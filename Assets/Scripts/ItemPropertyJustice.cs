using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





enum ItemType : int
{
    heart,
    gold
}
class Item
{
    public int itemCount;
    public ItemType itemKind;
    public string itemName;
}
class ItemPropertyJustice
{
    
    public Item GetItem(int itemKindP, int itemCountP)
    {
        ItemType itemKindTemp = (ItemType)itemKindP;
        Item item = null;
        item.itemCount = itemCountP;
        item.itemKind = itemKindTemp;

        switch (itemKindTemp)
        {
            case ItemType.heart:
                {
                    item.itemName = "하트";
                }
                break;

            case ItemType.gold:
                {
                    item.itemName = "골드";
                }
                break;
        }

        return item;
    }

}

