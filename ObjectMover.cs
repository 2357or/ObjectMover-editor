using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEngine.GUILayout;

public class ObjectMover : EditorWindow {
    [MenuItem ("Plugins/ObjectMover")]
    public static void ShowWindow () {
        GetWindow (typeof (ObjectMover));
    }

    GameObject Object;

    string[] valueType = { "Round", "Ceil", "Floor" };
    int selected_valueType = 0;

    void OnGUI () {
        Object = ObjectField ("What you want to Move", Object, typeof (GameObject), true) as GameObject;

        Space ();
        selected_valueType = Popup ("Integerization ValueType", selected_valueType, valueType);

        if (Button ("Integerization_Positon")) {
            var vector = Object.transform.position;
            Object.transform.position = mkValue (vector, selected_valueType);

        }
        if (Button ("Integerization_Rotatin")) {
            var vector = Object.transform.eulerAngles;
            Object.transform.rotation = Quaternion.Euler (mkValue (vector, selected_valueType));
        }

        var key = Event.current;
        if (key.type == EventType.KeyDown) {
            switch (key.keyCode.ToString ()) {
                case "G":
                    Object.transform.Translate (0, 0, 1);
                    break;
                case "B":
                    Object.transform.Translate (0, 0, -1);
                    break;
                case "N":
                    Object.transform.Translate (1, 0, 0);
                    break;
                case "V":
                    Object.transform.Translate (-1, 0, 0);
                    break;
                case "J":
                    Object.transform.Translate (0, 1, 0);
                    break;
                case "M":
                    Object.transform.Translate (0, -1, 0);
                    break;
                case "RightArrow":
                    Object.transform.Rotate (0, 1, 0);
                    break;
                case "LeftArrow":
                    Object.transform.Rotate (0, -1, 0);
                    break;
                case "UpArrow":
                    Object.transform.Rotate (1, 0, 0);
                    break;
                case "DownArrow":
                    Object.transform.Rotate (-1, 0, 0);
                    break;
            }
        }
    }

    Vector3 mkValue (Vector3 vector, int option = 0) {

        float x = vector.x;
        float y = vector.y;
        float z = vector.z;

        switch (option) {
            case 0:
                x = Mathf.Round (x);
                y = Mathf.Round (y);
                z = Mathf.Round (z);
                break;
            case 1:
                x = Mathf.Ceil (x);
                y = Mathf.Ceil (y);
                z = Mathf.Ceil (z);
                break;
            case 2:
                x = Mathf.Floor (x);
                y = Mathf.Floor (y);
                z = Mathf.Floor (z);
                break;
        }
        vector = new Vector3 (x, y, z);
        return vector;
    }
}