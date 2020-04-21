using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RegisterUser : MonoBehaviour
{
    public InputField EmailInput;
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button RegisterButton;
    EventSystem system;
    // Start is called before the first frame update
    void Start()
    {
        EmailInput.Select();
        EmailInput.ActivateInputField();
        RegisterButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.RegisterUser(EmailInput.text, UsernameInput.text, PasswordInput.text));
        });

        system = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            //else Debug.Log("next nagivation element not found");

        }
    }
}
