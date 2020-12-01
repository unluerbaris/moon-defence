using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Moon.Movement
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] float scrollSpeed = 0.02f;
        Material myMaterial;
        Vector2 offset;

        void Start()
        {
            myMaterial = GetComponent<Renderer>().material;
            offset = new Vector2(scrollSpeed, 0f);
        }

        void Update()
        {
            myMaterial.mainTextureOffset += offset * Time.deltaTime;
        }
    }
}
