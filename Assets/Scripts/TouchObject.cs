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
    private float width;
    private float height;



    // Update is called once per frame
    void Update()
    {



        if (Input.touchCount > 0)
        {

            
            for(int i = 0; i < Input.touchCount; i++){
   

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);
  
                // Debug.DrawRay(ray.origin,ray.direction*MaxDistance, Color.red, 0.3f);
                if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    // Construct a ray from the current touch coordinates

                    // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                    if(hit.collider.transform.tag == "Chair")
                    {
                        orgColor = hit.collider.transform.GetComponent<Image>().color;
                        hit.collider.transform.GetComponent<Image>().color  = new Color(1,0,0);
                    }
                }

                if (hit.collider != null && Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    // Construct a ray from the current touch coordinates

                    // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                    if(hit.collider.transform.tag == "Chair")
                    {
                        hit.collider.transform.GetComponent<Image>().color  = orgColor;
                    }
                }


               
            }


        }
    }    
}