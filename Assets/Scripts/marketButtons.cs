using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic; // Dictionary kullanımı için gerekli!
using TMPro;

public class marketButtons : MonoBehaviour
{
    public Player Player;
    public Button item1;
    public TMP_Text buttonText1;
    public int price1;

    public TMP_Text priceText1;
    public Button item2;
    public TMP_Text buttonText2;

    public int price2;
    public TMP_Text priceText2;
    public Button item3;
    public TMP_Text buttonText3;

    public int price3;
    public TMP_Text priceText3;
    public TMP_Text coin;

    private float multiplier1;
    private float multiplier2;
    private float multiplier3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }
    void OnEnable() {
            item1.onClick.RemoveAllListeners();
            item2.onClick.RemoveAllListeners();
            item3.onClick.RemoveAllListeners();
            List<int> randomNumbers = GetUniqueRandomNumbers(1, 6);
            Debug.Log(randomNumbers[0]);
            buttonText1.text = setText(randomNumbers[0],ref multiplier1,ref price1);
            priceText1.text = price1 + " X";
            buttonText2.text = setText(randomNumbers[1],ref multiplier2,ref price2);
            priceText2.text = price2 + " X";
            buttonText3.text = setText(randomNumbers[2],ref multiplier3,ref price3);
            priceText3.text = price3 + " X";
            item1.onClick.AddListener(() => increaseStat(randomNumbers[0],ref multiplier1,ref price1,item1));
            item2.onClick.AddListener(() => increaseStat(randomNumbers[1],ref multiplier2,ref price2,item2));
            item3.onClick.AddListener(() => increaseStat(randomNumbers[2],ref multiplier3,ref price3,item3));
            coin.text = ":" + Player.coins;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static List<int> GetUniqueRandomNumbers(int min, int max)
    {

        HashSet<int> uniqueNumbers = new HashSet<int>();
        System.Random random = new System.Random();

        while (uniqueNumbers.Count < 3)
        {
            int num = random.Next(min, max + 1);
            uniqueNumbers.Add(num);
        }

        return new List<int>(uniqueNumbers);
    }

    void increaseStat(int number, ref float multiplier, ref int price, Button se)  {
        Debug.Log(se);
        Debug.Log("Price:" + price);
        if(Player.coins < price){
            return;
        }
        switch (number)
        {
            case 1:
                Debug.Log("Damage a girdi");
                Player.ModifyDamage(Mathf.RoundToInt(multiplier));
                Debug.Log("Oyuncu Parası " + Player.coins);
                Player.coins -= price;
                Debug.Log("Güncel Para:" + Player.coins);
                coin.text = ":" + Player.coins;
                break;
           case 2:
            Debug.Log("Speed a girdi");
                Player.ModifySpeed(multiplier);
                Debug.Log("Oyuncu Parası " + Player.coins);
                Player.coins -= price;
                Debug.Log("Güncel Para:" + Player.coins);
                coin.text = ":" + Player.coins;
                break;
            case 3:
            Debug.Log("Range a girdi");
                Player.ModifyRange(multiplier);
                Debug.Log("Oyuncu Parası " + Player.coins);
                Player.coins -= price;
                Debug.Log("Güncel Para:" + Player.coins);
                coin.text = ":" + Player.coins;
                break;
            case 4:
            Debug.Log("Armora a girdi");
                Player.ModifyArmor(Mathf.RoundToInt(multiplier));
                Debug.Log("Oyuncu Parası " + Player.coins);
                Player.coins -= price;
                Debug.Log("Güncel Para:" + Player.coins);
                coin.text = ":" + Player.coins;
                break;
            case 5:
            Debug.Log("Cooldown a girdi");
                Player.ModifyAttackCooldown(multiplier);
                Debug.Log("Oyuncu Parası " + Player.coins);
                Player.coins -= price;
                Debug.Log("Güncel Para:" + Player.coins);
                coin.text = ":" + Player.coins;
                break;
            case 6:
            Debug.Log("Cana a girdi");
                Player.ModifyMaxHealth(Mathf.RoundToInt(multiplier));
                Debug.Log("Oyuncu Parası " + Player.coins);
                Player.coins -= price;
                Debug.Log("Güncel Para:" + Player.coins);
                coin.text = ":" + Player.coins;
                break;
            default:
                break;
        }
    }
    string setText(int number, ref float multiplier, ref int price) {
        switch (number)
        {
            case 1:
                multiplier = UnityEngine.Random.Range(5, 20);
                price = 10 ;
                return "Damage +" + multiplier;
            case 2:
                multiplier = UnityEngine.Random.Range(5, 20);
                price = 10 ;
                return "Speed +" + multiplier;
            case 3:
                multiplier = UnityEngine.Random.Range(0.1f, 0.5f);
                price = 10;
                return "Range +" + multiplier.ToString("F1");
            case 4:
                multiplier = UnityEngine.Random.Range(5, 20);
                price = 10;//Mathf.RoundToInt(UnityEngine.Random.Range(multiplier * 3, multiplier * 5)) ;
                return "Armor +" + multiplier;
            case 5:
                multiplier = UnityEngine.Random.Range(0.1f, 0.2f);
                price = 5;
                return "Cooldown +" + multiplier.ToString("F1");
            case 6:
                multiplier = UnityEngine.Random.Range(5, 30);
                price = 1;
                return "Health +" + multiplier;
            default:
                return "";
        }
    }
}
