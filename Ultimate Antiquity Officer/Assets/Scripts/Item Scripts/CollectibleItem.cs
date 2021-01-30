using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum Type
    {
        Loot,
        Tool
    }

    public Type type
    {
        get;
        protected set;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Player playerComponent = collision.collider.gameObject.GetComponent(typeof(Player)) as Player;

            if (playerComponent != null)
            {
                playerComponent.InteractWithItem(this);
            }
        }
    }
}