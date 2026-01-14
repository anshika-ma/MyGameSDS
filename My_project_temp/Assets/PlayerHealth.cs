using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth=7;
    public int CurrentHealth;
    private Script1 player;
    public CentralSystem time;
    void Start()
    {
      CurrentHealth=MaxHealth; 
      player=GetComponent<Script1>(); 
      time = FindObjectOfType<CentralSystem>();
    }
    public void CombatDamage(int damage){
        if (player.current == Script1.PlayerState.Dead){
            return;
        }
        CurrentHealth-=damage;
        CurrentHealth=Mathf.Clamp(CurrentHealth,0,MaxHealth);
        if (CurrentHealth==0){
            Die();
        }
    }
    public void Die(){
        Debug.Log("Player is dead");
    }
}
