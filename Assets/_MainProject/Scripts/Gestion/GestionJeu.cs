using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    // attributs
    private int _pointage;
    private float[] _tempsNiv = new float[3];
    private int[] _pointageNiv = new int[3];
    private float _tempsFinal;
    private float _tempsPause;

    private void Awake()
    {
        // V�rifi si il y a un gestion jeu dedans le nouveau niveau, si oui il le detruit pour garder l'ancien aussi non il le garde
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        if (nbGestionJeu > 1 || indexScene == 0)
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
        _tempsNiv[0] = 0;
        _tempsNiv[1] = 0;
        _tempsNiv[2] = 0;
        _pointageNiv[0] = 0;
        _pointageNiv[1] = 0;
        _pointageNiv[2] = 0;
        _tempsPause= 0;
    }

    private static void Instructions()
    {
        // Ecrit les instructions du jeu
        Debug.Log("*** Course � obstacles ***");
        Debug.Log("Atteindre la fin du parcours le plus rapidement possible");
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

    public void setTempsFinal(float tempsFinal)
    {
        _tempsFinal = tempsFinal;
    }

    public float getTempsFinal()
    {
        return _tempsFinal;
    }

    public float getTempsPause()
    {
        return _tempsPause;
    }

    public void SetTempsPause(float tempsPause)
    {
        _tempsPause += tempsPause;
    }
}
