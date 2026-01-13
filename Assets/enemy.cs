using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float PrepTime=1f;

    private Renderer material;

    private bool Triggered=false;
    public FIghtMoves fightmoves;
    private HealthEnemy myhealth;
    public CentralSystem central;
    private EnemyMoves em;
    public Manager EnemyManager;
    void Awake()
{
    EnemyManager = FindObjectOfType<Manager>();
}
    void Start()
    {
        material=GetComponent<Renderer>();

        if(material!=null){
         material.enabled =false;
        }
        myhealth=GetComponent<HealthEnemy>();
        em=GetComponent<EnemyMoves>();
 
    }
   private void OnTriggerEnter(Collider other){
    if (Triggered==true){
        return;
    }
    if(other.CompareTag("Player")){

        Triggered=true;
        EnemyManager.SetEnemy(myhealth);

        if(material!=null){
            material.enabled=true;
        }
        StartCoroutine(FightTime(other));
    }

   }
   private IEnumerator FightTime(Collider playerCollider){

    yield return new WaitForSeconds(PrepTime);
    central.StartCombat();
    if (em!=null){
    em.StartRoutine();
    }
   }
}
