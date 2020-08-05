using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLine : MonoBehaviour
{
    
    [SerializeField] List<Transform> waveTransformsList = null;

    private float boatPower = 1.0f;
    private float basicSpeed = 1.0f;
    void Update(){
        Waving();
    }

    private void Waving(){

        basicSpeed = Mathf.Abs(Mathf.Sin(Time.time))*0.05f;

        for(int i = 0; i < waveTransformsList.Count; i++){
            if(waveTransformsList[i].localPosition.y  < 2560.0f){
                
                waveTransformsList[i].Translate( new Vector3(0, basicSpeed*boatPower,0));   

            }
            else{
                waveTransformsList[i].localPosition = new Vector3(0,-2560.0f,0);
            }
        }
    }

    public void IncreaseSpeed(){
        boatPower += 0.5f;
    }

    public void DecreaseSpeed(){


        boatPower -= 0.5f;

        if(boatPower <= 0.0f){
            boatPower = 1.0f;
        }
    }


}
