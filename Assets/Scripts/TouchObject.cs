using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour
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


        // this.gameObject.GetComponent<Image>().color = new Color(1,0,0);
        // MousePosition = Input.mousePosition;
        // MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        
        // targetTrans = this.gameObject.transform;

        // origMousePos = new Vector3(MousePosition.x,MousePosition.y,MousePosition.z);
        // origTargetPos = new Vector3(targetTrans.position.x,targetTrans.position.y,targetTrans.position.z);       
       
        // isSelected = true;
    }

    void OnMouseDrag(){

        if(!isSelected){
            this.gameObject.GetComponent<Image>().color = new Color(1,0,0);
            isSelected = true;
        }

        // if(!isSelected){
            
        //     Debug.Log("New Touch: "+this.gameObject.transform.parent.name);

        //     MousePosition = Input.mousePosition;
        //     MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            
        //     targetTrans = this.gameObject.transform;

        //     origMousePos = new Vector3(MousePosition.x,MousePosition.y,MousePosition.z);
        //     origTargetPos = new Vector3(targetTrans.position.x,targetTrans.position.y,targetTrans.position.z);       
        
        //     isSelected = true;
            
        //     return ;
        // }

        // MousePosition = Input.mousePosition;
        // MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        // Vector3 movePos =  MousePosition - origMousePos;

 
        // //선 위치 후 판단
        // // this.gameObject.transform.position = new Vector3(origTargetPos.x, origTargetPos.y+movePos.y,origTargetPos.z);   
        // this.gameObject.transform.Translate( new Vector3(0, movePos.y *0.02f,0));   

        // if( this.gameObject.transform.localPosition.y < -boundaryTrans.rect.height/2 ){
        //     this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, -boundaryTrans.rect.height/2,origTargetPos.z);   
        // }   
        // else if( this.gameObject.transform.localPosition.y > boundaryTrans.rect.height/2){
        //     this.gameObject.transform.localPosition = new Vector3(origTargetPos.x, boundaryTrans.rect.height/2,origTargetPos.z);   
        // }    
                 
    }
     void OnMouseUp(){


        this.gameObject.GetComponent<Image>().color = orgColor;
    //     if(targetTrans !=  null){
    //             targetTrans.position = new Vector3(origTargetPos.x,origTargetPos.y,origTargetPos.z);
    //         }
            
    //         targetTrans = null;    
        isSelected = false;
    }
}
