using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheck : MonoBehaviour
{
    public float RmsValue;
    public float DbValue;
    public float PitchValue;
    public float Pitch;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;
    
    Dictionary<string, double> QuestionPitchValue = new Dictionary<string, double>();

    void Start()
    {
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;
        QuestionPitchValue.Add("A#1", 116.773);
        QuestionPitchValue.Add("A1", 111.8184);
        QuestionPitchValue.Add("B1", 121.5286);
        QuestionPitchValue.Add("C2", 132.6923);
        QuestionPitchValue.Add("D#2", 157.0971);
        QuestionPitchValue.Add("D#3", 309.4821);
        QuestionPitchValue.Add("D2", 174.4423);
        QuestionPitchValue.Add("D3", 296.1522);
        QuestionPitchValue.Add("E1", 82.3755);
        QuestionPitchValue.Add("E3", 329.0653);
        QuestionPitchValue.Add("F#1", 92.87058);
        QuestionPitchValue.Add("F#3", 741.7997);
        QuestionPitchValue.Add("F1", 88.74954);
        QuestionPitchValue.Add("F3", 349.5236);
        QuestionPitchValue.Add("G1", 96.90282);
    }

    void Update()
    {
        AnalyzeSound();
    }

    void AnalyzeSound()
    {
        GetComponent<AudioSource>().GetOutputData(_samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        DbValue = 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB
        if (DbValue < -160) DbValue = -160; // clamp it to -160dB min
                                            // get sound spectrum
        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        { // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < QSamples - 1)
        { // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        PitchValue = freqN * (_fSample / 2) / QSamples; // convert index to frequency
        Pitch = FrequencytoPitchConverter(PitchValue);
    }

    float FrequencytoPitchConverter(float freq)
    {
        return (12 * Mathf.Log(freq / 440, 2) + 49);
    }
}
