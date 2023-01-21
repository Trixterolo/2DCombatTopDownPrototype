using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class HealthText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    public string textToDisplay;

    RectTransform rTransform;
    Color startingColor;

    [SerializeField] float timeToLive = 0.5f;
    private float timeElapsed = 0.0f;

    private Vector3 floatDirection = new Vector3(0, 1, 0);
    [SerializeField] float floatSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        //textMesh = GetComponent<TextMeshProUGUI>();
        rTransform = GetComponent<RectTransform>();
        startingColor= textMesh.color;
    }   

    // Update is called once per frame
    void Update()
    {
        //time elapsed increase over time
        timeElapsed += Time.deltaTime;

        //go rect transform float upwards y axis over time.
        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        //color fading over time
        textMesh.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));

        //what to display on screen. Bad practice because it keeps updating.
        textMesh.SetText(textToDisplay);


        //time it takes to remove the Text GO.
        if (timeElapsed > timeToLive)
        {
            Destroy(gameObject);
        }
    }

}
