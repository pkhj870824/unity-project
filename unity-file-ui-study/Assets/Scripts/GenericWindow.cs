using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour
{

    protected WindowManager manager;
    public GameObject firstSelected;

    private EventSystem eventSystem;

    protected virtual void Awake()
    {
        eventSystem = EventSystem.current;
    }

    public void Init(WindowManager manager)
    {
        this.manager = manager;
    }

    public void OnFocus()
    {
        eventSystem.SetSelectedGameObject(firstSelected);
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        OnFocus();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
