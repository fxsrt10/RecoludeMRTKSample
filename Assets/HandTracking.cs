using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Subsystems;
using UnityEngine.XR;

using Recolude.Core.IO;
using Recolude.Core.Record;
using Recolude.API;
using Recolude.Core.Properties;
using Unity.XR.CoreUtils;
using System.IO;
using Recolude.Core;

public class HandTracking : MonoBehaviour
{
    public GameObject indexGemHolder;
    public GameObject pinklyGemHolder;
    public GameObject middleGemHolder;
    public GameObject ringGemHolder;
    public GameObject thumbGemHolder;
    public GameObject reality;
    public GameObject soul;
    public GameObject space;
    public GameObject time;
    public GameObject mind;
    public GameObject power;

    public GameObject thumbtip;
    public GameObject thumbmid;
    public GameObject thumbprox;
    public GameObject thumbholder;

    public GameObject indextip;
    public GameObject indexmid;
    public GameObject indexprox;
    public GameObject indexholder;

    public GameObject pinkytip;
    public GameObject pinkymid;
    public GameObject pinkyprox;
    public GameObject pinkyholder;

    public GameObject ringtip;
    public GameObject ringmid;
    public GameObject ringprox;
    public GameObject ringholder;

    public GameObject middletip;
    public GameObject middlemid;
    public GameObject middleprox;
    public GameObject middleholder;

    public GameObject palm;
    public bool firstStone;



    GameObject indexFinger;
    HandsAggregatorSubsystem aggregator;
    HandJointPose jointPose;


    [SerializeField]
    RecoludeConfig config;
    [SerializeField]
    XROrigin XR_Origin;
    Recorder recorder;

    //Microsoft.MixedReality.Toolkit.HandJointPose
    // Start is called before the first frame update
    void Start()
    {

        // Right Hand
        recorder = new Recorder();
        string url = "https://app.recolude.com/webplayer-assets/clients/recolude/";
        recorder.Register(XR_Origin.Camera.gameObject, "Head Pose").SetMetaData("recolude-model", url + "thaboo.glb");
        //recorder.SetMetaData("recolude-model", "https://app.recolude.com/webplayer-assets/clients/unity-virtual-forest/EuropeanRabbit.glb");
        recorder.Register(soul, "Soul Gem").SetMetaData("recolude-model", url+"Stone.glb"); 
        recorder.Register(space, "Space Gem").SetMetaData("recolude-model", url + "Stone.glb");
        recorder.Register(time, "Time Gem").SetMetaData("recolude-model", url + "Stone.glb");
        recorder.Register(reality, "Reality Gem").SetMetaData("recolude-model", url + "Stone.glb");
        recorder.Register(mind, "Mind Gem").SetMetaData("recolude-model", url + "Stone.glb");
        recorder.Register(power, "Power Gem").SetMetaData("recolude-model", url + "Stone.glb");

        recorder.Register(middletip, "middletip").SetMetaData("recolude-model", url + "middletip.glb");
        recorder.Register(middlemid, "middlemid").SetMetaData("recolude-model", url + "middletip.glb");
        recorder.Register(middleprox, "middleprox").SetMetaData("recolude-model", url + "middletip.glb");
        recorder.Register(middleholder, "middleholder").SetMetaData("recolude-model", url + "gemHolder.glb");

        recorder.Register(ringtip, "ringtip").SetMetaData("recolude-model", url + "ringTip.glb");
        recorder.Register(ringmid,"ringmid").SetMetaData("recolude-model", url + "ringTip.glb");
        recorder.Register(ringprox,"ringprox").SetMetaData("recolude-model", url + "ringTip.glb");
        recorder.Register(ringholder,"ringholder").SetMetaData("recolude-model", url + "gemHolder.glb");

        recorder.Register(pinkytip, "pinkytip").SetMetaData("recolude-model", url + "pinkeyTip.glb");
        recorder.Register(pinkymid, "pinkymid").SetMetaData("recolude-model", url + "pinkymid.glb");
        recorder.Register(pinkyprox, "pinkyprox").SetMetaData("recolude-model", url + "pinkyProx.glb");
        recorder.Register(pinkyholder, "pinkyholder").SetMetaData("recolude-model", url + "gemHolder.glb");

        recorder.Register(indextip, "pinkytip");
        recorder.Register(indexmid, "pinkymid");
        recorder.Register(indexprox, "pinkyprox");
        recorder.Register(indexholder, "pinkyholder");




        recorder.Register(palm, "palm").SetMetaData("recolude-model", url + "PalmBackCombined.glb");

        recorder.Start();
        firstStone = true;
        recorder.SetMetaData("recolude-grid", new BoolProperty(true));
        //recorder.SetMetaData("First Gem", new StringProperty());

        aggregator = XRSubsystemHelpers.GetFirstRunningSubsystem<HandsAggregatorSubsystem>();
        bool jointIsValid = aggregator.TryGetJoint(TrackedHandJoint.IndexMetacarpal, XRNode.LeftHand, out jointPose);
        indexGemHolder.transform.SetPositionAndRotation(jointPose.Position,jointPose.Rotation);

        
    }

