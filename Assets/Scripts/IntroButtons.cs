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


    [SerializeField] private Boat boat = null;





    public void Run500mRecord(){
        
        StartGame();
        boat.record = 500.0f;
        boat.maxRecord = 500.0f;        

    }


    public void Run1000mRecord(){

        StartGame();
        boat.record = 1000.0f;
        boat.maxRecord = 1000.0f;
        
    }


    public void Run2000mRecord(){
        
        StartGame();
        boat.record = 2000.0f;
        boat.maxRecord = 2000.0f;
    }

    private void StartGame(){
        waveObject.SetActive(true);
        boat.gameObject.SetActive(true);
        boat.ResetBoat();
        gameUIObject.SetActive(true);
        introObject.SetActive(false);

    }


}
