using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class interCube :  GazeAware
{
    void Update()
    {
        GazePoint  gazePoint = TobiiAPI.GetGazePoint();

        
            float xMouse = gazePoint.Screen.x;
            float yMouse = gazePoint.Screen.y;
            RaycastHit hit;

            var ray = Camera.main.ScreenPointToRay(new Vector2(xMouse,yMouse));
                if(Physics.Raycast(ray, out hit)){
                Debug.Log(hit.collider.name);

                // to shoot a small ball like p
                
                if(Input.GetKey("q")){
                    if(hit.collider.CompareTag("enemy_bug")){
                        Destroy(hit.collider.gameObject);
                    }     
                } 
            }
    }
}
