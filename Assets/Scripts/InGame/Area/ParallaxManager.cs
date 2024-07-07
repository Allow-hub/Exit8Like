using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] private float parallaxStrength = 0.1f; // パララックスの強さ
    private Transform[] childObjects; // 子オブジェクトの配列
    private Vector3[] startPositions; // 各オブジェクトの初期位置
    private Transform cam; // カメラのTransform

    void Start()
    {
        cam = Camera.main.transform;
        int childCount = transform.childCount;
        childObjects = new Transform[childCount];
        startPositions = new Vector3[childCount];

        // 子オブジェクトを配列に格納し、それぞれの初期位置を保存
        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i);
            startPositions[i] = childObjects[i].position;
        }
    }

    void Update()
    {
        for (int i = 0; i < childObjects.Length; i++)
        {
            float parallax = (cam.position.x * (1 - parallaxStrength));
            float distance = (cam.position.x * parallaxStrength);
            childObjects[i].position = new Vector3(startPositions[i].x + distance, childObjects[i].position.y, childObjects[i].position.z);
        }
    }
}
