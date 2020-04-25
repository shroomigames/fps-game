using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    public string nextlvl;
    public string currentlvl;

    public AudioSource AD;

    public Rigidbody rb;

    [SerializeField]
    public bool isSlowmo;
    public bool isDead;
    public GameObject Post_Pro;
    public GameObject death_screen;
    public bool lowqualityistoggled;
    bool issprinting;
    public float _speed;
    public float _slidespeed;
    float currentslidedspeed;
    private float _currentspeed;
    public float _sprintspeed;
    public float _jumpforce;
    Vector3 velocity;
    bool iscrouching;

    private camerascript cs;

    public Transform groudcheck;
    public Transform player;
    public Transform oreintation;
    public float raycastdistance = 0.4f;
    public LayerMask ground;

    private CharacterController controller;

    public bool isgrounded;

    public bool ispaused;

    private void Start()
    {
        isDead = false;
        cs = GetComponent<camerascript>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    } 

    private void Update()
    {
        if (!isDead)
        {
            if(iscrouching)
            {
                rb.AddForce(-oreintation.forward * currentslidedspeed, ForceMode.Force);
                GetComponent<CapsuleCollider>().sharedMaterial.dynamicFriction = 0f;
                GetComponent<CapsuleCollider>().sharedMaterial.staticFriction = 0f;
            }
            else
            {
                rb.AddForce(Vector3.zero);
                GetComponent<CapsuleCollider>().sharedMaterial.dynamicFriction = 1f;
                GetComponent<CapsuleCollider>().sharedMaterial.staticFriction = 1f;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (iscrouching)
                {
                    iscrouching = false;
                }
                else
                {
                    iscrouching = true;
                }
            }

            if (iscrouching == true)
            {
                currentslidedspeed = _slidespeed;
                oreintation.GetComponent<Rigidbody>().freezeRotation = true;
                transform.localScale = new Vector3(1, 0.3f, 1);
            }

            else
            {
                oreintation.GetComponent<Rigidbody>().freezeRotation = false;
                currentslidedspeed = 0;
                transform.localScale = new Vector3(1, 1f, 1);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (isSlowmo)
                {
                    isSlowmo = false;
                }
                else
                {
                    isSlowmo = true;
                }
            }

            if (isSlowmo == true)
            {
                Time.timeScale = 0.3f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
            else
            if(isSlowmo == false)
            {
                Time.timeScale = 1.0f;
            }

            if(isgrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * _jumpforce, ForceMode.Impulse);
            }

            float HorizInput = Input.GetAxis("Horizontal");
            float VerInput = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(HorizInput, 0f, VerInput) * _speed;
            Vector3 newpos = rb.position + rb.transform.TransformDirection(move);
            rb.MovePosition(newpos);

            if (Physics.Raycast(transform.position, -transform.up, raycastdistance))
            {
                isgrounded = true;
            }
            else
            {
                isgrounded = false;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && isgrounded)
            {
                rb.AddForce(-oreintation.forward * -currentslidedspeed, ForceMode.Force);
            }

            death_screen.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0.0f;
            death_screen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("goal"))
        {
            changescene();
        }
          if (other.GetComponent<Collider>().CompareTag("deathzone") || other.GetComponent<Collider>().CompareTag("bullet"))
          {
              isDead = true;
          }
        else
        {
            isDead = false;
        }
    }

    private void changescene()
    {
        SceneManager.LoadScene(nextlvl);
    }

    public void resetscene()
    {
        SceneManager.LoadScene(currentlvl);
    }
}
