using UnityEngine;

public class DoNotDestroyObject : MonoBehaviour
{
    [SerializeField] private string _objName;
    private void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag(_objName);
        if (musicObject.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
