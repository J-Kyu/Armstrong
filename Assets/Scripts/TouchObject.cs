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
                switch(hit.collider.transform.tag){
                    case "Chair":{
                        chairDic.Add(Input.GetTouch(i).fingerId, hit.transform.gameObject);
                        hit.transform.gameObject.GetComponent<ChairMovement>().ChairSelected();

                        LogContent.instance.SaveLog(this.gameObject.name, "Touch Start");
                        break;
                    }
                    case "MasterChair":{

                        chairDic.Add(Input.GetTouch(i).fingerId, hit.transform.gameObject);
                        hit.transform.gameObject.GetComponent<MasterChairMovement>().ChairSelected();

                        LogContent.instance.SaveLog(this.gameObject.name, "Touch Start");
              
                        break;
                    }
                    default:{
                        LogContent.instance.SaveLog(this.gameObject.name, "Touch Start");
                        break;
                    }
                }
            }

            if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Moved)
            {

                switch(hit.collider.transform.tag){
                    case "Chair":{
                         hit.transform.GetComponent<ChairMovement>().MoveChair(Input.GetTouch(i).position);
                        break;
                    }
                    case "MasterChair":{

                         hit.transform.GetComponent<MasterChairMovement>().MoveChair(Input.GetTouch(i).position);
              
                        break;
                    }
                    default:{
                        LogContent.instance.SaveLog(this.gameObject.name, "Touch Start");
                        break;
                    }
                    
                }
            }
        }
    
    
        //Check Get
        bool keyExist = false;
        foreach (int key in chairDic.Keys){

            for(int i = 0; i < Input.touchCount; i++){

                if(Input.GetTouch(i).fingerId == key){
                    keyExist = true;
                    break;
                }
            }

            if(!keyExist){
                //remove
                switch(chairDic[key].transform.tag){
                    case "Chair":{
                        chairDic[key].GetComponent<ChairMovement>().ChairReleased();
                        break;
                    }
                    case "MasterChair":{

                        chairDic[key].GetComponent<MasterChairMovement>().ChairReleased();
                        break;
                    }
                    default:{
                        LogContent.instance.SaveLog(this.gameObject.name, "Touch Start");
                        break;
                    }
                }        
                chairDic.Remove(key);
            }
            keyExist = false;

        }




    }    
}