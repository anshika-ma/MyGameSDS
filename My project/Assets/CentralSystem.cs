using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralSystem : MonoBehaviour
{
    public Script1 player;
    public PlayerHealth ph;
    public FIghtMoves pm;
    public bool CombatStart=false;
    public Timer time;
    public Wall collide;
    public bool GameEnded=false;
    public Manager manage;
    public void StartCombat()
    {
        if (manage.CurrentEnemy == null) return;

        CombatStart = true;
        player.current = Script1.PlayerState.Combat;
        ph.CurrentHealth = ph.MaxHealth; 
        pm.SpecialMove = false;
        player.CurrentMove = FIghtMoves.Moves.Standing;
        EnemyMoves enemyMoves = manage.CurrentEnemy.GetComponent<EnemyMoves>();
        if (enemyMoves != null)
        {
            enemyMoves.CurrentStatus = EnemyMoves.Moves.Standing;
            enemyMoves.SpecialMove = false;
            enemyMoves.StartRoutine();
        }
    }
    public void FightTime(FIghtMoves.Moves P, EnemyMoves.Moves E)
    {
        if (CombatStart==false || manage.CurrentEnemy == null) {
            return;
        }

        if (manage.CurrentEnemy == null){
            return;
        }
        HealthEnemy enemy = manage.CurrentEnemy;
        EnemyMoves enemyMoves = enemy.GetComponent<EnemyMoves>();

        if (player.CurrentMove==FIghtMoves.Moves.Standing && enemyMoves.CurrentStatus==EnemyMoves.Moves.Standing)
        {
            Debug.Log("Nothing is happening lol");
        }
        else if (player.CurrentMove==FIghtMoves.Moves.Standing && (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperDefence || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerDefence))
        {
            Debug.Log("Nothing");
        }
        else if ((player.CurrentMove==FIghtMoves.Moves.UpperDefence || player.CurrentMove==FIghtMoves.Moves.LowerDefence) && enemyMoves.CurrentStatus==EnemyMoves.Moves.Standing)
        {
            Debug.Log("Nothing");
        }
        else if (player.CurrentMove==FIghtMoves.Moves.Standing && (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperPunch || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerPunch || enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperKick || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerKick))
        {
            if (player.current!=Script1.PlayerState.Dead)
            {
                ph.CombatDamage(pm.punchdamage);
            }
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.Standing && (player.CurrentMove==FIghtMoves.Moves.UpperPunch || player.CurrentMove==FIghtMoves.Moves.LowerPunch || player.CurrentMove==FIghtMoves.Moves.UpperKick || player.CurrentMove==FIghtMoves.Moves.LowerKick))
        {
            if (enemy.HealthLeft > 0)
            {
                enemy.TakeDamage(enemyMoves.punchdamage);
            }
        }
        else if (player.CurrentMove==FIghtMoves.Moves.Standing && enemyMoves.CurrentStatus==EnemyMoves.Moves.SpecialMove)
        {
            if (player.current!=Script1.PlayerState.Dead)
            {
                ph.CombatDamage(pm.specialmovedamage);
            }
            enemyMoves.SpecialMove=true;
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.Standing && player.CurrentMove==FIghtMoves.Moves.SpecialMove)
        {
            if (enemy.HealthLeft > 0)
            {
                enemy.TakeDamage(enemyMoves.punchdamage);
            }
            pm.SpecialMove=true;
        }
        else if ((player.CurrentMove==FIghtMoves.Moves.UpperDefence || player.CurrentMove==FIghtMoves.Moves.LowerDefence) && (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperDefence || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerDefence))
        {
            Debug.Log("Nothing");
        }
        else if (player.CurrentMove==FIghtMoves.Moves.UpperDefence && (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperPunch || enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperKick))
        {
            Debug.Log("Nothing");
        }
        else if (player.CurrentMove==FIghtMoves.Moves.LowerDefence && (enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerPunch || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerKick))
        {
            Debug.Log("Nothing");
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperDefence && (player.CurrentMove==FIghtMoves.Moves.UpperPunch || player.CurrentMove==FIghtMoves.Moves.UpperKick))
        {
            Debug.Log("Nothing");
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerDefence && (player.CurrentMove==FIghtMoves.Moves.LowerPunch || player.CurrentMove==FIghtMoves.Moves.LowerKick))
        {
            Debug.Log("Nothing");
        }
        else if (player.CurrentMove==FIghtMoves.Moves.UpperDefence && (enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerPunch || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerKick))
        {
            if (player.current!=Script1.PlayerState.Dead)
            {
                ph.CombatDamage(pm.punchdamage);
            }
        }
        else if (player.CurrentMove==FIghtMoves.Moves.LowerDefence && (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperPunch || enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperKick))
        {
            if (player.current!=Script1.PlayerState.Dead)
            {
                ph.CombatDamage(pm.punchdamage);
            }
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerDefence && (player.CurrentMove==FIghtMoves.Moves.UpperPunch || player.CurrentMove==FIghtMoves.Moves.UpperKick))
        {
            if (enemy.HealthLeft > 0)
            {
                enemy.TakeDamage(enemyMoves.kickdamage);
            }
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperDefence && (player.CurrentMove==FIghtMoves.Moves.LowerPunch || player.CurrentMove==FIghtMoves.Moves.LowerKick))
        {
            if (enemy.HealthLeft > 0)
            {
                enemy.TakeDamage(enemyMoves.punchdamage);
            }
        }
        else if (player.CurrentMove==FIghtMoves.Moves.UpperDefence && enemyMoves.CurrentStatus==EnemyMoves.Moves.SpecialMove)
        {
            Debug.Log("Big Damage Saved");
            enemyMoves.SpecialMove=true;
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperDefence && player.CurrentMove==FIghtMoves.Moves.SpecialMove)
        {
            Debug.Log("Big Damage Wasted");
            pm.SpecialMove=true;
        }
        else if (player.CurrentMove==FIghtMoves.Moves.LowerDefence && enemyMoves.CurrentStatus==EnemyMoves.Moves.SpecialMove)
        {
            if (player.current!=Script1.PlayerState.Dead)
            {
                ph.CombatDamage(pm.specialmovedamage);
            }
            enemyMoves.SpecialMove=true;
        }
        else if (enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerDefence && player.CurrentMove==FIghtMoves.Moves.SpecialMove)
        {
            if (enemy.HealthLeft > 0)
            {
                enemy.TakeDamage(enemyMoves.specialmovedamage);
            }
            pm.SpecialMove=true;
        }
        else if ((player.CurrentMove==FIghtMoves.Moves.UpperKick || player.CurrentMove==FIghtMoves.Moves.UpperPunch) && (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperKick || enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperPunch))
        {
            Debug.Log("Attacks saved by both parties");
        }
        else if ((player.CurrentMove==FIghtMoves.Moves.LowerKick || player.CurrentMove==FIghtMoves.Moves.LowerPunch) && (enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerKick || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerPunch))
        {
            Debug.Log("Attacks saved by both parties");
        }
        else if ((player.CurrentMove==FIghtMoves.Moves.UpperKick || player.CurrentMove==FIghtMoves.Moves.UpperPunch) && (enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerKick || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerPunch))
        {
            if (player.current!=Script1.PlayerState.Dead && enemy.HealthLeft>0)
            {
                ph.CombatDamage(pm.kickdamage);
                enemy.TakeDamage(enemyMoves.punchdamage);
            }
        }
        else if ((player.CurrentMove==FIghtMoves.Moves.LowerKick || player.CurrentMove==FIghtMoves.Moves.LowerPunch) && (enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperKick || enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperPunch))
        {
            if (player.current!=Script1.PlayerState.Dead && enemy.HealthLeft>0)
            {
                ph.CombatDamage(pm.kickdamage);
                enemy.TakeDamage(enemyMoves.punchdamage);
            }
        }
        else if ((enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperKick || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerKick || enemyMoves.CurrentStatus==EnemyMoves.Moves.UpperPunch || enemyMoves.CurrentStatus==EnemyMoves.Moves.LowerPunch) && player.CurrentMove==FIghtMoves.Moves.SpecialMove)
        {
            if (enemy.HealthLeft > 0)
            {
                enemy.TakeDamage(enemyMoves.specialmovedamage);
            }
            pm.SpecialMove=true;
        }
        else if ((player.CurrentMove==FIghtMoves.Moves.UpperKick || player.CurrentMove==FIghtMoves.Moves.LowerKick || player.CurrentMove==FIghtMoves.Moves.UpperPunch || player.CurrentMove==FIghtMoves.Moves.LowerPunch) && enemyMoves.CurrentStatus==EnemyMoves.Moves.SpecialMove)
        {
            if (player.current!=Script1.PlayerState.Dead)
            {
                ph.CombatDamage(pm.specialmovedamage);
            }
            enemyMoves.SpecialMove=true;
        }
        else if (player.CurrentMove==FIghtMoves.Moves.SpecialMove && enemyMoves.CurrentStatus==EnemyMoves.Moves.SpecialMove)
        {
            Debug.Log("Wasted special moves by both parties sad");
            pm.SpecialMove=true;
            enemyMoves.SpecialMove=true;
        }
    
    }
    public void EndCombat()
    {
        if(manage.CurrentEnemy != null)
        {   
            EnemyMoves em = manage.CurrentEnemy.GetComponent<EnemyMoves>();
            if(em != null){
                em.StopRoutine();
            }
        }

        CombatStart=false;
        player.current = Script1.PlayerState.Moving;
        ph.CurrentHealth = ph.MaxHealth;
        pm.SpecialMove = false;
        player.CurrentMove = FIghtMoves.Moves.Standing;
        manage.CurrentEnemy=null;
        Debug.Log("Combat ended");
    }
    public void Win()
    {
        if (GameEnded == true)
        {
            return;
        }
        if(time.TimeLeft>0 && ph.CurrentHealth > 0)
        {
            player.current=Script1.PlayerState.Win;
            Debug.Log("You win!!");
        }
    }
    public void Lose()
    {
        if (GameEnded == true)
        {
            return;
        }
        if (ph.CurrentHealth <= 0)
        {
            GameEnded=true;
            ph.Die();
        }
        else if (time.TimeLeft <= 0)
        {
            GameEnded=true;
            player.Loser();
        }
    }
    public void CheckEndCombat()
    {
        bool anyAlive = false;
        foreach (var e in manage.Enemies)
        {
            if (e.HealthLeft > 0)
            {
                anyAlive = true;
                break;
            }
        }
        if (!anyAlive)
        {
            EndCombat();
        }
}

}
