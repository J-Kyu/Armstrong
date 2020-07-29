using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour
{
    Vector3 MousePosition;

    private Color orgColor = new Color (0,1,0);


    private Vector3 position;

    private Vector3 origMousePos;
    
    private Dictionary<int,Vector2> touchDic = new Dictionary<int,Vector2>();



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
                    //register fingerID and start Pos as pair
                    touchDic.Add(Input.GetTouch(i).fingerId,Input.GetTouch(i).position);
                }
            }

            if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                if(hit.collider.transform.tag == "Chair")
                {
                    //translate
                    Vector2 movingPos = Input.GetTouch(i).position -  touchDic[Input.GetTouch(i).fingerId];
                    hit.transform.Translate( new Vector3(0, movingPos.y *0.02f,0));
                }
            }


            //end touch
            if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if(hit.collider.transform.tag == "Chair")
                {
                    //remove fingerID and start Pos as pair
                    touchDic.Remove(Input.GetTouch(i).fingerId);
                }
            }


            
        }


    }    
}