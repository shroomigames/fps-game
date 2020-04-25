using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baddiescript : MonoBehaviour
{
    public Transform player;
    public Transform shootpoint;
    float timebtwshoots;
    public float starttimebtwshoots;
    public GameObject bullet;
    public GameObject ragdoll;
    bool isdead;
    // Start is called before the first frame update
    void Start()
    {
        isdead = false;
        timebtwshoots = starttimebtwshoots;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(player.position.x, -transform.position.y, player.position.z);
        transform.LookAt(target);

        if (timebtwshoots <= 0)
        {
            timebtwshoots = starttimebtwshoots;
            Instantiate(bullet, shootpoint.position, shootpoint.rotation);
        }
        else
        {
            timebtwshoots -= Time.deltaTime;
        }

        Vector3 playerpos = new Vector3(player.position.x, 0f, player.position.z);
        Vector3.MoveTowards(transform.position, playerpos * 0.1f, 100f);
    }
}
