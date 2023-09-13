using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject CurrentTeleport;
    public Animator transition;
    public float TransitionTime = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
     if (Input.GetButtonDown("Interact"))
        {
            StartCoroutine(Teleport());
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Teleport"))
        {
            CurrentTeleport = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Teleport"))
        {
            if (collision.gameObject == CurrentTeleport)
            {
                CurrentTeleport = null;
            }
        }
    }
    private IEnumerator Teleport()
    {
        if (CurrentTeleport != null)
            {
                transition.SetBool("Start", true);
                yield return new WaitForSeconds(TransitionTime);
                transform.position = CurrentTeleport.GetComponent<PlatformTeleport>().GetDestination().position;
                transition.SetBool("Start", false);
            }
    }
}
