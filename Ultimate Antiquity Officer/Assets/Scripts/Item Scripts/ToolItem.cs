using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolItem : CollectibleItem
{
    public enum Tool
    {
        Sledgehammer,   // Not sure if this should actually be a collectible, but it simplifies the logic

        Dynamite
    }

    public Tool toolType;

    ToolItem()
    {
        this.type = CollectibleItem.Type.Tool;
    }
}
