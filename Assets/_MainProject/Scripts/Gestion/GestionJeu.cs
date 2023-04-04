using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionJeu : MonoBehaviour
{
    // attributs
    private int _pointage;
    private float[] _tempsNiv = new float[3];
    private int[] _pointageNiv = new int[3];

    private void Awake()
    {
        // Vérifi si il y a un gestion jeu dedans le nouveau niveau, si oui il le detruit pour garder l'ancien aussi non il le garde
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // Lance les introductions et initialise le pointage a 0
        _pointage = 0;
        Instructions();

    }

    private static void Instructions()
    {
        // Ecrit les instructions du jeu
        Debug.Log("*** Course à obstacles ***");
        Debug.Log("Atteinfre la fin du parcours le plus rapidement possible");
    }

    
    public void AugmenterPointage()
    {
        // Augmente le pointage de 1 
        _pointage++;
        Debug.Log("Nombre d'accrochage :" + _pointage);
    }

    public int getPointage()
    {
        // Retourne le pointage
        return _pointage;
    }

    // prend le temps par niveau
    public void SetTempsNiv(int index,float temps)
    {
        // Prend le temps de chaque niveau
        _tempsNiv[index] = temps;
    }
    // prend le pointage par niveau
    public void SetPointageNiv(int index,int pointage) 
    {
        _pointageNiv[index] = pointage;
    }
    // retourne le pointage par niveau
    public int GetPointageNiv(int index)
    {
        return _pointageNiv[index];
    }
    // retourne le temps par niveau
    public float GetTempsNiv(int index) 
    { 
        return _tempsNiv[index];
    }
}
