using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChairMovement : MonoBehaviour
{

    private Vector3 MousePosition;

    private Transform targetTrans;

    public Vector3 origMousePos{get;set;}
    public Vector3 origTargetPos{get;set;}

    public RectTransform boundaryTrans = null;

    private Color orgColor;

    private bool isSelected = false;    


    void Start(){

        orgColor = this.gameObject.GetComponent<Image>().color;
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
        LogContent.instance.SaveLog(this.gameObject.name, "Mouse Down");
    }

    void OnMouseDrag(){

        if (SystemInfo.deviceType != DeviceType.Desktop){
            return;
        }

        Vector3 currentMousePos =   Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MoveChair(currentMousePos, origMousePos);
 
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


        LogContent.instance.SaveLog(this.gameObject.name, "Mouse Up");
    }


    public void MoveChair(Vector2 touchPosition, Vector2 origTouchPos){

        if (SystemInfo.deviceType != DeviceType.Desktop){
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);    
            origTouchPos = Camera.main.ScreenToWorldPoint(origTouchPos);    
        }

        Vector3 movePos =  touchPosition - origTouchPos;

        LogContent.instance.SaveLog(this.gameObject.name, "movePos: "+touchPosition);
 
        //선 위치 후 판단
        // this.gameObject.transform.position = new Vector3(origTargetPos.x, origTargetPos.y+movePos.y,origTargetPos.z);   
        this.gameObject.transform.Translate( new Vector3(0, movePos.y *0.02f,0));   

        if( this.gameObject.transform.localPosition.y < -boundaryTrans.rect.height/2 ){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, -boundaryTrans.rect.height/2,origTargetPos.z);   
        }   
        else if( this.gameObject.transform.localPosition.y > boundaryTrans.rect.height/2){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, boundaryTrans.rect.height/2,origTargetPos.z);   
        }   

    }

    
}