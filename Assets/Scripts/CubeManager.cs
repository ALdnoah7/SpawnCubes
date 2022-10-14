using UnityEngine;
using TMPro;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _distanceTMP;
    [SerializeField] private TMP_InputField _timeTMP;
    [SerializeField] private TMP_InputField _speedTMP;
    [SerializeField] private StartSettingsScriptableObject _settingsScriptableObject;
    
    [SerializeField] private float _startTimeSpawn;
    [SerializeField] private float _distance;
    [SerializeField] private float _speedCube;
    
    [SerializeField] private GameObject _prefabCube;

    private float _timeSpawn;
    
    void Start()
    {
        Reset();
        _timeSpawn = _startTimeSpawn;
    }

    void FixedUpdate()
    {
        if (_timeSpawn > 0)
        {
            _timeSpawn -= Time.deltaTime;
        }
        else
        {
            _timeSpawn = _startTimeSpawn;
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        GameObject temp = Instantiate(_prefabCube, Vector3.zero, Quaternion.identity);
        Vector2 randPos = Random.insideUnitCircle.normalized * _distance;
        Vector3 endPos = new Vector3(randPos.x, 0, randPos.y);
        temp.GetComponent<CubeMove>().SetSettings(_speedCube, endPos);
    }

    public void Reset()
    {
        _startTimeSpawn = _settingsScriptableObject.time;
        _distance = _settingsScriptableObject.distance;
        _speedCube = _settingsScriptableObject.speed;
        ResetUI();
    }

    private void ResetUI()
    {
        _distanceTMP.text = "";
        _timeTMP.text = "";
        _speedTMP.text = "";
        _distanceTMP.placeholder.GetComponent<TextMeshProUGUI>().text = "default: " + _distance;
        _timeTMP.placeholder.GetComponent<TextMeshProUGUI>().text = "default: " + _startTimeSpawn;
        _speedTMP.placeholder.GetComponent<TextMeshProUGUI>().text = "default: " + _speedCube;
    }
    
    public void SetTimeSpawn(string time)
    {
        if (!time.Equals(""))
        {
            _startTimeSpawn = float.Parse(time);
        }
        Debug.Log("Time: " + _startTimeSpawn);
    }    
    
    public void SetDistance(string distance)
    {
        if (!distance.Equals(""))
        {
            _distance = float.Parse(distance);
        }
        Debug.Log("Distance: " + _distance);
    }    
    
    public void SetSpeed(string speed)
    {
        if (!speed.Equals(""))
        {
            _speedCube = float.Parse(speed);
        }
        Debug.Log("Speed: " + _speedCube);
    }
}
