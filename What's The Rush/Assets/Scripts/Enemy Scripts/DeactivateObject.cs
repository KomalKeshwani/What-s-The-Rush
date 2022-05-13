using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    [SerializeField]
    private float deactiveTimer = 2f;

    private void OnEnable()
    {
        Invoke("DeactivateGameObject", deactiveTimer);
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateGameObject");
    }

    void DeactivateGameObject()
    {
       if(gameObject.activeInHierarchy)
        {
            CancelInvoke("DeactivateGameObject");
            gameObject.SetActive(false);

            
        }
    }
}
