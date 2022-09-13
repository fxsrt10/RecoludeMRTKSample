using System.IO;
using UnityEngine;

using Recolude.Core.IO;
using Recolude.Core.Record;
using Recolude.API;
using Recolude.Core.Properties;
using Unity.XR.CoreUtils;

///<summary>
/// This script is meant to act as a demo for creating recordings. It creates 3
/// boxes and registers them to be recorded. It then starts the root recorder.
/// The user can choose to stop the recorder by clicking the save
/// button. Clicking the save button takes the recording and saves it to assets
/// folder in the project.
///</summary>
public class RecordingExampleMRTK : MonoBehaviour
{
    // The recorder in charge of keeping up with all the subjects in the
    //scene.
    Recorder recorder;

    [SerializeField]
    int numberOfCubes = 3;


    [SerializeField]
    RecoludeConfig config;
    [SerializeField]
    XROrigin XR_Origin;

    // Start is called before the first frame update
    void Start()
    {
        // Create a new root recording
        recorder = new Recorder();

        //var incrementer = 8f / (numberOfCubes - 1);
        //for (int i = 0; i < numberOfCubes; i++)
        //{
        //    var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    cube.AddComponent<Rigidbody>();
        //    cube.transform.position = new Vector3((i * incrementer) - 4f, 3, 0);

        //    // Create a Child Recorder and set it to track the cube.
        //    recorder.Register(cube);
        //}
        recorder.Register(XR_Origin.Camera.gameObject, "Head Pose");
        

        // Store info about the cube drop simulation

        // Start the recorder so it will capture all events occuring both
        // to it and the registered children recorders.
        recorder.Start();
        recorder.SetMetaData("recolude-grid", new BoolProperty(true));
        
    }

    private void OnGUI()
    {
        // If the recorder is currently recording and the player clicks
        // save...
        if (recorder.CurrentlyRecording() && GUILayout.Button("Save"))
        {
            // Create a recording with all captured events up to this
            // point and stop the recorder from accepting any new
            // event captures.
            var recording = recorder.Finish();

            // Take the recording we just created and save it to the
            // assets folder inside our project.
            using (FileStream fs = File.Create(string.Format("{0}/demo.rap", Application.dataPath)))
            using (var rapWriter = new RAPWriter(fs))
            {
                rapWriter.Write(recording);
            }
            config.UploadRecording(recording);
            
        }
    }
}
