using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private Vector3 MousePosition;

    private Transform targetTrans;

    public Vector3 origMousePos{get;set;}
    public Vector3 origTargetPos{get;set;}

    public RectTransform boundaryTrans = null;

    private bool isSelected = false;    

    void OnMouseDown(){

        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        
        targetTrans = this.gameObject.transform;

        origMousePos = new Vector3(MousePosition.x,MousePosition.y,MousePosition.z);
        origTargetPos = new Vector3(targetTrans.position.x,targetTrans.position.y,targetTrans.position.z);       
       
        isSelected = true;
    }

    void OnMouseDrag(){

        if(!isSelected){
            return ;
        }

        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Vector3 movePos =  MousePosition - origMousePos;

 
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
     void OnMouseUp(){
    //     if(targetTrans !=  null){
    //             targetTrans.position = new Vector3(origTargetPos.x,origTargetPos.y,origTargetPos.z);
    //         }
            
    //         targetTrans = null;    
        isSelected = false;
    }
}
