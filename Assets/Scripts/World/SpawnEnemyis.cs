using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyis : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Foo(3));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator Foo(float f)
    {
        Rigidbody2D clone = Instantiate(rigidbody, new Vector3(21f, Random.Range(-1f, 5f), 5), new Quaternion(0, 0, 0, 0), gameObject.transform);
        clone.GetComponent<Enemes>().speed = Random.Range(50 * 2, 150 * 2);
        clone.GetComponent<Enemes>().healpoint = Random.Range(1,5);
        yield return new WaitForSeconds(f);
        StartCoroutine(Foo(3));
    }
}
