using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObject : MonoBehaviour
{
    private Vector3 MousePosition;

    private Transform targetPos;

    public Vector3 origMousePos{get;set;}
    public Vector3 origTargetPos{get;set;}

    public RectTransform boundaryTrans = null;

    

    void OnMouseDown(){

        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Debug.Log(MousePosition);

        targetPos = this.gameObject.transform;

        origMousePos = new Vector3(MousePosition.x,MousePosition.y,MousePosition.z);
        origTargetPos = new Vector3(targetPos.position.x,targetPos.position.y,targetPos.position.z);       
        
    }

    void OnMouseDrag(){

        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Vector3 movePos =  MousePosition - origMousePos;

        //선 위치 후 판단
        this.gameObject.transform.position = new Vector3(origTargetPos.x, origTargetPos.x+movePos.y,origTargetPos.z);   

        if( this.gameObject.transform.localPosition.y < -boundaryTrans.rect.height/2 ){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, -boundaryTrans.rect.height/2,origTargetPos.z);   
        }   
        else if( this.gameObject.transform.localPosition.y > boundaryTrans.rect.height/2){
            this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, boundaryTrans.rect.height/2,origTargetPos.z);   
        }      
                 
    }
    void OnMouseUp(){
        if(targetPos !=  null){
                targetPos.position = new Vector3(origTargetPos.x,origTargetPos.y,origTargetPos.z);
            }
            
            targetPos = null;    
    }
}
