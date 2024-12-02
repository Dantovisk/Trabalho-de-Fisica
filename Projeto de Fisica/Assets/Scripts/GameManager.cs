using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TMP_Text texto;
    public int alvos = 0;
    [SerializeField] public int alvosTotais;
    // Start is called before the first frame update
    void Start()
    {
        printarAlvos();
    }

    public int getAlvos()
    {
        return alvos;
    }

    public void aumentarAlvos()
    {
        alvos++;
        printarAlvos();
        if (alvos == alvosTotais)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void printarAlvos()
    {
        texto.text = "Alvos: " + alvos + "/" + alvosTotais;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
