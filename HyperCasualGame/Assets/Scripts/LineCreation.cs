using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class LineCreation : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    public Material material;
    private Color randomColor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject drawing= Instantiate(drawingPrefab);
            lineRenderer = drawing.GetComponent<LineRenderer>();
            //lineRenderer.positionCount = 0;
            lineRenderer.startWidth = 0.15f;
            lineRenderer.endWidth = 0.15f;
            Randomize();
            lineRenderer.startColor = randomColor;
            lineRenderer.endColor = randomColor;   
        }
        if(Input.GetMouseButton(0))// burada GetMouseButtonUp kullandým aynlýþýkla ve tüm çizgiler ayný orjinden çýktý
        {
            FreeDraw();
        }
    }

    private void FreeDraw() {
        //Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos); // Ekran koordinatlarýný dünya koordinatlarýna dönüþtür
        ////mousePos.z = 0f; // Z ekseni sabit olduðu için sýfýrla
        //lineRenderer.positionCount++;
        //lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePos);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, Camera.main.ScreenToWorldPoint(mousePos));
    }

    void Randomize() 
    {
        int randomInt = Random.Range(0, 5);
        
        switch(randomInt)
        {
            case 4:
                material.SetFloat("_width", 0.5f);
                material.SetFloat("_heigth", 0.1f);
                randomColor = Color.yellow;
                break;
            case 3:
                material.SetFloat("_width", 0.5f);
                material.SetFloat("_heigth", 1f);
                randomColor = Color.cyan;
                break;
            case 2:
                material.SetFloat("_width", 0.75f);
                material.SetFloat("_heigth", 0.1f);
                randomColor = Color.green;
                break;
            case 1:
                material.SetFloat("_width", 0.4f);
                material.SetFloat("_heigth", 0.8f);
                randomColor = Color.red;
                break;

        }
    }
}
