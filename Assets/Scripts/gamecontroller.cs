using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{
    public int totalScore;
    public static gamecontroller instance; 
    public Text scoreText;
    public GameObject gameOver;

    void Start()
    {
        instance = this; // atribui a variavel o proprio script, pra poder acessar de outro script tudo que nao seja private
    }

    public void updateScoreText(){
        scoreText.text = totalScore.ToString(); // toString() é pra converter o numero int da variavel total score pra uma string
    }

    public void showGameOver(){
        gameOver.SetActive(true);

    }

    public void restartGame(string lvlName){
        SceneManager.LoadScene(lvlName);
    }

}
