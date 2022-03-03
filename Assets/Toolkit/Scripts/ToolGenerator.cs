using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolGenerator : MonoBehaviour
{
    public GameObject[] handleParts;
    public GameObject[] headParts;
    public Vector3 spawningVector;
    public GameObject newWeaponPrefab;
    public GameObject spawnArea;
    private GameObject newWeapon;
    int arrayPositionHead;
    public int arrayPosHead
    {
        get { return arrayPositionHead; }
        set
        {
            if (value > headParts.Length - 1)
            {
                value = 0;
                arrayPositionHead = value;
            }
            else if (value < 0)
            {
                value = headParts.Length - 1;
                arrayPositionHead = value;
            }
            else
            {
                arrayPositionHead = value;
            }
        }

    }
    int arrayPositionHandle;
    public int arrayPosHandle
    {
        get { return arrayPositionHandle; }
        set
        {
            if( value > handleParts.Length - 1)
            {
                value = 0;
                arrayPositionHandle = value;
            }
            else if (value < 0)
            {
                value = handleParts.Length - 1;
                arrayPositionHandle = value;
            }
            else
            {
                arrayPositionHandle = value;
            }
        }
    }
    public ToolHandle toolHandle;
    public GameObject instHandle;
    public GameObject instHead;

    // Start is called before the first frame update
    void Start()
    {
        spawningVector = Vector3.zero;
        DontDestroyOnLoad(newWeaponPrefab.gameObject);
    }

    public void TestSceneStart()
    {
        if (newWeapon != null)
        {
            SceneManager.LoadScene("TestingArea");
        }
    }

    public void CheckWeaponSpawn()
    {
        if(newWeapon!= null)
        {
            Destroy(newWeapon);
            
        }
        ToolRandomSpawn();
    }

    public void LastHeadSpawn()
    {
        arrayPosHead--;
        CreateHead();
    }

    public void NextHeadSpawn()
    {
        arrayPosHead++;
        CreateHead();
    }

    public void LastHandleSpawn()
    {
        arrayPosHandle--;
        CreateHandle();
    }

    public void NextHandleSpawn()
    {
        arrayPosHandle++;
        CreateHandle();
    }


    public void ToolRandomSpawn()
    {
        newWeapon = Instantiate(newWeaponPrefab, spawningVector, Quaternion.identity, spawnArea.transform);

        arrayPosHandle = getRandomHandle();

        arrayPosHead = getRandomHead();

        CreateHandle();
        CreateHead();
    }

    int getRandomHandle()
    {
       return Random.Range(0, handleParts.Length);
        
    }

    int getRandomHead()
    {
        return Random.Range(0, headParts.Length);
    }

    void CreateHandle()
    {
        if (instHandle != null)
        {
            Destroy(instHandle);

        }
        instHandle = Instantiate(handleParts[arrayPosHandle], spawningVector, Quaternion.identity, newWeapon.transform);
        toolHandle = instHandle.GetComponent<ToolHandle>();
    }

    void CreateHead()
    {
        if (instHead != null)
        {
            Destroy(instHead);

        }
        instHead = Instantiate(headParts[arrayPosHead], toolHandle.headConnection.position, headParts[arrayPosHead].transform.rotation, newWeapon.transform);
    }
}

/* TO DO LIST -> 
      - REMOVE RANDOMIZER ELEMENTS 
      - IMPLEMENT IT WITH UI
*/