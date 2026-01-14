using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
public class camera : MonoBehaviour 
{ 
    public Transform target; 
    void LateUpdate() 
    { 
        Vector3 lookPoint = target.position + Vector3.up*0.1f; 
        transform.LookAt(lookPoint); 
        } 
}