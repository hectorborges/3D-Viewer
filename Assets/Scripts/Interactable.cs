using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static bool interacting;
    public Texture2D openHand;
    public Texture2D closedHand;
    public Texture2D interactHand;

    bool leftClick;
    bool rightClick;

    private void Update()
    {
        leftClick = Input.GetMouseButton(0);
        rightClick = Input.GetMouseButton(1);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag.Equals("Interactable"))
            {
                interacting = true;
                Cursor.SetCursor(interactHand, Vector2.zero, CursorMode.Auto);
                if (Input.GetMouseButtonDown(0))
                {
                    Animator animator = hit.transform.GetComponent<Animator>();
                    if (animator)
                    {
                        animator.SetBool("Open", !animator.GetBool("Open"));
                    }
                }
            }
            else
            {
                interacting = false;
            }
        }
        else
        {
            interacting = false;
        }

        if (!interacting)
        {
            if (!leftClick && !rightClick)
                Cursor.SetCursor(openHand, Vector2.zero, CursorMode.Auto);
            else if(leftClick || rightClick)
                Cursor.SetCursor(closedHand, Vector2.zero, CursorMode.Auto);
        }
    }
}

