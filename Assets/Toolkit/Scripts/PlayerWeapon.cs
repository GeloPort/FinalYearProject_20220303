using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public ToolGenerator TGen;
    public GameObject newWeapon;
    public GameObject weaponHand;
    public GameObject iHandle;
    public GameObject iHead;
    public ToolHandle toolHandle;

    // Start is called before the first frame update
    void Start()
    {
        newWeapon = Instantiate(TGen.newWeaponPrefab, Vector3.up, weaponHand.transform.rotation, weaponHand.transform);
        iHandle = Instantiate(TGen.handleParts[TGen.arrayPosHandle], Vector3.zero, Quaternion.identity, newWeapon.transform);
        toolHandle = iHandle.GetComponent<ToolHandle>();
        iHead = Instantiate(TGen.headParts[TGen.arrayPosHead], toolHandle.headConnection.position, weaponHand.transform.rotation, newWeapon.transform);
        //iHead = Instantiate(TGen.headParts[TGen.arrayPosHead], toolHandle.headConnection.position, TGen.headParts[TGen.arrayPosHead].transform.rotation, newWeapon.transform);

        newWeapon.transform.position = weaponHand.transform.position;
        newWeapon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
