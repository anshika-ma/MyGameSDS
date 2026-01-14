using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIghtMoves : MonoBehaviour
{   
    public int defencedamage=0;
    public int punchdamage=1;
    public int kickdamage=1;
    public int specialmovedamage=3;
    private Script1 player;
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
    public bool SpecialMove;
    public Moves CurrentMove = Moves.Standing;
    void Start()
    {
        player=GetComponent<Script1>();
        SpecialMove=false;
        CurrentMove=Moves.Standing;
    }
    void Update()
    {
        if (player.current != Script1.PlayerState.Combat){
            return;
        }
        player.CurrentMove = Moves.Standing;
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.RightArrow)){
            player.CurrentMove=Moves.LowerPunch;
            Debug.Log("Lower Punch");
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.LeftArrow)){
            player.CurrentMove=Moves.UpperKick;
            Debug.Log("Upper Kick");
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            player.CurrentMove=Moves.UpperDefence;
            Debug.Log("Upper Defence");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)){
            player.CurrentMove=Moves.LowerDefence;
            Debug.Log("Lower Defence");
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
            player.CurrentMove=Moves.UpperPunch;
            Debug.Log("Upper Punch");
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            player.CurrentMove=Moves.LowerKick;
            Debug.Log("Lower Kick");
        }
        else if(Input.GetKeyDown(KeyCode.Space)){
            if (SpecialMove==false){
                player.CurrentMove=Moves.SpecialMove;
                Debug.Log("Special Kick");
            }
            else if (SpecialMove==true){
                
            }
        }
    }
}