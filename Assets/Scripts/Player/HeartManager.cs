using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public MainCharacter2 characterController;
    public Sprite[] hearts;
    public Image image;

    void Start()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter2>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = hearts[characterController.hearts];
    }
}
