//Koal Casler
//GameDev 1
//NSCC Truro 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public int InfoDelay;
    public float PlayerSpeed;
    public float JumpForce;
    private float movementX;
    private float movementZ;
    public int DoorNumber;
    public int PCount;
    public int PTotal;
    public int KCount;
    public int DCount;
    public bool WinCondition;
    public TextMeshProUGUI PCountText;
    public TextMeshProUGUI KCountText;
    public GameObject WTextObject;
    public GameObject StartTextObject;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartInfo", InfoDelay);
        SetCountText();
        Initialize();
        SetKeyCount();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    // Update is called once per frame
    void Update()
    {
        if (WinCondition == true)
        {
            WTextObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            movementX = Input.GetAxis("Horizontal");
        }
        //If no input, horizontalInput = 0
        else
        {
            movementX = 0;
        }
        if (Input.GetAxis("Vertical") != 0 )
        {
            movementZ = Input.GetAxis("Vertical");
        }
        //If no input, horizontalInput = 0
        else
        {
            movementZ = 0;
        }
        SetCountText();
    }
    public void EndGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    void Movement()
    {
        Vector3 Movement = new Vector3(movementX ,0.0f,movementZ);
        rb.AddForce(Movement * PlayerSpeed);
    }
    void SetCountText()
    {
        PCountText.text = "Crystals found : " + PCount.ToString() + "/" + PTotal.ToString(); 
        if(PCount >= PTotal)
        {
            WinCondition = true;
        }
    }
    void SetKeyCount()
    {
        KCountText.text = "Keys found : " + KCount.ToString();
    }
    void StartInfo()
    {
        StartTextObject.SetActive(false);
    }
    void Initialize()
    {
        KCount = 0;
        PCount = 0;
        DCount = 0;
        WinCondition = false;
        rb = GetComponent<Rigidbody>();
        WTextObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            PCount = PCount+1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            KCount = KCount+1;
            SetKeyCount();
        }
        if (other.gameObject.CompareTag("Door"))
        {
            if (KCount >= DCount)
            {
                other.gameObject.SetActive(false);
                DCount = DCount+1;
            }
        }
        if (other.gameObject.CompareTag("LastDoor"))
         {
            if (WinCondition == true)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
