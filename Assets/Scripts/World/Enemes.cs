using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemes : MonoBehaviour
{
    public float speed;
    public float healpoint;
    public int scoreAdd = 1;
    private new Rigidbody2D rigidbody;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Color mainColor;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        mainColor = spriteRenderer.color;
        rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 70);
    }

    // Update is called once per frame
    void Update()
    {
        if(healpoint <= 0)
        {
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject);
            Score.ScorePlus(scoreAdd);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = transform.TransformDirection(gameObject.transform.right * speed * -1 * Time.deltaTime);
    }

    public float HitD(float damage)
    {
        healpoint -= damage;
        return healpoint;
    }
}
