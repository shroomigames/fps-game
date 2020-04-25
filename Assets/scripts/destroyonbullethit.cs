using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyonbullethit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
