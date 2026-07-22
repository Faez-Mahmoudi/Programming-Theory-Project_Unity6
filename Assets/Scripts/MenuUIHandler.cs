using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chooseVehicleText;
    [SerializeField] private List<GameObject> myCar;
    [SerializeField] private List<Light> spotLights;
    [SerializeField] private float rotationSpeed = 25;
    [SerializeField] private PropellerSpiner propler;

    [SerializeField] private Animator carAnim;
    [SerializeField] private Animator planeAnim;
    [SerializeField] private Animator armorAnim;

    void Start()
    {
        chooseVehicleText.gameObject.SetActive(false);

        if(MainManager.Instance.sceneNum == 1)
            ArmorButton();
        else if (MainManager.Instance.sceneNum == 2)
            PlaneButton();
        else if (MainManager.Instance.sceneNum == 3)
            VehicleButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainManager.Instance.sceneNum == 1)
            myCar[0].transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }

    public void StartNew()
    {
        if (MainManager.Instance.sceneNum != 0)
            SceneManager.LoadScene(MainManager.Instance.sceneNum); 
        else
            chooseVehicleText.gameObject.SetActive(true);
    }

    public void ArmorButton()
    {
        MainManager.Instance.sceneNum = 1;
        SetRotation(1);
        SetRotation(2);

        SetLigh(0);
        SetAnim(true, false, false);
    }

    public void PlaneButton()
    {
        MainManager.Instance.sceneNum = 2;
        SetRotation(0);
        SetRotation(2);

        SetLigh(1);
        SetAnim(false, true, false);
    }

    public void VehicleButton()
    {
        MainManager.Instance.sceneNum = 3;
        SetRotation(0);
        SetRotation(1);

        SetLigh(2);
        SetAnim(false, false, true);
    }

    // ABSTRACTION
    private void SetRotation(int n)
    {
        myCar[n].transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    // ABSTRACTION
    private void SetLigh(int n)
    {
        foreach (var light in spotLights)
        {
            light.enabled = false;
        }
        spotLights[n].enabled = true;
    }

    // ABSTRACTION
    private void SetAnim(bool armor, bool plane, bool car)
    {
        armorAnim.SetBool("isSelected", armor);
        carAnim.SetBool("isSelected", car);
        planeAnim.SetBool("isSelected", plane);
        propler.enabled = plane;
    }

    public void Exit()
    {
    # if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    # else
        Application.Quit();
    # endif
    }
}
