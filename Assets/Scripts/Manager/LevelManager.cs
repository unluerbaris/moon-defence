using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Moon.Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] float loadSceneDelay = 2f;
        int numberOfEnemies = 0;

        public void EnemySpawned()
        {
            numberOfEnemies++;
        }

        public void EnemyDestroyed()
        {
            numberOfEnemies--;
        }

        public int GetNumberOfEnemies()
        {
            return numberOfEnemies;
        }

        public void LoadStartMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(1);
            if (FindObjectOfType<ScoreManager>() != null)
            {
                FindObjectOfType<ScoreManager>().ResetScore();
            }
        }

        public void LoadGameOver()
        {
            StartCoroutine(WaitAndLoadScene("GameOver")); 
        }

        public void LoadWinMenu()
        {
            StartCoroutine(WaitAndLoadScene("WinMenu"));
        }

        IEnumerator WaitAndLoadScene(string sceneName)
        {
            yield return new WaitForSeconds(loadSceneDelay);
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
