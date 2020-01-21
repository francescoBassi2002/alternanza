using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_music : MonoBehaviour
{   
    
    public int speed = 4;
    private int errorBug =11;
    public Transform parent;
    public GameObject[] prefab;  
    public int resu;
    public int height;
    public int width;
    public AudioSource NameMusic = null;
    public GameObject cubo;
    public GameObject cubo2;
    private AudioSource audioSource;
    public Vector3 startPos = new Vector3(-3.08f,-1.18f,-7.31f);
    private float maxY = 5;
   



    private void Awake() {
        
        createdCube();
    
    }




    private void createdCube(){
        int i  = 0;
        prefab = new GameObject[height * width];
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++,i++)
            {
                
                    if((i%errorBug)==0){
                        prefab[i]= Instantiate(cubo2, new Vector3(x,Random.Range(1,5),y), Quaternion.identity);
                        prefab[i].transform.parent = parent;
                    }else{
                        prefab[i]= Instantiate(cubo, new Vector3(x,Random.Range(1,5),y), Quaternion.identity);
                        prefab[i].transform.parent = parent;
                    }
                
                    prefab[i].transform.position = new Vector3(x,prefab[i].transform.position.y,y);
            }
        }
    }

    private void ChangePosition(){
        int i = 0;
        for(int x = 0; x < height ; x++){
            for (int y = 0; y < width; y++,i++)
            {
                if(prefab[i].transform.position.y == maxY){
                    Debug.Log("maggiore");
                    prefab[i].transform.Translate(0f,(maxY*Time.deltaTime)*-1,0f);
                }
                if(prefab[i].transform.position.y > maxY){
                    //Debug.Log("minore");
                    prefab[i].transform.Translate(0f,speed*Time.deltaTime,0f);
                }
                
            }
        }
    }


    void Start()
    {
       
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //ChangePosition();
        transform.Translate(0f,0f,20*Time.deltaTime);
    }
}





