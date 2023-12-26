using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class CollectibleTextDisplay : MonoBehaviour
{

    [HideInInspector] GameObject _textBox;
    private TMP_Text _text;

    public CollectionController CollectionScript;
    public KeyCode PressKey;
    void Start()
    {
        _textBox = gameObject.transform.GetChild(0).gameObject;
        _textBox.SetActive(false);
        PressKey = CollectionScript.KeyToPress;
        _text = _textBox.GetComponent<TMP_Text>();
        _text.text = "Press " + PressKey;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            _textBox.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            _textBox.SetActive(false);
        }
    }
}
