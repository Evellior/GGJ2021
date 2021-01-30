using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : CollectibleItem
{
    public uint value;

    LootItem(uint value)
    {
        this.value = value;
        this.type = CollectibleItem.Type.Loot;
    }
}
