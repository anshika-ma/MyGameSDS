using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   public int HealthMax=7;
   public int HealthLeft;
   Script1 user;
    void Start()
    {
        HealthLeft=HealthMax;
        user=GetComponent<Script1>();
    }

    void Update()
    {
        
    }
    public void TakeDamage(int harm){
        HealthLeft-=harm;
        HealthLeft=Mathf.Clamp(HealthLeft,0,HealthMax);
        if (HealthLeft==0){
            Death();
        }
    }
    private void Death(){
         Debug.Log("Enemy defeated!!");
         user.current=Script1.PlayerState.Moving;

    }
}
