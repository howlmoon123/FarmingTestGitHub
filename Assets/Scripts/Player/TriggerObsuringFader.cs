using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObsuringFader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
       
            ObscuringItemFader[] obscuringItems = target.gameObject.GetComponentsInChildren<ObscuringItemFader>();
            if(obscuringItems.Length > 0)
            {
                for (int i = 0; i < obscuringItems.Length; i++)
                {
                    obscuringItems[i].FadeOut();
                }
            }
        
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        
            ObscuringItemFader[] obscuringItems = target.gameObject.GetComponentsInChildren<ObscuringItemFader>();
            if (obscuringItems.Length > 0)
            {
                for (int i = 0; i < obscuringItems.Length; i++)
                {
                    obscuringItems[i].FadeIn();
                }
            }
       
    }
}
