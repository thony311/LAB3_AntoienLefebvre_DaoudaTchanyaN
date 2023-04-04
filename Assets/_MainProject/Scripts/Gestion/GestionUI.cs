using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionUI : MonoBehaviour
{
    [SerializeField] GameObject instruction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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