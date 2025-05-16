using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera arCamera;
    public GameObject smokeEffect;
    public GameManager gameManager;

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            // ��Ǩ�ͺ��� hit �Ѻ GameObject ����� Tag "Bottle" �������
            if (hit.transform.CompareTag("Bottle"))
            {
                // �֧ʤ�Ի�� Bottle �ҡ object ��� (�����)
                Bottle bottle = hit.transform.GetComponent<Bottle>();

                // ����¢Ǵ
                Destroy(hit.transform.gameObject);

                // ���ҧ��ѹ�ç���˹�ⴹ�ԧ
                Instantiate(smokeEffect, hit.point, Quaternion.LookRotation(hit.normal));

                // ������� �����ʤ�Ի�� Bottle ����
                if (bottle != null && gameManager != null)
                {
                    gameManager.AddScore(bottle.pointValue);
                }
            }
        }
    }
}
