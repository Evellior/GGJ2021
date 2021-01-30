using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    public const uint MAX_PLAYERS = 4;

    private List<Player> players = new List<Player>();

    private Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        textElement = gameObject.GetComponent("Text") as Text;

        if (textElement != null)
        {
            textElement.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textElement != null)
        {
            string str = "";

            foreach (Player player in players)
            {
                str += "Player #" + player.id + " (Loot: " + player.loot + ", Tool: " + player.currentTool + ")\n";
            }

            textElement.text = str;
        }
    }

    public void RegisterPlayer(Player player)
    {
        if (!players.Contains(player))
        {
            players.Add(player);
        }
    }

    public void UnregisterPlayer(Player player)
    {
        if (players.Contains(player))
        {
            players.Remove(player);
        }
    }
}
