using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class crosshair : MonoBehaviour
{


    public float  GradY; 
    private float rotationZ = 0f;
    private float sensitivityZ = 2f;
    public GameObject Player;               // object to follow
    private Vector3 Location;               // vector for position to follow the ball
    public float mouseSensitivity = 0.09f;  // the sensitivity of the movement of the character (speed)                                 
    public Transform PlayerBody;            // to control the player's body
    private float centroX = Screen.width/2; // I calculate the center of the screen on the X axis
    private float centroY = Screen.height/2;// I calculate the center of the screen on the Y axis
    float xrotation = 0f;  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveCrossHair(){

    // I instantiate an object that will control eyes tracker
    GazePoint  gazePoint = TobiiAPI.GetGazePoint();

    // check that eyes tracker is available        
    if(gazePoint.IsRecent()){
         
            // reposition the center and coordinates to make the screen move with the eye tracker

            float xMouse = (gazePoint.Screen.x-centroX)*mouseSensitivity*Time.deltaTime;
            float yMouse = (gazePoint.Screen.y-centroY)*mouseSensitivity*Time.deltaTime;

            //transform.position = new Vector3(xMouse,yMouse,0f);
            
           
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        MoveCrossHair();
    }
}
