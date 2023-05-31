using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPivot : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 pointerPosition {get; set; }
    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    public Transform player;

    public bool IsAttacking {get;private set; }

    public void ResetIsAttacking()
    {
      IsAttacking = false;
    }

     private void Update(){
      Vector2 direction = (pointerPosition-(Vector2)transform.position).normalized;
      transform.right = direction;

      Vector2 scale = transform.localScale;
      if(direction.x < 0 ){
        scale.y = -1;
            scale.x = -1;
        }
        if(direction.x >0){
        scale.y = 1;
            scale.x = 1;
        }

      transform.localScale = scale;
     

     if (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
     {
        weaponRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
     }else {
        weaponRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
     }
    }

    public void Attack() 
    {
      if(attackBlocked) return;

      IsAttacking =true;
      animator.SetTrigger("Attack");
      attackBlocked = true;
      StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
      yield return new WaitForSeconds(delay);
      attackBlocked = false;
    }

}
