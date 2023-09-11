using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public int TotalKeys;
    private float movementX;
    private float movementZ;
    public int DoorNumber;
    public int PCount;
    public int SCount;
    public float PlayerSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        TotalKeys = 0;

    }
    private void FixedUpdate()
    {
        Movement();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            movementX = Input.GetAxis("Horizontal");
        }
        //If no input or taking damage, horizontalInput = 0
        else
        {
            movementX = 0;
        }
        if (Input.GetAxis("Vertical") != 0 )
        {
            movementZ = Input.GetAxis("Vertical");
        }
        //If no input or taking damage, horizontalInput = 0
        else
        {
            movementZ = 0;
        }
    }
    void EndGame()
    {
        Application.Quit();
    }
    void Movement()
    {
        Vector3 Movement = new Vector3(movementX ,0.0f,movementZ);
        rb.AddForce(Movement * PlayerSpeed);
    }
}
