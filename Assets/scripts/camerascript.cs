using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    public bool isslowmo;

    public float mousespeed;

    public AudioSource AS;

    public bool consoleisactive;

    public bool isdead;

    public playercontroller pc;

    public Transform player;

    private float xrot;
    private float yrot;

    // Update is called once per frame

    private void Start()
    {
        consoleisactive = false;
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (pc.isDead)
        {
            isdead = true;
        }
        else
        {
            isdead = false;
        }
        if (!isdead)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (isslowmo == true)
                {
                    isslowmo = false;
                }
                else
                {
                    isslowmo = true;
                }
            }

            if (isslowmo == true)
            {
             
                AS.pitch = 0.5f;
            }
            else
            {
                AS.pitch = 1f;
            }

            float xpos = Input.GetAxis("Mouse X") * mousespeed;
            float ypos = Input.GetAxis("Mouse Y") * mousespeed;


            xrot -= ypos;
            yrot -= xpos;
            xrot = Mathf.Clamp(xrot, -90f, 90);

            transform.localRotation = Quaternion.Euler(-xrot, 0f, 0f);
            player.Rotate(Vector3.up * xpos);
        }
        else
        {
            return;
        }
    }
}
