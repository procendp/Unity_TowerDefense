using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//보통 MonoBehaviour를 상속한 클래스를 오브젝트에 컴포넌트로 등록 시키면
//그 클래스 안의 공개변수가 인스펙터에 실시간으로 반영 되어 GUI를 통해 할당이 가능해진다.
//하지만 C#으로 할 경우 [System.Serializable]를 해줘야 MonoBehaviour를 타고 인스펙터에 표시된다.
public class TurretBluePrint
{
    public GameObject prefab;
    public int cost;
}
