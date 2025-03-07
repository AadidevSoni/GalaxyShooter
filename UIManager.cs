using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private int _playerScore;

    [SerializeField]
    private Sprite[] _livesSprites;

    [SerializeField]
    private Image _livesImg;

    [SerializeField]
    private TextMeshProUGUI _gameOver;

    [SerializeField]
    private TextMeshProUGUI _restartText;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {   
        _scoreText.text = "Score: " + 0;
        _gameOver.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(_gameManager == null){
            Debug.LogError("Game Manager is null");
        }
    }

    public void UpdateScore(int playerScore)
    {   
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives){
        _livesImg.sprite = _livesSprites[currentLives];

        if(currentLives == 0){
            gameOverSequence();
        }
    }

    void gameOverSequence(){
        _gameOver.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        _gameManager.GameOver();
        StartCoroutine(gameOverRoutine());
    }

    IEnumerator gameOverRoutine(){
        while(true){
            _gameOver.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOver.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}