using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public TextMeshProUGUI scoreText;
    private Animator anim;
    public AudioClip scored;
    private int score = 0;
    private AudioSource audio;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
        audio = GetComponent<AudioSource>();
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score: " + score.ToString ();
        PlaySound(scored);
    }

    private void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
