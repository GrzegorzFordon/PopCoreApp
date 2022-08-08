using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pullthepin
{
    public class BallSpawner : MonoBehaviour
    {
        public static BallSpawner instance;
        public GameObject ball;
        public float delay;
        public float activeBallsAmount;
        public int spawnAmount;

        public bool spawnColoredIn;

        public static Color[] ballColors = {
    new Color(0.15f, 0.67f, 0.88f), new Color(1, 0.4f, 0.37f),
    new Color(1, 0.54f, 0.22f), new Color(0.98f, 0.93f, 0.2f),
    new Color(0.39f, 0.75f, 0.16f), new Color(0.43f, 0.32f, 0.96f) };

        private void Awake()
        {
            instance = this;
            activeBallsAmount = 0;
            // StartCoroutine(SpawnBall());
        }

        [ContextMenu("spawn balls")]
        public void SpawnBalls()
        {
            StartCoroutine(SpawnBallsCO());
        }
        IEnumerator SpawnBallsCO()
        {
            GameObject ballParent = new GameObject();
            int counter = 0;
            while (counter < spawnAmount)
            {
                GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);
                if (spawnColoredIn) newBall.GetComponent<Ball>().ColorIn();
                newBall.transform.SetParent(ballParent.transform);
                yield return new WaitForSeconds(delay);
                counter++;
            }
        }
    }
}
