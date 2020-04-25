using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class turretscript : MonoBehaviour
{
    bool isawake;
    LineRenderer lr;
    public float rotationspeed;
    public float maxtimebtwshoots;
    public float mintimebtwshoots;
    private float currenttimebtwshoots;
    private float timebtwshoots;
    public Transform player;
    public Transform shootpoint;
    public GameObject bullet;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        isawake = false;
        lr = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootpoint.position, shootpoint.forward, out hit, 100f))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                isawake = true;
            }
        }
        else
        {
            isawake = false;
        }
        if (isawake)
        {
            lr.enabled = true;
            lr.SetPosition(0, shootpoint.position);
            lr.SetPosition(1, hit.point);
            Vector3 target = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(target);
            if (currenttimebtwshoots <= 0)
            {
                Instantiate(bullet, shootpoint.position, transform.rotation);
                timebtwshoots = Random.Range(mintimebtwshoots, maxtimebtwshoots);
                currenttimebtwshoots = timebtwshoots;
            }
            else
            {
                currenttimebtwshoots -= Time.deltaTime;
            }
        }
        else
        {
            lr.enabled = false;
            transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(transform.position, transform.forward);
    }
}

        


