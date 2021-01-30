using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class Player : MonoBehaviour
{
    public uint id;
    public uint loot;

    public ToolItem.Tool currentTool
    {
        get;
        private set;
    }

    Player(uint id)
    {
        this.id = id;
        this.loot = 0;
        this.currentTool = ToolItem.Tool.Sledgehammer;
    }

    void Awake()
    {
        RegisterWithDisplays();
    }

    void OnDestroy()
    {
        UnregisterFromDisplays();
    }

    private void RegisterWithDisplays()
    {
        DisplayController[] controllers = GameObject.FindObjectsOfType<DisplayController>();

        foreach (DisplayController controller in controllers)
        {
            controller.RegisterPlayer(this);
        }
    }

    private void UnregisterFromDisplays()
    {
        DisplayController[] controllers = GameObject.FindObjectsOfType<DisplayController>();

        foreach (DisplayController controller in controllers)
        {
            controller.UnregisterPlayer(this);
        }
    }

    public void InteractWithItem(CollectibleItem item)
    {
        bool handled = false;

        if (item.type == CollectibleItem.Type.Loot)
        {
            LootItem lootItem = item as LootItem;

            if (lootItem != null)
            {
                loot += lootItem.value;

                handled = true;
            }
        }
        else if (item.type == CollectibleItem.Type.Tool)
        {
            ToolItem toolItem = item as ToolItem;

            if (toolItem != null && toolItem.toolType != currentTool)
            {
                currentTool = toolItem.toolType;

                handled = true;
            }
        }

        if (handled)
        {
            if (item.gameObject != null)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
