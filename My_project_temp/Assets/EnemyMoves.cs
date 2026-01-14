using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    public int defencedamage=0;
    public int punchdamage=1;
    public int kickdamage=1;
    public int specialmovedamage=3;
    private enemy ENEMY;
    public enum Moves{
        Standing,
        UpperDefence,
        LowerDefence,
        UpperPunch,
        LowerPunch,
        UpperKick,
        LowerKick,
        SpecialMove
    }
    public Moves CurrentStatus= Moves.Standing;
    public bool SpecialMove=false;
    private HealthEnemy health;
    private Renderer combat;
    public void MovesAsColor(Moves move)
    {
        Color c;
        if (combat == null) {
        return;
        }

        if(move == Moves.Standing)
        {
            ColorUtility.TryParseHtmlString("#E66167", out c);
            combat.material.color= c;
        }
        else if(move == Moves.LowerPunch)
        {
            combat.material.color= Color.cyan;
        }
        else if(move == Moves.UpperKick)
        {
            ColorUtility.TryParseHtmlString("#DE8DDB", out c);
            combat.material.color= c;
        }
        else if(move == Moves.UpperDefence)
        {
            combat.material.color= Color.yellow;
        }
        else if(move == Moves.LowerDefence)
        {
            combat.material.color= Color.white;
        }
        else if(move == Moves.UpperPunch)
        {
            combat.material.color= Color.green;
        }
        else if(move == Moves.LowerKick)
        {
            combat.material.color= Color.magenta;
        }
        else if(move == Moves.SpecialMove)
        {
            ColorUtility.TryParseHtmlString("#9B75CF", out c);
            combat.material.color= c;
        }
    
    }
    void ChooseMoveEnemy()
    {
        Moves[] allMoves = new Moves[]
        {
            Moves.Standing,
            Moves.UpperDefence,
            Moves.LowerDefence,
            Moves.UpperPunch,
            Moves.LowerPunch,
            Moves.UpperKick,
            Moves.LowerKick,
        };
        if (SpecialMove!=true && Random.value < 0.16f)
        {
            CurrentStatus= Moves.SpecialMove;
            SpecialMove=true;
            MovesAsColor(CurrentStatus);
            return;
        }
        int RandomMove= Random.Range(0,allMoves.Length);
        CurrentStatus= allMoves[RandomMove];
        MovesAsColor(CurrentStatus);
    }
    public CentralSystem x;
    public Script1 player;
    public FIghtMoves playerMoves;
    float TimeToReact()
    {
        if (GameSettings.CurrentDifficulty == Difficulty.Easy)
        {
            return Random.Range(1f,1.2f);
        }
        else if (GameSettings.CurrentDifficulty == Difficulty.Medium)
        {
            return Random.Range(0.65f,1f);
        }
        else
        {
            return Random.Range(0.4f,0.65f);
        }
    }
    void Start()
    {
        health=GetComponent<HealthEnemy>();
        ENEMY=GetComponent<enemy>();
        combat = GetComponent<Renderer>();
    }
    Coroutine idk;
    public void StartRoutine()
    {
        if (idk == null)
        {
            idk=StartCoroutine(EnemyFights());
        }
    }
    public void StopRoutine()
    {
        if (idk != null)
        {
            StopCoroutine(idk);
            idk=null;
        }
    }
    private IEnumerator EnemyFights()
    {
        while (x.CombatStart==true && health.HealthLeft > 0)
        {
            ChooseMoveEnemy();
            Moves action = CurrentStatus;
            float ReactionTime = TimeToReact();
            float timer = 0f;
            player.CurrentMove = FIghtMoves.Moves.Standing;

            while (timer < ReactionTime)
            {
                timer += Time.deltaTime;

                if (x.player != null && x.player.GetComponent<UI>() != null)
                {
                    UI ui = x.player.GetComponent<UI>();
                    if (ui.EnemySlider != null)
                    {
                        ui.EnemySlider.value = ReactionTime - timer;
                        ui.EnemySlider.maxValue = ReactionTime;
                    }
                }

                yield return null;
            }

    
            x.FightTime(player.CurrentMove, CurrentStatus);

            CurrentStatus = Moves.Standing;
            player.CurrentMove = FIghtMoves.Moves.Standing;

            Debug.Log(action);
        }
    }


}
