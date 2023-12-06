using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class PlayGraph : MonoBehaviour
{
    private PlayableGraph playableGraph;
    private AnimationClipPlayable clipPlayable;

    public AnimationClip runAnimation;

    void Start()
    {
        // Create a PlayableGraph
        playableGraph = PlayableGraph.Create();


        // Set the time update mode to GameTime (frame-dependent)
        playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

        // Create an AnimationClipPlayable for the run animation
        clipPlayable = AnimationClipPlayable.Create(playableGraph, runAnimation);

        // Create an AnimationPlayableOutput and connect it to the Animator
        AnimationPlayableOutput animationOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());
        animationOutput.SetSourcePlayable(clipPlayable);

        // Play the graph
        playableGraph.Play();
    }

    private void Update()
    {
        GraphVisualizerClient.Show(playableGraph);

    }

    void OnDestroy()
    {
        // Destroy the graph when the object is destroyed
        if (playableGraph.IsValid())
        {
            playableGraph.Destroy();
        }
    }
}
