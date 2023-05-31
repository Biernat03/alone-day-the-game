using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private HandPivot handPivot;

     private void Awake()
    {
        handPivot = GetComponentInChildren<HandPivot>();
    }

    void Update()
    {
         if(Input.GetMouseButton(0))
        {
            handPivot.Attack();
        }
    }
}
