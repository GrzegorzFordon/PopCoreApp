using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace pullthepin
{
    public class Level : MonoBehaviour
    {
        public static Level instance;
        public GameObject winlosePanel;
        public TextMeshProUGUI winloseText;

        private void Awake()
        {
            instance = this;
        }
        public void WinLevel()
        {
            winlosePanel.SetActive(true);
            winloseText.text = "You Won!";
        }

        public void LoseLevel()
        {
            winlosePanel.SetActive(true);
            winloseText.text = "So Close!";

        }
    }
}