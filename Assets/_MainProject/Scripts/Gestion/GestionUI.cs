using Mono.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionUI : MonoBehaviour
{
    [SerializeField] GameObject instruction;
    [SerializeField] GameObject temps;
    [SerializeField] GameObject pointage;
    GestionJeu gestionJeu;
    GestionPlayer player;
    // Start is called before the first frame update
    void Start()
    {
       gestionJeu= FindObjectOfType<GestionJeu>();
        player = FindObjectOfType<GestionPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.getDebutJeu() == true)
        {
            int indexScene = SceneManager.GetActiveScene().buildIndex;
            gestionJeu.SetTempsNiv(indexScene -1, Time.time - player.GetTimeStart());
            temps.GetComponent<TMPro.TextMeshProUGUI>().text = "temps : " + Math.Round(gestionJeu.GetTempsNiv(1) + gestionJeu.GetTempsNiv(2) + gestionJeu.GetTempsNiv(0),2,MidpointRounding.AwayFromZero).ToString();
        }
        else
        {
            temps.GetComponent<TMPro.TextMeshProUGUI>().text = Math.Round(gestionJeu.GetTempsNiv(1) + gestionJeu.GetTempsNiv(2) + gestionJeu.GetTempsNiv(3), 2, MidpointRounding.AwayFromZero).ToString();
        }
        

        pointage.GetComponent<TMPro.TextMeshProUGUI>().text = "Accrochages : " + gestionJeu.getPointage().ToString();
    }

    public void Commencer()
    {
        SceneManager.LoadScene(1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void Instruction()
    {
        instruction.SetActive(true);
    }

    public void FermerInstructions()
    {
        instruction.SetActive(false);
    }
}
