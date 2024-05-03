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
    private bool goRight = true; // Ýlk olarak saða gitsin
    void Start() {
        startPoint = new Vector3(Screen.width * 0.1f, Screen.height * 0.1f, 0f); // Ekranýn sol alt köþesinden baþlayalým
        endPoint = startPoint;
        InvokeRepeating("AutoDraw", 0f, 1f); // Her saniyede bir AutoDraw metodu çaðrýlýr
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

    private void AutoDraw() {
        float randomY = Random.Range(Screen.height * 0.1f, Screen.height * 0.9f); // Ekranýn yüksekliðinde rastgele bir yükseklik seçilir

        if (goRight) // Eðer saða gidiyorsak
        {
            endPoint.x += Screen.width * 0.2f; // X koordinatýný saða doðru kaydýr
        }
        else // Eðer sola gidiyorsak
        {
            endPoint.x -= Screen.width * 0.2f; // X koordinatýný sola doðru kaydýr
        }

        endPoint.y = randomY; // Y koordinatýný rastgele yükseklikte tut

        startPoint = endPoint; // Baþlangýç noktasýný son bitiþ noktasý olarak güncelle

        goRight = !goRight; // Yönü tersine çevir (saðsa sola, sola saða)

        GameObject drawing = Instantiate(drawingPrefab);
        lineRenderer = drawing.GetComponent<LineRenderer>();

        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
        Randomize();
        lineRenderer.startColor = randomColor;
        lineRenderer.endColor = randomColor;

        lineRenderer.positionCount = 2; // Baþlangýç ve bitiþ noktalarý için iki nokta olmalý
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
