using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 13);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            switch (other.tag)
            {
                case "Enemy":
                    Destroy(gameObject);
                    other.GetComponent<Enemes>().HitD(damage);
                    break;
            }
        }
    }
}
