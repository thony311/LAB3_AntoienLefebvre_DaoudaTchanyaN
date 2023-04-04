using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptFin : MonoBehaviour
{
    //Attributs
    private GestionPlayer player;
    private GestionJeu gestionJeu;

    void Start()
    {
        // Va chercher le player et le gestion jeu
        player = FindObjectOfType<GestionPlayer>();
        gestionJeu = FindObjectOfType<GestionJeu>();
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Prend le niveau que le joueur est rendu
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        // Lorsque que le joueur rentre en collision avec l'objet de fin il met fin au jeu
        if(collision.gameObject.tag == "Player")
            if (indexScene == 2)
            {
                // récupère le pointage
                gestionJeu.SetPointageNiv(indexScene, gestionJeu.getPointage());
                gestionJeu.SetTempsNiv(indexScene, Time.time - player.GetTimeStart());
                // temps par niveau
                float tempsNiv1 = gestionJeu.GetTempsNiv(0);
                float tempsNiv2 = gestionJeu.GetTempsNiv(1) - tempsNiv1;
                if(tempsNiv2 < 0)
                {
                    tempsNiv2 *= -1;
                }
                float tempsNiv3 = gestionJeu.GetTempsNiv(2) - gestionJeu.GetTempsNiv(1);
                if(tempsNiv3 < 0)
                {
                    tempsNiv3 *= -1;
                }
                // erreurs
                float nbErreursNiv1 = gestionJeu.GetPointageNiv(0);
                float nbErreursNiv2 = gestionJeu.GetPointageNiv(1) - nbErreursNiv1;
                if(nbErreursNiv2 < 0)
                {
                    nbErreursNiv2 *= -1;
                }
                float nbErreursNiv3 = gestionJeu.GetPointageNiv(2) - gestionJeu.GetPointageNiv(1);
                if(nbErreursNiv3 < 0)
                {
                    nbErreursNiv3 *= -1;
                }
                // temps total
                float tempsTotal1 = tempsNiv1 + nbErreursNiv1;
                float tempsTotal2 = tempsNiv2 + nbErreursNiv2;
                float tempsTotal3 = tempsNiv3 + nbErreursNiv3;
                // fin
                float tempTotal = gestionJeu.GetPointageNiv(2) + gestionJeu.GetTempsNiv(2);
                float nbErreursTotal = gestionJeu.GetPointageNiv(2);

                // retourne les informations de la fin du jeu et bloque les mouvements du joueur
                Debug.Log("!!!!!!Fin du jeu!!!!!!!");
                Debug.Log("Votre temps de jeu du niveau 1 est de " + tempsNiv1 + " sec avec " + nbErreursNiv1 + " collisions alors vous avec un temps total de " + tempsTotal1 + " sec");
                Debug.Log("Votre temps de jeu du niveau 2 est de " + tempsNiv2 + " sec avec " + nbErreursNiv2 + " collisions alors vous avec un temps total de " + tempsTotal2 + " sec");
                Debug.Log("Votre temps de jeu du niveau 3 est de " + tempsNiv3 + " sec avec " + nbErreursNiv3 + " collisions alors vous avec un temps total de " + tempsTotal3 + " sec");
                Debug.Log("Votre temps total pour les trois niveau de jeu est de " + tempTotal + " sec et votre nombre de collisions total est de " + nbErreursTotal);

                player.finDeJeu();
            }
            else
            {
                // changer la scene suivante
                SceneManager.LoadScene(indexScene + 1);
                // Récupére les données de pointage et de temps
                gestionJeu.SetTempsNiv(indexScene, Time.time - player.GetTimeStart());
                gestionJeu.SetPointageNiv(indexScene, gestionJeu.getPointage());
            }
    }

}
