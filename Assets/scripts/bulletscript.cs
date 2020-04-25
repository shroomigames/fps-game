using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public bool isslowmo;

    public float speed;

    public float bullethitforce;

    private bool iscolliding;

    private Rigidbody rb;

    private void Start()
    {
        iscolliding = false;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (iscolliding)
        {
            StartCoroutine(Explode());
        }
        else
        {
            return;
        }      
    }

    IEnumerator Explode()
    {
        rb.AddExplosionForce(bullethitforce, transform.position, 4);
        yield return new WaitForSeconds(0.09f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        iscolliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        iscolliding = false;
    }
}
