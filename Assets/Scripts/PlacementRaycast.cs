using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

//Manque le couleur configurable du cube

public class PlacementRaycast : MonoBehaviour
{
    public GameObject cubePrefab;

    private InputSystem_Actions inputActions;

    public Color couleurDuCube = Color.white;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        

            if(Physics.Raycast(ray, out hit))
            {
                GameObject nouveauCube = Instantiate(cubePrefab, hit.point, Quaternion.identity);
                Renderer cubeRenderer = nouveauCube.GetComponent<Renderer>();
                if (cubeRenderer != null)
                {
                    cubeRenderer.material.color = couleurDuCube;
                }
            }
        }
    }

    void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.SelectColor.performed += OnColorSelect;
    }

    void OnColorSelect(InputAction.CallbackContext context)
    {
        // Obtenir le contrôle qui a déclenché l'action
        if (context.control is KeyControl key)
        {
            switch (key.keyCode)
            {
                case Key.Digit1:
                    ChangeColor(0);
                    break;
                case Key.Digit2:
                    ChangeColor(1);
                    break;
                case Key.Digit3:
                    ChangeColor(2);
                    break;
                case Key.Digit4:
                    ChangeColor(3);
                    break;
                case Key.Digit5:
                    ChangeColor(4);
                    break;
            }
        }
    }

    void ChangeColor(int colorIndex)
    {
        Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };
        couleurDuCube = colors[colorIndex];
    }

}
