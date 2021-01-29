using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject levelCompleteUI;

    private List<GameObject> enemies;

    void Awake()
    {
        MakeInstance();

        enemies = new List<GameObject>();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void Update()
    {
        foreach (GameObject enemy in enemies.ToArray())
        {
            if (enemy.GetComponent<EnemyData>().Killed)
            {
                enemies.Remove(enemy);
            }
        }

        if (enemies.Count == 0 && !GameManager.instance.GameIsLost)
        {
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        levelCompleteUI.SetActive(true);
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
