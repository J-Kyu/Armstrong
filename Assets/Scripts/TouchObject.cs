using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour
{


    float MaxDistance = 150f;
    Vector3 MousePosition;

    private Color orgColor = new Color (0,1,0);


    private Vector3 position;

    private Vector3 origMousePos;
    



    // Update is called once per frame
    void Update()
    {


        //touch
        for(int i = 0; i < Input.touchCount; i++){

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);


            //first touch
            if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if(hit.collider.transform.tag == "Chair")
                {
                    orgColor = hit.collider.transform.GetComponent<Image>().color;
                    hit.collider.transform.GetComponent<Image>().color  = new Color(1,0,0);
                }
            }

            //end touch
            if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if(hit.collider.transform.tag == "Chair")
                {
                    hit.collider.transform.GetComponent<Image>().color  = orgColor;
                }
            }


            
        }


    }    



    /*
    phone에서와 pc에서 test를 위해서 function만 고유하고 input 값을 유동적으로 받는다.
    */
    private void MoveTarget(Vector2 touch, GameObject target){
        /*
            move target on touch
        */
        target.transform.Translate( new Vector3(0, touch.y *0.02f,0));
    }
}