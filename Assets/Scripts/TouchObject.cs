using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour
{


    float MaxDistance = 150f;
    Vector3 MousePosition;
    Camera camera;
    private HashSet<Transform> target;

    private Vector3 origMousePos;
    private Vector3 origTargetPos;

    private Color orgColor = new Color (0,1,0);


    private Vector3 position;
    private float width;
    private float height;



    void Awake()
    {
        width = (float)Screen.width / 2.0f;
        height = (float)Screen.height / 2.0f;

        // Position used for the cube.
        position = new Vector3(0.0f, 0.0f, 0.0f);
    }
     void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++){
   

                // The pos of the touch on the screen
                Vector2 vTouchPos = Input.GetTouch(i).position;
                    
                // The ray to the touched object in the world
                Ray ray = Camera.main.ScreenPointToRay(vTouchPos);
                    
                // Your raycast handling
                RaycastHit vHit;
                Debug.DrawRay(ray.origin,ray.direction*MaxDistance, Color.red, 0.3f);

                if(Physics.Raycast(ray.origin,ray.direction, out vHit))
                {
                    if(vHit.transform.tag == "Chair") 
                    {
                        vHit.transform.position = new Vector3(vTouchPos.x,vTouchPos.y,0);
                    }
                }
            }


        }
    }    
}