using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] public TMP_InputField nameInputField;
    [SerializeField] private List<GameObject> myCar;
    [SerializeField] private float rotationSpeed = 25;

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance.sceneNum != 0)
            myCar[MainManager.Instance.sceneNum - 1].transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

    public void StartNew()
    {
        if (MainManager.Instance.playerName == "")
        {
            MainManager.Instance.playerName = nameInputField.text;
        }
        else if (nameInputField.text != "" )
        {
            MainManager.Instance.playerName = nameInputField.text;
        }

        if (MainManager.Instance.sceneNum != 0)
            SceneManager.LoadScene(MainManager.Instance.sceneNum); 
    }

    public void ArmorButton()
    {
        MainManager.Instance.sceneNum = 1;
        SetRotation(1);
        SetRotation(2);
    }

    public void PlaneButton()
    {
        MainManager.Instance.sceneNum = 2;
        SetRotation(0);
        SetRotation(2);
    }

    public void VehicleButton()
    {
        MainManager.Instance.sceneNum = 3;
        SetRotation(0);
        SetRotation(1);
    }

    // ABSTRACTION
    private void SetRotation(int n)
    {
        myCar[n].transform.rotation = new Quaternion(0, 180, 0, 0);
    }
}
