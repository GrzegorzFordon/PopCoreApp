using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace pullthepin
{
    public class Bucket : MonoBehaviour
    {
        float ballsInBucketAmount = 0;

        public TextMeshProUGUI fillPercentageText;

        private void Start()
        {
            // UpdateText();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Ball") return;

            if (!other.GetComponent<Ball>().isColoredIn)
            {
                Level.instance.LoseLevel();
                return;
            }

            ballsInBucketAmount++;
            if (ballsInBucketAmount == BallSpawner.instance.activeBallsAmount) Level.instance.WinLevel();

            UpdateText();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag != "Ball") return;
            ballsInBucketAmount--;
            UpdateText();
        }

        private void UpdateText()
        {
            float percentage = (ballsInBucketAmount / BallSpawner.instance.activeBallsAmount) * 100;
            fillPercentageText.text = percentage.ToString("#00") + "%";
        }
    }
}