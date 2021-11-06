using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsShop : MonoBehaviour
{
    [System.Serializable]
    public struct Character
    {
        public int cost;
        public float bullSpeed, speedAttack, Damage;
        public GameObject bulletPrefab;

        public Sprite sprite;
    }

    public GameObject character;
    public List<BuySkinButton> buttons;
    public List<Character> persons;

    private Statistic statistic;

    private void Start()
    {
        statistic = character.GetComponent<Statistic>();

        for (int i = 0; i <= buttons.Count - 1; i++)
        {
            Debug.Log(buttons.Count);
            int x = i;
            buttons[i].selectedButton.GetComponent<Button>().onClick.AddListener(() => SelectPerson(x));
            buttons[i].buyBtn.GetComponent<Button>().onClick.AddListener(() => BuyPerson(x));
        }
    }

    private void OnGUI()
    {
        for (int i = 0; i
            < buttons.Count; i++)
        {
            buttons[i].imageHero.sprite = persons[i].sprite;
            buttons[i].costText.text = persons[i].cost.ToString();

            if (statistic.Characters.Contains(i))
            {
                if (statistic.selectCharacter == i)
                {
                    buttons[i].buyBtn.SetActive(false);
                    buttons[i].selectedButton.SetActive(false);
                    buttons[i].nowSelectedButton.SetActive(true);
                }
                else
                {
                    buttons[i].buyBtn.SetActive(false);
                    buttons[i].selectedButton.SetActive(true);
                    buttons[i].nowSelectedButton.SetActive(false);
                }
            }
            else
            {
                buttons[i].buyBtn.SetActive(true);
                buttons[i].selectedButton.SetActive(false);
                buttons[i].nowSelectedButton.SetActive(false);
            }
        }
    }


    public void BuyPerson(int i)
    {
        Debug.Log(i);
        if (Score.GetScore() >= persons[i].cost)
        {
            SelectPerson(i);
            statistic.Characters.Add(i);
            Score.ScorePlus(-persons[i].cost);
        }
    }

    public void SelectPerson(int i)
    {
        statistic.selectCharacter = i;
        Shooting c = character.GetComponent<Shooting>();
        SpriteRenderer sp = character.GetComponent<SpriteRenderer>();

        c.fireRate = persons[i].speedAttack;
        c.heroDamage = persons[i].Damage;
        c.speed = persons[i].bullSpeed;

        sp.sprite = persons[i].sprite;
        Debug.Log(string.Format("бляяять {0}", i));
    }
}