    // Update is called once per frame
    void Update()
    {
        aggregator = XRSubsystemHelpers.GetFirstRunningSubsystem<HandsAggregatorSubsystem>();


        aggregator.TryGetJoint(TrackedHandJoint.IndexProximal, XRNode.RightHand, out jointPose);
        indexGemHolder.transform.position = jointPose.Position;
        indexGemHolder.transform.rotation = jointPose.Rotation;

        aggregator.TryGetJoint(TrackedHandJoint.IndexIntermediate, XRNode.RightHand, out jointPose);
        indexprox.transform.position = jointPose.Position;
        indexprox.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.IndexTip, XRNode.RightHand, out jointPose);
        indextip.transform.position = jointPose.Position;
        indextip.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.IndexDistal, XRNode.RightHand, out jointPose);
        indexmid.transform.position = jointPose.Position;
        indexmid.transform.rotation = jointPose.Rotation;


        aggregator.TryGetJoint(TrackedHandJoint.LittleProximal, XRNode.RightHand, out jointPose);
        pinklyGemHolder.transform.position = jointPose.Position;
        pinklyGemHolder.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.LittleDistal, XRNode.RightHand, out jointPose);
        pinkyprox.transform.position = jointPose.Position;
        pinkyprox.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.LittleTip, XRNode.RightHand, out jointPose);
        pinkytip.transform.position = jointPose.Position;
        pinkytip.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.LittleIntermediate, XRNode.RightHand, out jointPose);
        pinkymid.transform.position = jointPose.Position;
        pinkymid.transform.rotation = jointPose.Rotation;


        aggregator.TryGetJoint(TrackedHandJoint.MiddleProximal, XRNode.RightHand, out jointPose);
        middleGemHolder.transform.position = jointPose.Position;
        middleGemHolder.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.MiddleDistal, XRNode.RightHand, out jointPose);
        middleprox.transform.position = jointPose.Position;
        middleprox.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.MiddleTip, XRNode.RightHand, out jointPose);
        middletip.transform.position = jointPose.Position;
        middletip.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.MiddleIntermediate, XRNode.RightHand, out jointPose);
        middlemid.transform.position = jointPose.Position;
        middlemid.transform.rotation = jointPose.Rotation;
        //positionRecorders[i].Record(new VectorCapture(Time.time, newPoint));



        aggregator.TryGetJoint(TrackedHandJoint.RingProximal, XRNode.RightHand, out jointPose);
        ringGemHolder.transform.position = jointPose.Position;
        ringGemHolder.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.RingDistal, XRNode.RightHand, out jointPose);
        ringprox.transform.position = jointPose.Position;
        ringprox.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.RingTip, XRNode.RightHand, out jointPose);
        ringtip.transform.position = jointPose.Position;
        ringtip.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.RingIntermediate, XRNode.RightHand, out jointPose);
        ringmid.transform.position = jointPose.Position;
        ringmid.transform.rotation = jointPose.Rotation;


        aggregator.TryGetJoint(TrackedHandJoint.ThumbProximal, XRNode.RightHand, out jointPose);
        thumbGemHolder.transform.position = jointPose.Position;
        thumbGemHolder.transform.rotation = jointPose.Rotation;

        thumbprox.transform.position = jointPose.Position;
        thumbprox.transform.rotation = jointPose.Rotation;
        aggregator.TryGetJoint(TrackedHandJoint.ThumbDistal, XRNode.RightHand, out jointPose);
        thumbtip.transform.position = jointPose.Position;
        thumbtip.transform.rotation = jointPose.Rotation;


        aggregator.TryGetJoint(TrackedHandJoint.Palm, XRNode.RightHand, out jointPose);
        //reality.transform.position = jointPose.Position;
        palm.transform.position = jointPose.Position;
        palm.transform.rotation = jointPose.Rotation;
    }

    public void Save()
    {
        // If the recorder is currently recording and the player clicks
        // save...
        if (recorder.CurrentlyRecording())
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

    public void SetStone(string stone)
    {
        if(firstStone)
        {
            recorder.SetMetaData("First Gem", new StringProperty(stone));
            firstStone = false;
        }
    }
}
