using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingActivation : MonoBehaviour
{


    private InteractiveObject interactiveObj;
    private void Start()
    {
        interactiveObj = GetComponent<InteractiveObject>();
    }

    private void OnMouseEnter()
    {
        if (interactiveObj.IsInteractive)
            interactiveObj.CreateActivationPanel();
    }

    private void OnMouseExit()
    {
        if (interactiveObj.IsInteractive)
            interactiveObj.DeleteActivationPanel();
    }

    /*private Camera camera;

    private void Start()
    {

        camera = Camera.main;
    }
    private void FixedUpdate()
    {
        if (interactiveObj.IsInteractive)
        {
            Vector3 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Ray ray = camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider.gameObject == this.gameObject))
                    interactiveObj.CreateActivationPanel();
                else
                    interactiveObj.DeleteActivationPanel();
            }
        }
    }*/
}
