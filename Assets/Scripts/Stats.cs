using UnityEngine;
using TMPro;
public class Stats : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = ("Health: " + player.currentHealth + "/" + player.maxHealth + "\n" + "Damage: " + player.damage + "\n" + "Speed: " + player.speed + "\n" + "Range: " + player.range + "\n" + "Armor: " + player.armor + "\n" + "Speed: " + player.speed + "\n" + "Coins: " + player.coins);
    }

    void OnEnable() {
        text.text = ("Health: " + player.currentHealth + "/" + player.maxHealth + "\n" + "Damage: " + player.damage + "\n" + "Speed: " + player.speed + "\n" + "Range: " + player.range + "\n" + "Armor: " + player.armor + "\n" + "Speed: " + player.speed + "\n" + "Coins: " + player.coins);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
