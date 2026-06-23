using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] public TMP_InputField nameInputField;
    [SerializeField] private List<GameObject> myCar;
    [SerializeField] private List<Light> spotLights;
    [SerializeField] private float rotationSpeed = 25;
    [SerializeField] private PropellerSpiner propler;

    private Animator carAnim;
    [SerializeField] private Animator armorAnim;

    void Start()
    {
        carAnim = myCar[2].GetComponent<Animator>();
        //armorAnim = myCar[0].GetComponent<Animator>();
    }

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

        SetLigh(0);
        armorAnim.SetBool("isSelected", true);
        carAnim.SetBool("isSelected", false);
        propler.enabled = false;
    }

    public void PlaneButton()
    {
        MainManager.Instance.sceneNum = 2;
        SetRotation(0);
        SetRotation(2);

        SetLigh(1);
        carAnim.SetBool("isSelected", false);
        armorAnim.SetBool("isSelected", false);

        propler.enabled = true;
    }

    public void VehicleButton()
    {
        MainManager.Instance.sceneNum = 3;
        SetRotation(0);
        SetRotation(1);

        SetLigh(2);
        carAnim.SetBool("isSelected", true);
        armorAnim.SetBool("isSelected", false);

        propler.enabled = false;
    }

    // ABSTRACTION
    private void SetRotation(int n)
    {
        myCar[n].transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    private void SetLigh(int n)
    {
        foreach (var light in spotLights)
        {
            light.enabled = false;
        }
        spotLights[n].enabled = true;
    }

    public void Exit()
    {
    # if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    # else
        Application.Quit();
    # endif

        //Saves the last bestScore and bestPlayerName
        //MyManager.Instance.SaveScore();
    }
}
