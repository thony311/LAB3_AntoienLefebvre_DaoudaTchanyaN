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
    [SerializeField] GameObject menuPause;

    [SerializeField] GameObject pointageFinal;
    [SerializeField] GameObject tempsFinal;
    [SerializeField] GameObject tempsPointagefinal;

    GestionJeu gestionJeu;
    GestionPlayer player;
    bool pause = false;
    float tempsPause;
    int indexScene;
    // Start is called before the first frame update
    void Start()
    {
       gestionJeu= FindObjectOfType<GestionJeu>();
       player = FindObjectOfType<GestionPlayer>();
       indexScene = SceneManager.GetActiveScene().buildIndex;

        try
        {
            pointageFinal.GetComponent<TMPro.TextMeshProUGUI>().text = "Pointage Final : " + gestionJeu.getPointage().ToString();
            tempsFinal.GetComponent<TMPro.TextMeshProUGUI>().text = "Vous avez fait " +(gestionJeu.GetTempsNiv(1) + gestionJeu.GetTempsNiv(2) + gestionJeu.GetTempsNiv(0) - gestionJeu.getTempsPause()).ToString() + " sec";
            tempsPointagefinal.GetComponent<TMPro.TextMeshProUGUI>().text = "Votre temps final est donc de " + (gestionJeu.GetTempsNiv(1) + gestionJeu.GetTempsNiv(2) + gestionJeu.GetTempsNiv(0) - gestionJeu.getTempsPause() + gestionJeu.getPointage()).ToString();
        }
        catch 
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            pause = true;
            menuPause.SetActive(true);
            player.finDeJeu();
            tempsPause = gestionJeu.GetTempsNiv(0) + gestionJeu.GetTempsNiv(1) + gestionJeu.GetTempsNiv(2);
        }
        if(player.getDebutJeu() == true && pause == false)
        {
            
            gestionJeu.SetTempsNiv(indexScene -1, Time.time - player.GetTimeStart());
            temps.GetComponent<TMPro.TextMeshProUGUI>().text = "temps : " + Math.Round(gestionJeu.GetTempsNiv(1) + gestionJeu.GetTempsNiv(2) + gestionJeu.GetTempsNiv(0) - gestionJeu.getTempsPause(),2,MidpointRounding.AwayFromZero).ToString();
        }
        else
        {
            temps.GetComponent<TMPro.TextMeshProUGUI>().text = "temps : " + Math.Round(gestionJeu.GetTempsNiv(1) + gestionJeu.GetTempsNiv(2) + gestionJeu.GetTempsNiv(0) - gestionJeu.getTempsPause(), 2, MidpointRounding.AwayFromZero).ToString();
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

    public void RetourMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void EnvleverPause()
    {
        pause = false;
        menuPause.SetActive(false);
        player.EnleverFinJeu();
        gestionJeu.SetTempsPause((Time.time - player.GetTimeStart()) - gestionJeu.GetTempsNiv(indexScene - 1));
    }
}
