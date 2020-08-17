using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLine : MonoBehaviour
{
    
    [SerializeField] List<Transform> waveTransformsList = null;

    private float basicSpeed = 0.0f;

    void Awake(){

        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        for(int i = 0; i < waveTransformsList.Count; i++){

            RectTransform rt = waveTransformsList[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(0.0f,Screen.height);
        }



    }

    void Update(){
        Waving();
    }

    private void Waving(){

        for(int i = 0; i < waveTransformsList.Count; i++){
            if(waveTransformsList[i].localPosition.y  < Screen.height){
                
                waveTransformsList[i].Translate( new Vector3(0, basicSpeed,0));   

            }
            else{
                waveTransformsList[i].localPosition = new Vector3(0,-Screen.height,0);
            }
        }
    }

    public void CalSpeed(float powerSpeed){
    
        basicSpeed = powerSpeed;

    }


}
