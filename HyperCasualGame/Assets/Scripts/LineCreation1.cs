using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineCreation1 : MonoBehaviour {
    public GameObject drawingPrefab;
    public Material material;
    public int numberOfZigzags = 100; // Olu�turulacak zigzag say�s�
    public float drawSpeed = 0.05f; // �izim h�z�
    public float zigzagWidth = 1f; // Zigzag geni�li�i
    public float zigzagPeak = 1f; // Zigzag y�ksekli�i
    public float angle = 30f; // Zigzag a��s�
    public int maxPoints = 20000; // Zigzag�n duraca�� maksimum nokta say�s�
    //public RectTransform panelRectTransform;

    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    void Start() {
        for (int i = 0; i < numberOfZigzags; i++)
        {
            StartCoroutine(CreateZigzagLine(i));
        }
    }

    IEnumerator CreateZigzagLine(int index) {
        GameObject drawing = Instantiate(drawingPrefab);
        LineRenderer lineRenderer = drawing.GetComponent<LineRenderer>();
        lineRenderer.material = material;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.positionCount = 0;

        // Ekran�n d���ndan ba�lamas� i�in rastgele bir ba�lang�� noktas� se�
        float extraOffset = 10f; // Ekran s�n�rlar�n�n d���na ��kmak i�in ekstra mesafe
        float extraOffset1 = 100f; // Ekran s�n�rlar�n�n d���na ��kmak i�in ekstra mesafe
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector3 startPoint = new Vector3(
            Random.Range(-screenBounds.x - extraOffset, screenBounds.x + extraOffset),
            Random.Range(-screenBounds.y - extraOffset, screenBounds.y + extraOffset),
            0f
        );

        // A��y� radyana �evir
        float radianAngle = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle), 0f);

        int pointCount = 0;
        while (pointCount < maxPoints)
        {
            lineRenderer.positionCount++;
            float x = startPoint.x + (pointCount * zigzagWidth * direction.x);
            float y = startPoint.y + ((pointCount % 2 == 0) ? 0f : zigzagPeak * direction.y);
            Vector3 nextPoint = new Vector3(x, y, 0f);
            lineRenderer.SetPosition(pointCount, nextPoint);
            pointCount++;
            yield return new WaitForSeconds(drawSpeed); // Belirli bir h�zda �iz
        }
    }


}
