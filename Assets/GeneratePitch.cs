using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePitch : MonoBehaviour
{
    public float RmsValue;
    public float DbValue;
    public float PitchValue;
    public float Pitch;
    public AudioSource[] aus;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;
    public float[] PitchValueTotal;
    public float[] count;
    public float[] PitchValueAverage;

    void Start()
    {
        //Debug.Log(aus[0].name);
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        PitchValueAverage = new float[44];
        PitchValueTotal = new float[44];
        count = new float[44];
        _fSample = AudioSettings.outputSampleRate;
        //PitchValueTotal = 0;
    }

    void Update()
    {
        
        float pv;
        int i;
        //aus[0].Play();
        
        for (i = 0; i < 44; i++)
        {
            //PitchValueTotal = 0;
            //count = 0;
            pv = AnalyzeSound(i);
            if (pv == 0)
            {
            }
            else
            {
                PitchValueTotal[i] += pv;
                count[i] += 1;
            }
            PitchValueAverage[i] = PitchValueTotal[i] / count[i];
            Debug.Log(PitchValueTotal[i] / count[i]);
        }
        
        /*
        i = 1;
        pv = AnalyzeSound(i);
        if (pv == 0)
        {
        }
        else
        {
            PitchValueTotal[i] += pv;
            count[i] += 1;
        }
        PitchValueAverage[i] = PitchValueTotal[i] / count[i];
        Debug.Log(PitchValueTotal[i] / count[i]);
        */

    }

    float AnalyzeSound(int x)
    {
        //GetComponent<AudioSource>().GetOutputData(_samples[x], 0); // fill array with samples
        aus[x].GetOutputData(_samples, 0);
        //Debug.Log(_samples[x][0]);
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
        //GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        aus[x].GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
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
        return PitchValue;
    }

    float FrequencytoPitchConverter(float freq)
    {
        return (12 * Mathf.Log(freq / 440, 2) + 49);
    }
}
