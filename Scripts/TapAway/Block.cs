using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace tapaway
{
    public class Block : MonoBehaviour
    {

        bool isBusy;

        public void CheckForClearPath()
        {
            if (isBusy) return;

            isBusy = true;
            Ray ray = new Ray(transform.position, transform.up * 100);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Block") StartCoroutine(Wiggle());
                else if (hit.transform.tag == "Border") StartCoroutine(FloatAway());
            }

        }

        IEnumerator Wiggle()
        {
            Tween wiggleTween = transform.DOShakeRotation(0.2f, 30);
            yield return wiggleTween.WaitForCompletion();
            isBusy = false;
        }

        IEnumerator FloatAway()
        {
            isBusy = true;
            GetComponentInChildren<BoxCollider>().enabled = false;
            Tween moveTween = transform.DOMove(transform.position + transform.up * 100, 3);
            yield return moveTween.WaitForCompletion();
            // float timer = 3;
            // while (timer > 0)
            // {
            //     transform.position += transform.up * 20 * Time.deltaTime;
            //     timer -= Time.deltaTime;
            //     yield return new WaitForEndOfFrame();
            // }
            Destroy(gameObject);
        }

    }
}
