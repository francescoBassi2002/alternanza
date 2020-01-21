using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 120;            // keeps the score of the character's life
    public int damage = 0;
    public float zMove = 10f;       // movement to go left and right
    public float speed;             //  indicates the speed at which the cube moves
    public bool cond = true;
    public float Max_Dx;
    public float Max_Sx;
    public Camera firstCamera;      // first person
    public Camera secondCamera;     // second person
    private bool fpscamera = true;  // support variable memo. what state is my camera in
    
     // control of life
    private void collDamage(Collision collision, int damage){
        
        Destroy(collision.gameObject);
        hp -= damage;
        if(hp<= 0){
            Destroy(gameObject);
            Debug.Log("hit");
        }
    }

    private void OnCollisionEnter(Collision coll) {

        if(coll.collider.CompareTag("enemy_cubo")){
            damage = 20;
            collDamage(coll,damage);
            
            
        }
        if(coll.collider.CompareTag("enemy_bug")){
            damage = 40;
            collDamage(coll,damage);
        }
        
    }

    public void MovePlayer(){
        transform.rotation = Quaternion.Euler(0f,0f,0f);
        
        if(cond){
            transform.Translate(0f,0f,speed*Time.deltaTime);
            
        }
     
        //  to go right

        if(Input.GetKey("a")){
        if(transform.position.x > Max_Sx){

           transform.Translate((zMove*Time.deltaTime)*-1,0f,0f);
              
        }
        
        }

        //  to go left

        if(Input.GetKey("d")){
        if(transform.position.x < Max_Dx){

            transform.Translate(zMove*Time.deltaTime,0f,0f);

        }
        }
    }

    // function to switch cameras
    public void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            fpscamera  = !fpscamera;
            firstCamera.enabled = fpscamera;
            secondCamera.enabled = !fpscamera; 
        }
        
    }
    // Start is called before the first frame update
    void Start(){
        firstCamera.enabled = fpscamera;
        secondCamera.enabled = !fpscamera;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        switchCamera();
        
    }






}
