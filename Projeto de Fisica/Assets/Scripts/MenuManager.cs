using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public LevelLoader levelLoader;

    [Serializable] private GameObject principal;
    [Serializable] private GameObject opcoes;
    [Serializable] private GameObject level;

    void Jogar(){
        principal.setActive(false);
        opcoes.setActive(false);
        level.setActive(true);
    }

    void Sair(){
        Application.Quit();
    }

    void Opcoes(){
        principal.setActive(false);
        opcoes.setActive(true);
        level.setActive(false);
    }

    void Voltar(){
        principal.setActive(true);
        opcoes.setActive(false);
        level.setActive(false);
    }

    void Level(int level){
        levelLoader.LoadNextLevel(level);
    }


}
