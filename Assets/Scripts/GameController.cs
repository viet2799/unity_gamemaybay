using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameover;

    UiManager m_ui;
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UiManager>();
        m_ui.SetScoreText("Score : " + m_score);
    }

    // Update is called once per frame
    void Update()
    {


        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void SpawnEnemy()
    {
        float ranXpos = Random.Range(-11, 11);
        Vector2 spawnPos = new Vector2(ranXpos, 6);
        if (enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public float GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        if (m_isGameover)
            return;

        m_score++;
        m_ui.SetScoreText("Score : " +m_score);
    }
    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
}
