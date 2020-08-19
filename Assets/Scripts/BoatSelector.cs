using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSelector : MonoBehaviour
{


    [SerializeField] private List<GameObject> boatThumbnails = null;
    private List<GameObject> thumbnailPrefabs = new List<GameObject>();


    private int curBoatVersion = 0;

    private const float radius = 500.0f;

    private float countSecs = 0.0f;

    private bool isPrevDone = true;
    private float startYAngle = 0.0f;
    private float btwAngle = 0.0f;
    const float rotateSecs = .7f;

    private int  direction = 0;

    


    private Queue directionQueue = new Queue();


    void Awake(){

    }

    void Start(){
        float angle = -90.0f;
        btwAngle = 360/boatThumbnails.Count;


        Vector3 pos = this.gameObject.transform.localPosition;
        for(int i = 0; i < boatThumbnails.Count; i++){

            var thumbnials = Instantiate(boatThumbnails[i].gameObject,this.gameObject.transform,false);
            thumbnials.gameObject.transform.localPosition = new Vector3(pos.x+radius*Mathf.Cos(angle*Mathf.Deg2Rad),pos.y,pos.z+radius*Mathf.Sin(angle*Mathf.Deg2Rad));
            
            angle += btwAngle;

            thumbnailPrefabs.Add(thumbnials);
        }

        
        

        thumbnailPrefabs[curBoatVersion].transform.SetSiblingIndex(thumbnailPrefabs.Count-1);
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x,this.gameObject.transform.localPosition.y,radius);
        SetAlpha();
    }
    

    void Update(){
    

        //flag for cirtical section
        //synchronously하게 작동을 해야 한다
        if(isPrevDone && directionQueue.Count > 0){
            isPrevDone = false;
            direction = (int)directionQueue.Dequeue();
            startYAngle = this.gameObject.transform.localEulerAngles.y;
        }

        switch(direction){
            case 1:{
                //right
                DoRotate((int)-btwAngle,startYAngle-btwAngle);
                break;
            }
            case -1:{
                // left
                DoRotate((int)btwAngle,startYAngle+btwAngle);
                break;
            }
            default :{
                // Debug.Log("No Such Values");
                break;
            }
        }
        
    }
    public void RotateRight(){
        
        if(curBoatVersion >= 1){
            curBoatVersion--;
        }
        else{
            curBoatVersion = thumbnailPrefabs.Count-1;
        }

        directionQueue.Enqueue(1);        
    }

    public void RotateLeft(){

        if(curBoatVersion+1 < thumbnailPrefabs.Count){
            curBoatVersion++;
        }
        else{
            curBoatVersion = 0;
        }

        directionQueue.Enqueue(-1);
    }

    private void DoRotate(int angle, float tragetAngle){

        
        this.gameObject.transform.Rotate(0,angle*Time.deltaTime/rotateSecs,0);
        countSecs += Time.deltaTime;

        if(countSecs >= rotateSecs){
            this.gameObject.transform.rotation = Quaternion.Euler(this.gameObject.transform.localEulerAngles.x, tragetAngle,0);
            SetAlpha();
                  
            thumbnailPrefabs[curBoatVersion].transform.SetSiblingIndex(thumbnailPrefabs.Count-1);
            // thumbnailPrefabs[curBoatVersion].transform.SetSiblingIndex(1);




            countSecs = 0.0f;
            direction = 0;
            isPrevDone = true;
        }

        //Set Boat Type to Armstrong Manager
        thumbnailPrefabs[curBoatVersion].GetComponent<BoatThumbnail>().SetBoat();


    }

    public void SetAlpha(){
        for(int i = 0 ; i < thumbnailPrefabs.Count; i++){
            thumbnailPrefabs[i].GetComponent<BoatThumbnail>().SetAlpha(0.2f);
        }
        thumbnailPrefabs[curBoatVersion].GetComponent<BoatThumbnail>().SetAlpha(1.0f);
        Debug.Log(thumbnailPrefabs[curBoatVersion].name);
    }

}
