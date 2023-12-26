using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    [HideInInspector] private GameObject _currentCollectible;
    [SerializeField] private bool _isInTrigger;
    [SerializeField] public KeyCode KeyToPress = KeyCode.E;
    void Start()
    {
        _currentCollectible = null;
        _isInTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPressedButton();
    }
    private void CheckPressedButton()
    {
        if (Input.GetKeyDown(KeyToPress) && _isInTrigger == true)
        {
            Debug.Log("E is pressed");
            _currentCollectible.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Collectible detected");
            _currentCollectible = other.gameObject;
            _isInTrigger = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Collectible exit detected");
            _currentCollectible = null;
            _isInTrigger = false;
        }
    }
}

