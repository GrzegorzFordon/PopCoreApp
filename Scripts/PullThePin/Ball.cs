using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pullthepin
{
    public class Ball : MonoBehaviour
    {


        public bool isColoredIn;
        public MeshRenderer mr;
        public float padding;
        private void Start()
        {
            BallSpawner.instance.activeBallsAmount++;
            if (isColoredIn) ColorIn();
        }

        public void ColorIn()
        {
            isColoredIn = true;
            mr.material.color = BallSpawner.ballColors[Random.Range(0, BallSpawner.ballColors.Length)];
            Collider[] neighbours = Physics.OverlapSphere(transform.position, mr.bounds.size.x + padding);
            foreach (Collider collider in neighbours)
            {
                if (collider.tag != "Ball") return;
                Ball otherBall = collider.GetComponentInParent<Ball>();
                if (!otherBall.isColoredIn) otherBall.ColorIn();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag != "Ball") return;

            Ball otherBall = other.transform.GetComponentInParent<Ball>();
            if (isColoredIn && !otherBall.isColoredIn) otherBall.ColorIn();
            if (otherBall.isColoredIn && !isColoredIn) ColorIn();
        }

        // private void OnCollisionExit(Collision other)
        // {
        //     if (other.transform.tag != "Ball") return;
        // }

        public Ball(bool _isColoredIn)
        {
            isColoredIn = _isColoredIn;
        }


    }
}
