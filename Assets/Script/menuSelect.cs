using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSelect : MonoBehaviour
{
    [SerializeField] RectTransform[] charbtn;
    [SerializeField] RectTransform pointer;
    [SerializeField] float moveDelay;

    int pointerPos;
    float moveTimer;

    void Update()
    {

        if(moveTimer < moveDelay)
        {
            moveTimer += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(moveTimer >= moveDelay)
            {
                if(pointerPos < charbtn.Length - 1)
                {
                    pointerPos++;
                }
                else
                {
                    pointerPos = 0;
                }
                moveTimer = 0;
            }
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (moveTimer >= moveDelay)
            {
                if (pointerPos > 0)
                {
                    pointerPos--;
                }
                else
                {
                    pointerPos = charbtn.Length - 1;
                }
                moveTimer = 0;
            }
        }
        pointer.localPosition = charbtn[pointerPos].localPosition;

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("menu " + (pointerPos + 1));
        }
    }

    public void HoverButton(int btnPos)
    {
        pointerPos = btnPos;
    }

    public void ButtonPress()
    {
        Debug.Log("menu " + (pointerPos + 1));
    }
}
