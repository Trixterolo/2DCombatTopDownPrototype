using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public string tagTarget = "Player";
    public List<Collider2D> detectedObjects = new List<Collider2D>();
    [SerializeField] Collider2D collider2d;

    //detect when object enters range
    private void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if(playerCollider.gameObject.tag == tagTarget)
        {
            detectedObjects.Add(playerCollider);

        }
    }


    //detect when object leaves range
    private void OnTriggerExit2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == tagTarget)
        {
            detectedObjects.Remove(playerCollider);
        }
    }
}
