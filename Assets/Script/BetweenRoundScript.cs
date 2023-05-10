using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetweenRoundScript : MonoBehaviour
{
    public Text roundText;
    public Text balance;
    public Text currentSpeed;
    public Text currentArmor;
    public Text armorText;
    public Text speedText;
    public AudioClip nopeSound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        roundText.text = "Round " + GlobalVariables.roundNumber;
        audioSource.clip = nopeSound;
        if (GlobalVariables.roundNumber >= 5)
        {
            GlobalVariables.speeAddition += 0.2f;
            GlobalVariables.bossSpeed += GlobalVariables.speeAddition;
            GlobalVariables.bossDamage += 10;
        }
        else
        {
            GlobalVariables.bossSpeed += .5f;
            GlobalVariables.bossDamage += 5;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        currentArmor.text = "CURRENT ARMOR: " + GlobalVariables.armor;
        currentSpeed.text = "CURRENT SPEED: " + GlobalVariables.speed;
        balance.text = "CURRENT BALANCE: " + GlobalVariables.money + "$";
        if (GlobalVariables.money < 40)
        {
            speedText.color = Color.red;
        }
        else
        {
            speedText.color = Color.green;
        }
        if (GlobalVariables.money < 60)
        {
            armorText.color = Color.red;
        }
        else
        {
            armorText.color = Color.green; 
        }

    }

    public void upgradeSpeed()
    {
        if(GlobalVariables.money >= 40) { 
            GlobalVariables.playerSpeed += 0.5f;
            GlobalVariables.speed += 1;
            GlobalVariables.money -= 40;
        }
        else
        {
            audioSource.Play();
        }
       
    }
    public void upgradeArmor()
    {
        if(GlobalVariables.money >= 60) { 
        GlobalVariables.bossDamage -= 15;
            GlobalVariables.armor += 1;
            GlobalVariables.money -= 60;
        }
        else
        {
            audioSource.Play();
        }
    }
}
