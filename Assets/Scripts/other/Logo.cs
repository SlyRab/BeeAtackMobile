using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public Image image;
    public Text text;
    int i = 255;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        image.color = new Color(255, 255, 255, Mathf.PingPong(-1, 255));
    }
}
