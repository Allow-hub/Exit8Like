using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] private float parallaxStrength = 0.1f; // �p�����b�N�X�̋���
    private Transform[] childObjects; // �q�I�u�W�F�N�g�̔z��
    private Vector3[] startPositions; // �e�I�u�W�F�N�g�̏����ʒu
    private Transform cam; // �J������Transform

    void Start()
    {
        cam = Camera.main.transform;
        int childCount = transform.childCount;
        childObjects = new Transform[childCount];
        startPositions = new Vector3[childCount];

        // �q�I�u�W�F�N�g��z��Ɋi�[���A���ꂼ��̏����ʒu��ۑ�
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
