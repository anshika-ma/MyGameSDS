using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
   public int HealthMax=7;
   public int HealthLeft;
   public Script1 user;
   public PlayerHealth player;
   public CentralSystem x;
    void Start()
    {
        HealthLeft=HealthMax;
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
         gameObject.SetActive(false);
         EnemyMoves em = GetComponent<EnemyMoves>();
        if (em != null)
        {
            em.StopRoutine();
        }
        if (x != null)
        {
            x.CheckEndCombat();
        }

    }
}
