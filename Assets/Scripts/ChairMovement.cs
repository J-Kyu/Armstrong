using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairMovement : MonoBehaviour
{

    public enum OarSide{Bow,Stroke}

    public enum ChairStatus{Catch,Rowing, Finish, Recovery}

    private float chairSpeed = 0.2f;

    private Vector3 MousePosition;

    private Transform targetTrans;

    public Vector3 origMousePos{get;set;}
    public Vector3 origTargetPos{get;set;}

    public RectTransform boundaryTrans = null;

    private bool isSelected = false;   

    public Boat boat = null;

    public float countTime = 1.0f;

    [SerializeField] private Transform oarTrans = null;

    [SerializeField] private CircleCollider2D rangeTouchCollider = null; 
    [SerializeField] private GameObject rangeTouchObject = null;

    [SerializeField] private OarSide oarSide;

    public ChairStatus chairStatus = ChairStatus.Recovery;


    void Start(){
        countTime = 1.0f;
    }

    void Update(){
        Rowing();
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
        LogContent.instance.SaveLog(this.gameObject.name, "Mouse Down");

    }

    void OnMouseDrag(){

        if (SystemInfo.deviceType != DeviceType.Desktop){
            return;
        }

        Vector3 currentMousePos =   Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MoveChair(currentMousePos);
 
        LogContent.instance.SaveLog(this.gameObject.name, "Mouse Drag"); 
                 
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
        LogContent.instance.SaveLog(this.gameObject.name, "Mouse Up");
    }


    public void MoveChair(Vector2 touchPosition){

        if (SystemInfo.deviceType != DeviceType.Desktop){
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);        
        }

        Vector2 origTouchPos = this.gameObject.transform.position;

        Vector3 movePos =  touchPosition - origTouchPos;

        LogContent.instance.SaveLog(this.gameObject.name, "movePos: "+touchPosition);
 
        //선 위치 후 판단
        // this.gameObject.transform.position = new Vector3(origTargetPos.x, origTargetPos.y+movePos.y,origTargetPos.z);   
        this.gameObject.transform.Translate( new Vector3(0, movePos.y * chairSpeed,0));   

        if( this.gameObject.transform.localPosition.y < -boundaryTrans.rect.height/2 ){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, -boundaryTrans.rect.height/2,origTargetPos.z);   
        }   
        else if( this.gameObject.transform.localPosition.y > boundaryTrans.rect.height/2){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, boundaryTrans.rect.height/2,origTargetPos.z);   
        }   

    }

    public void ChairSelected()
    {
        rangeTouchCollider.radius = 80.0f;
        rangeTouchObject.SetActive(true);


    }

    public void ChairReleased()
    {
        rangeTouchCollider.radius = 35f;
        rangeTouchObject.SetActive(false);

    }



    private void Rowing(){
        float ratio = this.gameObject.transform.localPosition.y/boundaryTrans.rect.height;
        if(oarSide == OarSide.Bow){
            oarTrans.rotation =  Quaternion.Euler (0,0,ratio*2 * (45));
        }
        else if(oarSide == OarSide.Stroke){
            oarTrans.rotation =  Quaternion.Euler (0,0,ratio*2 * (-45));
        }
        

    }
}
