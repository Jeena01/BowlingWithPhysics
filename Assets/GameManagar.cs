using UnityEngine;
using TMPro;
public class GameManagar : MonoBehaviour
{
    [SerializeField] private float score=0;

    [SerializeField] private BallController ball;

    [SerializeField] private GameObject pinCollection;

    [SerializeField] private Transform pinAnchor;

    [SerializeField] private InputManager inputManager;


    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    private void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }
    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }
    private void SetPins()
    {
        if(pinObjects){
            foreach( Transform child in pinObjects.transform){
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
            
        }

        pinObjects = Instantiate(pinCollection,
                pinAnchor.transform.position,
                Quaternion.identity, transform);
                fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
                fallTriggers = System.Array.FindAll(fallTriggers, pin => pin.transform.IsChildOf(pinObjects.transform));

                 Debug.Log($"Total pins detected: {fallTriggers.Length}");
        foreach (FallTrigger pin in fallTriggers)
        {
            Debug.Log($"Detected FallTrigger on: {pin.gameObject.name}");
            pin.onPinFall.RemoveAllListeners();
            pin.onPinFall.AddListener(IncrementScore);
            pin.isPinFallen = false;
        }
    }
    private void IncrementScore(){
        score++;
        scoreText.text = $"Score: {score/2}";
    }
}
