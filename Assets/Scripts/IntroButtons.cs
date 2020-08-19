using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IntroButtons : MonoBehaviour
{

    [SerializeField] private Button button500m = null;

    [SerializeField] private Button button1000m = null;

    [SerializeField] private Button button2000m = null;

    [SerializeField] private Button buttonRecord = null;


    [SerializeField] private GameObject introObject = null;
    [SerializeField] private GameObject waveObject = null;

    [SerializeField] private GameObject gameUIObject = null;


    [SerializeField] private Boat boat2x = null;

    [SerializeField] private Boat boat4x = null;





    public void Run500mRecord(){
        StartGame(500.0f);
    }


    public void Run1000mRecord(){
        StartGame(1000.0f);
    }


    public void Run2000mRecord(){
        StartGame(2000.0f);
    }

    private void StartGame(float length){
        waveObject.SetActive(true);
        gameUIObject.SetActive(true);
        introObject.SetActive(false);
        GenerateBoat(length);

    }

    private void GenerateBoat(float length){
        switch(ArmstrongManager.instance.boatType){

         case BoatType.x2:{
                boat2x.gameObject.SetActive(true);
                boat2x.ResetBoat();
                boat2x.record = length;
                boat2x.maxRecord = length;
                break;
            }
            case BoatType.x4:{
                boat4x.gameObject.SetActive(true);
                boat4x.ResetBoat();
                boat4x.record = length;
                boat4x.maxRecord = length;
                break;
            }
            default:{   
                boat2x.gameObject.SetActive(true);
                boat2x.ResetBoat();
                boat2x.record = length;
                boat2x.maxRecord = length;
                break;
            }
        }
    }

    


}
