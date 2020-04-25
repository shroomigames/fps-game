using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplinggun : MonoBehaviour
{
    public LineRenderer lr;
    SpringJoint joint;
    public Transform guntip;
    public Transform othergun;
    Vector3 guntippos;
    public Transform player;
    Vector3 grapplepoint;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        guntippos = guntip.position;
        if (Input.GetMouseButtonDown(0))
        {
            startgrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            stopgrapple();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(joint);
            gameObject.SetActive(false);
            othergun.gameObject.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        if (!joint)
        {
            return;
        }
        else
        {
            lr.SetPosition(0, guntippos);
            lr.SetPosition(1, grapplepoint);
        }
    }

    void startgrapple()
    {
        lr.enabled = true;
        RaycastHit hit;
        if(Physics.Raycast(guntip.position, guntip.forward, out hit, 100f))
        {
            grapplepoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = true;
            joint.connectedAnchor = grapplepoint;

            float maxdistance = Vector3.Distance(player.position, grapplepoint);

            joint.maxDistance = maxdistance * 0.08f;
            joint.minDistance = maxdistance * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }

    void stopgrapple()
    {
        Destroy(joint);
        lr.enabled = false;
        grapplepoint = Vector3.zero;
    }
}
