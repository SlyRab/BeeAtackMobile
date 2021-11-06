using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkillsShop : MonoBehaviour
{
    public Shooting Character;
    public Bonus[] bonuses;
    public Button[] buttons;
    private void OnGUI()
    {
        for (int i = 0; i <= bonuses.Length-1; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = string.Format("{0}, {1}$", bonuses[i].name, bonuses[i].price);
        }
    }


    public void BuyButton(int num)
    {
        if (Score.GetScore() >= bonuses[num].price)
        {
            Score.ScorePlus(-bonuses[num].price);
            Character.fireRate += bonuses[num].speedAttak;
            Character.heroDamage += bonuses[num].power;
            bonuses[num].price *= 2;
        }
    }

    [System.Serializable]
    public struct Bonus
    {
        public string name;
        public float speedAttak;
        public float power;
        public int price;
    }

}
