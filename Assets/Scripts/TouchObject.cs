﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour
{
    Vector3 MousePosition;

    private Color orgColor = new Color (0,1,0);


    private Vector3 position;

    private Vector3 origMousePos;
    
    private Dictionary<int,GameObject> chairDic = new Dictionary<int,GameObject>();




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
                    //register collider chair
                    chairDic.Add(Input.GetTouch(i).fingerId, hit.transform.gameObject);
                    hit.transform.gameObject.GetComponent<ChairMovement>().ChairSelected();

                    LogContent.instance.SaveLog(this.gameObject.name, "Touch Start");
                }
            }

            if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                if(hit.collider.transform.tag == "Chair")
                {
                    //translate            
                    hit.transform.GetComponent<ChairMovement>().MoveChair(Input.GetTouch(i).position);
                }
            }
        }
    }    
}