using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class gunscript : MonoBehaviour 
{
    public Transform player;

    private bool ispaused;
    private bool isslowmo;

    public AudioSource shootsound;

    public Transform shootpoint;
    public Transform othergun;
    public Vector3 dir;
    Vector3 localPosition;
    public Transform bullet;
    public float timebtwshoots;
    public float starttimebtwshoots;

    private void Start()
    {
        localPosition = transform.position;
        timebtwshoots = starttimebtwshoots;
    }
    private void Update()
    {
        if (!player.GetComponent<playercontroller>().isDead)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                gameObject.SetActive(false);
                othergun.gameObject.SetActive(true);
            }
            if (!gameObject.active) return;
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
            if (isslowmo)
            {
                shootsound.pitch = 0.5f;
                starttimebtwshoots = 0.02f;
            }
            else
            {
                shootsound.pitch = 1f;
                starttimebtwshoots = 1f;
            }

            getraycast();
            if (timebtwshoots <= 0)
            {
                if (!ispaused)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        shootsound.Play();
                        Instantiate(bullet, shootpoint.position, shootpoint.rotation);
                        timebtwshoots = starttimebtwshoots;
                    }
                }
            }
            else
            {
                timebtwshoots -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (ispaused)
                {
                    ispaused = false;
                }
                else
                {
                    ispaused = true;
                }
            }
        }
        else
        {
            return;
        }
    }

    void getraycast()
    {
        Vector3 orign = transform.position;
        Vector3 dir = shootpoint.forward;

        Debug.DrawRay(orign, dir * 10f, Color.red);
        Ray ray = new Ray(orign, dir);

        if(Physics.Raycast(ray, out  RaycastHit rayhit))
        {
            Vector3 target = rayhit.point;
            Debug.DrawRay(orign, dir * 10f, Color.green);
        }
    }
}
