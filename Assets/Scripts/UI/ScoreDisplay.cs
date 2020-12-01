using System.Collections;
using System.Collections.Generic;
using Moon.Manager;
using TMPro;
using UnityEngine;

namespace Moon.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        TextMeshProUGUI scoreText;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        public void UpdateScoreDisplay(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
