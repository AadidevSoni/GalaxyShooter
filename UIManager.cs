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

    // Start is called before the first frame update
    void Start()
    {   
        _scoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {   
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives){
        _livesImg.sprite = _livesSprites[currentLives];
    }
}