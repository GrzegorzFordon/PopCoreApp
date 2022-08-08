using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pullthepin
{
    public class PullThePinManager : MonoBehaviour
    {
        public Pin activePin;

        void Update()
        {
            CheckForNewPin();
            UpdateActivePinPosition();
        }

        void CheckForNewPin()
        {
            if (Inputs.pointerPress)
            {
                Ray ray = Inputs.main.mainCam.ScreenPointToRay(Inputs.pointerPos);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag != "Pin") return;
                    if (hit.transform.GetComponentInParent<Pin>() == activePin) return;
                    if (activePin != null) activePin.SetActive(false);
                    activePin = hit.transform.GetComponentInParent<Pin>();
                    activePin.SetActive(true);
                }
            }
            else
            {
                if (activePin != null) activePin.SetActive(false);
                activePin = null;
            }
        }

        void UpdateActivePinPosition()
        {
            if (activePin == null) return;
            if (activePin.isBusy) return;

            float moveMult = Vector3.Dot(activePin.transform.right, Inputs.pointerDelta) * Time.deltaTime;
            Vector3 goalVec = activePin.transform.position + activePin.transform.right * moveMult;
            float dist = Vector3.Distance(goalVec, activePin.startingPos - activePin.transform.right * activePin.distTreshhold);
            if (dist > activePin.distTreshhold) return;
            activePin.transform.position = goalVec;
        }
    }
}