using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    private bool _isGameOver;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver == true){
            SceneManager.LoadScene(1); //integer in the build scene manager
        }
    }

    public void GameOver(){
        _isGameOver = true;
    }
    
}