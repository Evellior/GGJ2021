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

    public Rigidbody rigidBody;

    //private Vector2 ;

    void Awake()
    {
        this.id = id;
        this.loot = 0;
        this.currentTool = ToolItem.Tool.Sledgehammer;

        RegisterWithDisplays();
    }

    void Start()
    {
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

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 moveVector = context.ReadValue<Vector2>();

        if (moveVector.sqrMagnitude >= 0.15)
        {
            rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, 50.0f * new Vector3(moveVector.x, 0.0f, moveVector.y), 0.5f);
            //rigidBody.AddForce(/* May need to multiply by a scaling factor */ 1000f * new Vector3(moveVector.x, 0.0f, moveVector.y));
        }
        else
        {
            rigidBody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }//*/
    }
}
