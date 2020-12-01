using System.Collections;
using Moon.UI;
using UnityEngine;

namespace Moon.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] ScoreDisplay scoreDisplay;
        int totalScore = 0;
        int counterValue = 0;
        int scoreCounterIncrement = 1;

        private void Awake()
        {
            SetUpSingleton();
        }

        private void SetUpSingleton()
        {
            int numberOfScoreManagers = FindObjectsOfType<ScoreManager>().Length;
            if (numberOfScoreManagers > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public void AddScore(int score)
        {
            totalScore += score;
            StartCoroutine(CountScoreRoutine());
        }

        IEnumerator CountScoreRoutine()
        {
            int iterations = 0;

            while (counterValue < totalScore && iterations < 100000)
            {
                counterValue += scoreCounterIncrement;
                scoreDisplay.UpdateScoreDisplay(counterValue);
                iterations++;
                yield return null;
            }

            counterValue = totalScore;
            scoreDisplay.UpdateScoreDisplay(totalScore);
        }

        public void ResetScore()
        {
            totalScore = 0;
            scoreDisplay.UpdateScoreDisplay(totalScore);
        }
    }
}
