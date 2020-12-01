﻿using UnityEngine;

namespace Moon.Manager
{
    public class TargetFPS : MonoBehaviour
    {
        void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }
}
