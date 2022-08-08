using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tapaway
{

    public class TapManager : MonoBehaviour
    {
        public static TapManager instance;
        public bool isBusy;
        public float cdTimer;

        private void Awake()
        {
            instance = this;
        }

        void Update()
        {
            if (Inputs.pointerPress && !isBusy)
            {
                Ray ray = Inputs.main.mainCam.ScreenPointToRay(Inputs.pointerPos);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag != "Block") return;

                    hit.transform.GetComponentInParent<Block>().CheckForClearPath();
                    StartCoroutine(CoolDownCO());
                }
            }
        }

        IEnumerator CoolDownCO()
        {
            isBusy = true;
            yield return new WaitForSeconds(cdTimer);
            isBusy = false;
        }
    }
}