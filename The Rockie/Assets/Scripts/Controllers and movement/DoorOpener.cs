using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] GameObject _key;
    void Start()
    {

    }

    void Update()
    {
        if (!_key.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
