using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Classe responsável por gerenciar a gameplay
public class GameManager : MonoBehaviour
{
    
    public LevelLoader levelLoader;
	[SerializeField] public TMP_Text texto;
    public int alvos = 0;
    [SerializeField] public int alvosTotais;
    

    void Start()
    {
        printarAlvos();
    }

    public int getAlvos()
    {
        return alvos;
    }

    // Função que atualiza a pontuação
    public void aumentarAlvos()
    {
        alvos++;
        printarAlvos();

        Debug.Log("Acertou um alvo!");

        if (alvos == alvosTotais && SceneManager.GetActiveScene().buildIndex != 6)
            levelLoader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        if (SceneManager.GetActiveScene().buildIndex == 6 && alvos == alvosTotais)
        {
            Debug.Log("Voc� venceu!");
			levelLoader.LoadNextLevel(7);
        }
            
    }

    public void printarAlvos()
    {
        texto.text = "Alvos: " + alvos + "/" + alvosTotais;
    }
}
