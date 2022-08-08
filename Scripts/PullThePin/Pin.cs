using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pullthepin
{
    public class Pin : MonoBehaviour
    {
        public float moveMult;
        public Vector3 startingPos;
        public float distTreshhold;
        public float padding;
        public bool isBusy;
        bool isActive;
        public ParticleSystem ps;

        private void Start()
        {
            startingPos = transform.position;
        }
        void Update()
        {
            if (isBusy) return;

            float distToGoal = Vector3.Distance(transform.position, startingPos);
            if (distToGoal >= distTreshhold)
            {
                StartCoroutine(FloatAway());
            }
        }

        IEnumerator FloatAway()
        {
            isBusy = true;
            Vector3 dir = (transform.position - startingPos).normalized;
            while (Vector3.Distance(startingPos, transform.position) < 5)
            {
                transform.position -= transform.right * 20 * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            Destroy(gameObject);
        }

        IEnumerator FloatBack()
        {
            while (Vector3.Distance(transform.position, startingPos) > 0.2f)
            {
                transform.position = Vector3.Lerp(transform.position, startingPos, 0.2f);
                yield return new WaitForEndOfFrame();
            }

            transform.position = startingPos;
            isBusy = false;
        }

        public void SetActive(bool active)
        {
            isActive = active;

            if (active)
            {
                ps.Play();
            }
            if (!active)
            {
                ps.Clear();
                ps.Stop();
                StopAllCoroutines();
                StartCoroutine(FloatBack());
            }
        }

    }
}