using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Manager : MonoBehaviour
{
    public HealthEnemy[] Enemies;
    public HealthEnemy CurrentEnemy;
    public HealthEnemy Dummy;

    public void SetEnemy(HealthEnemy en)
    {
        if (CurrentEnemy != null && CurrentEnemy != Dummy)
        {
            CurrentEnemy.gameObject.SetActive(false);
            EnemyMoves em = CurrentEnemy.GetComponent<EnemyMoves>();
            if (em != null) em.StopRoutine();
        }

        CurrentEnemy = en;

        if (CurrentEnemy != null)
        {
            CurrentEnemy.gameObject.SetActive(true);
        }
    }


    void Awake()
    {
        Enemies = GetComponentsInChildren<HealthEnemy>(true);

        if(Dummy != null)
        {
            CurrentEnemy = Instantiate(Dummy, transform);
            CurrentEnemy.gameObject.SetActive(false); 
        }
    }

    void Start()
    {
        
    }

    public void All(int damage)
    {
        foreach (HealthEnemy e in Enemies)
        {
            if (e.HealthLeft>0){
                e.TakeDamage(damage);
            }
        }
    }
}
