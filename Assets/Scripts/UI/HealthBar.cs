using UnityEngine;

namespace Moon.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] GameObject bar;

        // scale the health bar between 0 and 1 
        public void UpdateHealthBar(float currentHealth, float startHealth)
        {
            float scaleValue = Mathf.Clamp01(currentHealth / startHealth);
            bar.transform.localScale = new Vector2(scaleValue,
                                                   bar.transform.localScale.y);
        }
    }
}
