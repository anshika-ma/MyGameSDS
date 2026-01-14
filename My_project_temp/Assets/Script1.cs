using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    public enum PlayerState{
        Moving,
        Combat,
        Paused,
        Dead,
        Win
    }
    public PlayerState current;

    Rigidbody rb;
    public float movingSpeed=0.2f;
    public float turningSpeed=25f;
    public float maxTurnAngle=135f;
    float currentTurn=0f;
    float startingRotation;
    FIghtMoves fightMoves;
    public FIghtMoves.Moves CurrentMove = FIghtMoves.Moves.Standing;
    private Renderer combat;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        current = PlayerState.Moving;

        Vector3 StartPos=rb.position;
        StartPos.y=-0.236f;
        rb.position=StartPos;

        startingRotation=transform.eulerAngles.y;

        fightMoves = GetComponent<FIghtMoves>();
        fightMoves.enabled = false;

        combat=GetComponent<Renderer>();

    }

    public void MovesAsColor(FIghtMoves.Moves move)
    {
        Color c;
        if (combat == null) {
        return;
        }

        if(move == FIghtMoves.Moves.Standing)
        {
            ColorUtility.TryParseHtmlString("#E66167", out c);
            combat.material.color= c;
        }
        else if(move == FIghtMoves.Moves.LowerPunch)
        {
            combat.material.color= Color.cyan;
        }
        else if(move == FIghtMoves.Moves.UpperKick)
        {
            ColorUtility.TryParseHtmlString("#DE8DDB", out c);
            combat.material.color= c;
        }
        else if(move == FIghtMoves.Moves.UpperDefence)
        {
            combat.material.color= Color.yellow;
        }
        else if(move == FIghtMoves.Moves.LowerDefence)
        {
            combat.material.color= Color.white;
        }
        else if(move == FIghtMoves.Moves.UpperPunch)
        {
            combat.material.color= Color.green;
        }
        else if(move == FIghtMoves.Moves.LowerKick)
        {
            combat.material.color= Color.magenta;
        }
        else if(move == FIghtMoves.Moves.SpecialMove)
        {
            ColorUtility.TryParseHtmlString("#9B75CF", out c);
            combat.material.color= c;
        }
    
    }
    void FixedUpdate(){

        if(current==PlayerState.Moving){
            Movement();
            fightMoves.SpecialMove=false;
        }
    }
    void Update()
    {
        if (current == PlayerState.Combat)
        {
            fightMoves.enabled = true;
            MovesAsColor(CurrentMove);

        }
        else
        {
            fightMoves.enabled = false;
        }
    }

    void Movement()
    {
        float x=Input.GetAxis("Horizontal");

        float z=Input.GetAxis("Vertical");
        z=Mathf.Max(0f, z);

        currentTurn+= x * turningSpeed * Time.fixedDeltaTime;
        currentTurn=Mathf.Clamp(currentTurn, -maxTurnAngle, maxTurnAngle);
 
        float Y=startingRotation + currentTurn;
        rb.MoveRotation(Quaternion.Euler(0f, Y, 0f));
        Vector3 moveDir = Quaternion.Euler(0f, Y, 0f) * Vector3.forward;

        Vector3 targetPos = rb.position + moveDir * z * movingSpeed * Time.fixedDeltaTime;
   
        rb.MovePosition(targetPos);
    }
    
    
    public void Loser()
    {
        if (current == PlayerState.Dead)
            return;

        current = PlayerState.Dead;
        Debug.Log("Player is dead");
    }


    
    

}


