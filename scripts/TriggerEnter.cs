using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    // the point from which the spwan occurs
    public List<GameObject> SpawnPoint = new List<GameObject>();

    // the object I will make appear where the Spwanpoint is
    public GameObject PrefabCube ;

    private void OnTriggerEnter(Collider col){
        // test I create a cube of the Spawn point
        for(int i = 0; i<SpawnPoint.Count;i++){
            
            Instantiate(PrefabCube,SpawnPoint[i].transform.position,Quaternion.Euler(0,180,0)); 
        } 
    }
}
