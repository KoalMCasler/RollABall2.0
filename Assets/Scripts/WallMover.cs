using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public float MoveSpeed;
    public float RotateMove;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3 (0,RotateMove,0)*Time.deltaTime);
    }
}
