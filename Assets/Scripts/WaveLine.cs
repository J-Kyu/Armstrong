using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLine : MonoBehaviour
{
    
    [SerializeField] List<Transform> waveTransformsList = null;

    private float basicSpeed = 0.0f;

    void Update(){
        Waving();
    }

    private void Waving(){

        for(int i = 0; i < waveTransformsList.Count; i++){
            if(waveTransformsList[i].localPosition.y  < 2560.0f){
                
                waveTransformsList[i].Translate( new Vector3(0, basicSpeed,0));   

            }
            else{
                waveTransformsList[i].localPosition = new Vector3(0,-2560.0f,0);
            }
        }
    }

    public void CalSpeed(float powerSpeed){
    
        basicSpeed = powerSpeed;

    }


}
