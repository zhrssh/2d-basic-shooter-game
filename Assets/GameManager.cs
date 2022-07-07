using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCount;
    private int kills = 0;

    private void Start()
    {
        kills = 0;
    }

    private void Update()
    {
        killCount.text = "Kills: " + kills;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore()
    {
        kills++;
    }
}
