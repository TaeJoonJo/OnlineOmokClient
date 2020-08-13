using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ItemInfoManager
{      

    public static List<Item> itemInfo(ItemType itemKindP, int itemCountP)
    {
        List<Item> itemInfoList = new List<Item>();
        Item item = new Item();

        item.itemKind = itemKindP;
        item.itemCount = itemCountP;

        itemInfoList.Add(item);

        return itemInfoList;
    }
}


