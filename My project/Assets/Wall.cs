using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool Triggered=false;
    public Script1 player;
    public CentralSystem central;
    private void OnTriggerEnter(Collider other)
    {
        if (Triggered == true)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            Triggered=true;
            central.Win();

        }
    }
}
