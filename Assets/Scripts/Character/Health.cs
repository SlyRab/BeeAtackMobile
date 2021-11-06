using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Enemes enemes;
    private Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {
        enemes = GetComponentInParent<Enemes>();
        slider = gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        slider.maxValue = enemes.healpoint;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemes.healpoint;
    }
}
