using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject[] texObj;
    [SerializeField] private GameObject trueObj, badObj,thanksObj;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float spawnInterval = 1f; // �X�|�[���Ԋu

    [SerializeField] private FadeManager fadeManager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < texObj.Length; i++)
        {
            texObj[i].SetActive(false);
        }
        trueObj.SetActive(false);
        badObj.SetActive(false);
        thanksObj.SetActive(false);
    }

    public IEnumerator EndRoll(bool isBad)
    {
        for (int i = 0; i < texObj.Length; i++)
        {
            GameObject obj = texObj[i];

            // �I�u�W�F�N�g���A�N�e�B�u����A�N�e�B�u�ɂ���
            obj.SetActive(true);

            // Rigidbody���A�^�b�`����Ă��Ȃ��ꍇ�̓A�^�b�`����
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = obj.AddComponent<Rigidbody>();
            }

            // Rigidbody�̐ݒ�
            rb.velocity = Vector3.zero; // �������x���[���ɐݒ�
            rb.angularVelocity = Vector3.zero; // ������]���x���[���ɐݒ�

            // �X�|�[���ʒu�ɃI�u�W�F�N�g��z�u
            obj.transform.position = spawnPos.position;

            // ������ɃX�N���[��������
            rb.velocity = new Vector3(0, scrollSpeed, 0);

            // �X�|�[���Ԋu�̑ҋ@
            yield return new WaitForSeconds(spawnInterval);
        }
        yield return new WaitForSeconds(spawnInterval);
        if (isBad)
        {
            badObj.SetActive(true);
            Rigidbody rb = badObj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = badObj.AddComponent<Rigidbody>();
            }            
            // Rigidbody�̐ݒ�
            rb.velocity = Vector3.zero; // �������x���[���ɐݒ�
            rb.angularVelocity = Vector3.zero; // ������]���x���[���ɐݒ�
                                               // �X�|�[���ʒu�ɃI�u�W�F�N�g��z�u
            badObj.transform.position = spawnPos.position;

            // ������ɃX�N���[��������
            rb.velocity = new Vector3(0, scrollSpeed, 0);

            yield return new WaitForSeconds(spawnInterval + 1f);
            thanksObj.SetActive(true);
            rb=thanksObj.GetComponent<Rigidbody>();
            // Rigidbody�̐ݒ�
            rb.velocity = Vector3.zero; // �������x���[���ɐݒ�
            rb.angularVelocity = Vector3.zero; // ������]���x���[���ɐݒ�
                                               // �X�|�[���ʒu�ɃI�u�W�F�N�g��z�u
            thanksObj.transform.position = spawnPos.position;

            // ������ɃX�N���[��������
            rb.velocity = new Vector3(0, scrollSpeed, 0);
        }
        else
        {
            trueObj.SetActive(true);
            Rigidbody rb = trueObj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = trueObj.AddComponent<Rigidbody>();
            }
            // Rigidbody�̐ݒ�
            rb.velocity = Vector3.zero; // �������x���[���ɐݒ�
            rb.angularVelocity = Vector3.zero; // ������]���x���[���ɐݒ�
                                               // �X�|�[���ʒu�ɃI�u�W�F�N�g��z�u
            trueObj.transform.position = spawnPos.position;

            // ������ɃX�N���[��������
            rb.velocity = new Vector3(0, scrollSpeed, 0);
            yield return new WaitForSeconds(spawnInterval+1f);
            thanksObj.SetActive(true);
            rb = thanksObj.GetComponent<Rigidbody>();
            // Rigidbody�̐ݒ�
            rb.velocity = Vector3.zero; // �������x���[���ɐݒ�
            rb.angularVelocity = Vector3.zero; // ������]���x���[���ɐݒ�
                                               // �X�|�[���ʒu�ɃI�u�W�F�N�g��z�u
            thanksObj.transform.position = spawnPos.position;

            // ������ɃX�N���[��������
            rb.velocity = new Vector3(0, scrollSpeed, 0);
        }
        // ���ׂẴI�u�W�F�N�g���X�|�[����������A�K�v�ɉ����ď������I������
        Debug.Log("All objects have been spawned and are scrolling.");
        yield return new WaitForSeconds(4f);
        fadeManager.StartCoroutine(fadeManager.FadeIn(2f));
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
