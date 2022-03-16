using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Pipelines;

public class ARPlaceTrackedImages : MonoBehaviour
{
    // Cache AR tracked images manager from ARCoreSession
    private ARTrackedImageManager _trackedImagesManager;

    // List of prefabs - these have to have the same names as the 2D images in the reference image library
    [SerializeField]
    public GameObject[] ArPrefabs;

    [SerializeField]
    public GameObject ToastOutput;

    [SerializeField]
    public int ToastDuration;

    Image toastImg;
    Text toastHeader;
    Text toastText;

    // Internal storage of created prefabs for easier updating
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();
    // Internal storage of Sprite Resources
    private readonly Dictionary<int, Sprite> modelSprites = new Dictionary<int, Sprite>();

    // Reference to logging UI element in the canvas
    private string logText;
    private string currentTarget = "none";
        
    void Awake()
    {   
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();

        foreach (var model in Data.models)
        {
            modelSprites.Add(
                model.ID,
                Resources.Load<Sprite>("Sprites/ModelGrid/" + model.ID));
        }

        if (ToastOutput == null)
        {
            print("Toast is null");
        }else
        {
            toastImg = ToastOutput.transform.GetChild(0).GetComponent<Image>();
            toastHeader = ToastOutput.transform.GetChild(1).GetComponent<Text>();
            toastText = ToastOutput.transform.GetChild(2).GetComponent<Text>();

            if (toastImg == null || toastHeader == null || toastText == null) {
                print("Couldn't access to toast properties");
            }
        }
    }
    
    void OnEnable()
    {
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // Good reference: https://forum.unity.com/threads/arfoundation-2-image-tracking-with-many-ref-images-and-many-objects.680518/#post-4668326
        // https://github.com/Unity-Technologies/arfoundation-samples/issues/261#issuecomment-555618182
        
        // Go through all tracked images that have been added
        // (-> new markers detected)
        
        foreach (var trackedImage in eventArgs.added)
        {
            // Get the name of the reference image to search for the corresponding prefab
            var imageName = trackedImage.referenceImage.name;
            foreach (var curPrefab in ArPrefabs)
            {
                if (imageName.Contains(curPrefab.name, StringComparison.OrdinalIgnoreCase)
                    && !_instantiatedPrefabs.ContainsKey(imageName))
                {
                    // Found a corresponding prefab for the reference image, and it has not been instantiated yet
                    // -> new instance, with the ARTrackedImage as parent (so it will automatically get updated
                    // when the marker changes in real-life)
                    var newPrefab = Instantiate(curPrefab, trackedImage.transform);
                    // Store a reference to the created prefab
                    _instantiatedPrefabs[imageName] = newPrefab;
                    _instantiatedPrefabs[imageName].name = curPrefab.name;
                    logText = $"{Time.time} -> Tracked image (name: {imageName}).\n" +
                            $"using prefab (name: {curPrefab.name}).\n" +
                            $"guid: {trackedImage.referenceImage.guid}";
                    
                    Debug.Log(logText);
                }
            }
        }

        // Disable instantiated prefabs that are no longer being actively tracked
        foreach (var trackedImage in eventArgs.updated)
        {
            _instantiatedPrefabs[trackedImage.referenceImage.name]
                .SetActive(trackedImage.trackingState == TrackingState.Tracking);

            if (trackedImage.trackingState == TrackingState.Tracking
                && currentTarget != trackedImage.referenceImage.name)
            {
                currentTarget = trackedImage.referenceImage.name;

                var prefabName = _instantiatedPrefabs[trackedImage.referenceImage.name].name;
                Debug.Log("Now tracking: " + prefabName);
                Notify(prefabName);
            }
        }

        // Remove is called if the subsystem has given up looking for the trackable again.
        // (If it's invisible, its tracking state would just go to limited initially).
        // Note: ARCore doesn't seem to remove these at all; if it does, it would delete our child GameObject
        // as well.
        foreach (var trackedImage in eventArgs.removed)
        {
            // Destroy the instance in the scene.
            // Note: this code does not delete the ARTrackedImage parent, which was created
            // by AR Foundation, is managed by it and should therefore also be deleted
            // by AR Foundation.
            Destroy(_instantiatedPrefabs[trackedImage.referenceImage.name]);
            // Also remove the instance from our array
            _instantiatedPrefabs.Remove(trackedImage.referenceImage.name);

            // Alternative: do not destroy the instance, just set it inactive
            //_instantiatedPrefabs[trackedImage.referenceImage.name].SetActive(false);

            logText = $"REMOVED (TrackerName: {trackedImage.referenceImage.name}).";
            Debug.Log(logText);
        }
    }

    private void Notify(string modelName)
    {
        var model = Data.FindModelByName(modelName);
        RedirectData.targetModel = model;
        RedirectData.targetSprite = toastImg.sprite = modelSprites[model.ID];
        toastHeader.text = model.Name;
        toastText.text = model.Type;

        ToastOutput.SetActive(true);
        Invoke("HideNotify", ToastDuration);
    }

    private void HideNotify()
    {
        ToastOutput.SetActive(false);
        Debug.Log("Notify hidden");
    }
}

public static class StringExtensions
{
   public static bool Contains(this String str, String substring, 
                               StringComparison comp)
   {                            
        if (substring == null)
            throw new ArgumentNullException("substring", 
                                         "substring cannot be null.");
        else if (! Enum.IsDefined(typeof(StringComparison), comp))
            throw new ArgumentException("comp is not a member of StringComparison",
                                     "comp");

        return str.IndexOf(substring, comp) >= 0;                      
   }
}