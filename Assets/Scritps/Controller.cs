using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Controller : MonoBehaviour
{
    [SerializeField] GameObject red = default;
    [SerializeField] GameObject blue = default;
    [SerializeField] GameObject green = default;
    [SerializeField] GameObject origin = default;
    [SerializeField] LineRenderer redLine = default;
    [SerializeField] LineRenderer greenLine = default;
    [SerializeField] LineRenderer blueLine = default;
    [SerializeField] Text debugText = default;


    void Start() {

    }

    void Update() {
        redLine.SetPosition(0, origin.transform.position);
        redLine.SetPosition(1, red.transform.position);
        blueLine.SetPosition(0, origin.transform.position);
        blueLine.SetPosition(1, blue.transform.position);


        float dot = Vector3.Dot(
            red.transform.position.normalized,
            blue.transform.position.normalized
        );

        float degree = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // Vector3 cross = Vector3.Cross(
        //     green.transform.position, 
        //     red.transform.position
        // );

        Vector3 cross = Vector3.Cross(
            red.transform.position,
            blue.transform.position
        );

        greenLine.SetPosition(0, origin.transform.position);
        greenLine.SetPosition(1, cross);

        green.transform.position = cross;

        debugText.text = "Dot: " + dot.ToString("F2") + "\nDeg: " + degree.ToString("F2") + "\nCross: " + cross + "\nMagnitude: " + cross.magnitude.ToString("F1");
    }
}
