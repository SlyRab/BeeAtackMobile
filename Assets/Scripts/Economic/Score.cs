using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static int score = 0;
    public Text textI;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnGUI()
    {
        if (textI)
        {
            textI.text = score.ToString();
        }
    }

    public static void ScorePlus(int i)
    {
        score += i;
    }

    public static int GetScore()
    {
        return score;
    }
}
