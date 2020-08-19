using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmstrongManager : MonoBehaviour
{
    public static ArmstrongManager instance;

    [SerializeField] private Boat boat2x = null;

    [SerializeField] private Boat boat4x = null;

    [SerializeField] private GameObject gmaeUIObject = null;
    [SerializeField] private GameObject lineWaveObject = null;

    [SerializeField] private GameObject introObject = null;

    public BoatType boatType;


    public void ReturnToIntro(){
        boat2x.gameObject.SetActive(false);
        boat4x.gameObject.SetActive(false);
        gmaeUIObject.gameObject.SetActive(false);
        lineWaveObject.gameObject.SetActive(false);
        introObject.gameObject.SetActive(true);

        boat2x.ResetBoat();
        boat4x.ResetBoat();

    }







}
