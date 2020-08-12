using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterChairMovement : MonoBehaviour
{

    public enum ChairStatus{Catch,Rowing, Finish, Recovery}

    private float chairSpeed = 0.2f;

    private Vector3 MousePosition;

    private Transform targetTrans;

    public Vector3 origMousePos{get;set;}
    public Vector3 origTargetPos{get;set;}

    public RectTransform boundaryTrans = null;

    private bool isSelected = false;   

    public float countTime = 1.0f;

    public float speed;
    [SerializeField] private CircleCollider2D rangeTouchCollider = null; 
    [SerializeField] private GameObject rangeTouchObject = null;

    [SerializeField] private Boat boat = null;
    public ChairStatus chairStatus ;



    void Start(){
        chairStatus = ChairStatus.Recovery;
        countTime = 1.0f;
    }



    void OnMouseDown(){
        
        if (SystemInfo.deviceType != DeviceType.Desktop){
            return;
        }

        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        
        targetTrans = this.gameObject.transform;

        origMousePos = new Vector3(MousePosition.x,MousePosition.y,MousePosition.z);
        origTargetPos = new Vector3(targetTrans.position.x,targetTrans.position.y,targetTrans.position.z);       
       
        isSelected = true;
        ChairSelected();
        

    }

    void OnMouseDrag(){

        if (SystemInfo.deviceType != DeviceType.Desktop){
            return;
        }

        Vector3 currentMousePos =   Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MoveChair(currentMousePos);
 
        
                 
    }
     void OnMouseUp(){

        if (SystemInfo.deviceType != DeviceType.Desktop){
            return;
        }

        // if(targetTrans !=  null){
        //         targetTrans.position = new Vector3(origTargetPos.x,origTargetPos.y,origTargetPos.z);
        //     }
            
        targetTrans = null;    
        isSelected = false;

        ChairReleased();
        
    }


    public void MoveChair(Vector2 touchPosition){

        if (SystemInfo.deviceType != DeviceType.Desktop){
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);        
        }

        Vector2 origTouchPos = this.gameObject.transform.position;

        Vector3 movePos =  touchPosition - origTouchPos;

        
 
        //선 위치 후 판단
        // this.gameObject.transform.position = new Vector3(origTargetPos.x, origTargetPos.y+movePos.y,origTargetPos.z);   
        this.gameObject.transform.Translate( new Vector3(0, movePos.y * chairSpeed,0));   

        if( this.gameObject.transform.localPosition.y < -boundaryTrans.rect.height/2 ){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, -boundaryTrans.rect.height/2,0);   
        }   
        else if( this.gameObject.transform.localPosition.y > boundaryTrans.rect.height/2){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, boundaryTrans.rect.height/2,0);   
        }   



        //boat
        for(int i = 0 ; i < boat.chairMovementsList.Count; i++){

            Vector3 chairPos = boat.chairMovementsList[i].gameObject.transform.localPosition;
            boat.chairMovementsList[i].gameObject.transform.localPosition = new Vector3(chairPos.x, this.gameObject.transform.localPosition.y - origTouchPos.y,chairPos.z);   

        }

    }

    public void ChairSelected()
    {
        rangeTouchCollider.radius = 85.0f;
        rangeTouchObject.SetActive(true);


    }

    public void ChairReleased()
    {
        rangeTouchCollider.radius = 35f;
        rangeTouchObject.SetActive(false);

    }


}
