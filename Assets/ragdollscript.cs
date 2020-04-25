using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollscript : MonoBehaviour
{
    public Transform activehelper;

    private void Start()
    {
        activehelper.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            activehelper.gameObject.SetActive(false);
        }
        else
        {
            return;
        }
    }

}
