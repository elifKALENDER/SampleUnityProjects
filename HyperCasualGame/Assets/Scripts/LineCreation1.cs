using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class LineCreation1 : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject drawingPrefab;
    public Material material;
    private Color randomColor;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool goRight = true; // �lk olarak sa�a gitsin
    void Start() {
        startPoint = new Vector3(Screen.width * 0.1f, Screen.height * 0.1f, 0f); // Ekran�n sol alt k��esinden ba�layal�m
        endPoint = startPoint;
        InvokeRepeating("AutoDraw", 0f, 1f); // Her saniyede bir AutoDraw metodu �a�r�l�r
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
        if(Input.GetMouseButton(0))// burada GetMouseButtonUp kulland�m aynl���kla ve t�m �izgiler ayn� orjinden ��kt�
        {
            FreeDraw();
        }
    }

    private void FreeDraw() {
        //Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos); // Ekran koordinatlar�n� d�nya koordinatlar�na d�n��t�r
        ////mousePos.z = 0f; // Z ekseni sabit oldu�u i�in s�f�rla
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

    private void AutoDraw() {
        float randomY = Random.Range(Screen.height * 0.1f, Screen.height * 0.9f); // Ekran�n y�ksekli�inde rastgele bir y�kseklik se�ilir

        if (goRight) // E�er sa�a gidiyorsak
        {
            endPoint.x += Screen.width * 0.2f; // X koordinat�n� sa�a do�ru kayd�r
        }
        else // E�er sola gidiyorsak
        {
            endPoint.x -= Screen.width * 0.2f; // X koordinat�n� sola do�ru kayd�r
        }

        endPoint.y = randomY; // Y koordinat�n� rastgele y�kseklikte tut

        startPoint = endPoint; // Ba�lang�� noktas�n� son biti� noktas� olarak g�ncelle

        goRight = !goRight; // Y�n� tersine �evir (sa�sa sola, sola sa�a)

        GameObject drawing = Instantiate(drawingPrefab);
        lineRenderer = drawing.GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
        Randomize();
        lineRenderer.startColor = randomColor;
        lineRenderer.endColor = randomColor;

        lineRenderer.positionCount = 2; // Ba�lang�� ve biti� noktalar� i�in iki nokta olmal�
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
