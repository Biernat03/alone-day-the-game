using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointController : MonoBehaviour
{
     public float desiredDistance = 1f; // Adjust the desired distance as needed

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z));
        
        Vector3 direction = worldMousePosition - transform.position;
        direction.Normalize();
        Vector3 attackPointPosition = transform.position + direction * desiredDistance;
        transform.GetChild(0).position = attackPointPosition;
    }
}
