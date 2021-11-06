using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isDown;

    public float speed = 10;
    public Rigidbody2D bullet;
    public Transform gunPoint;

    public float fireRate = 2;
    public bool mayShoot = true;

    public Transform zRotate;

    public float minAngle = -40;
    public float maxAngle = 40;

    public float heroDamage;

    public AudioClip din;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Fire()
    {
            if (mayShoot)
            {
                audioSource.PlayOneShot(din);
                Rigidbody2D clone = Instantiate(bullet, gameObject.transform.position, Quaternion.identity) as Rigidbody2D;
                clone.GetComponent<bullet>().damage = heroDamage;
                clone.velocity = transform.TransformDirection(clone.transform.right * speed);
                clone.transform.forward = gameObject.transform.forward;

                StartCoroutine(offset());
            }
        
    }

    public void DownFire()
    {
        isDown = true;
    }

    public void UpFire()
    {
        isDown = false;
    }

    private IEnumerator offset()
    {
        mayShoot = false;
        yield return new WaitForSeconds(fireRate);
        mayShoot = true;
        StopCoroutine(offset());
    }

    // Update is called once per frame
    void Update()
    {
        if(mayShoot && isDown)
        {
            Fire();
        }
    }
}
