using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateInterval : MonoBehaviour
{
    public float RmsValue;
    public float DbValue;
    public float PitchValue;
    public float Pitch;
    public float pi_mic;
    

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;



    int index_interval;
    int index_not;
    int index_not_answer;
    int chord;
    int pitchAnswer;
    string[] interval_name;
    string[] not_name;
    public QuizManager QuizManager;
    public Text txt;
    public AudioSource[] aus;
    

    // Start is called before the first frame update
    void Start()
    {
        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;


        index_interval = Random.Range(0, 12);
        interval_name = new string[12];
        interval_name[0] = "Minor 2nd";
        interval_name[1] = "Major 2nd";
        interval_name[2] = "Minor 3rd";
        interval_name[3] = "Major 3rd";
        interval_name[4] = "Perfect 4th";
        interval_name[5] = "Tritone";
        interval_name[6] = "Perfect 5th";
        interval_name[7] = "Minor 6th";
        interval_name[8] = "Major 6th";
        interval_name[9] = "Minor 7th";
        interval_name[10] = "Major 7th";
        interval_name[11] = "Octave";

        txt.text = interval_name[index_interval]+" Up";


        index_not = Random.Range(0, 25);
        aus[index_not].Play();
        Debug.Log(index_interval.ToString());
        Debug.Log(aus[index_not].name);

        index_not_answer = index_not + (index_interval + 1);
        //Debug.Log(index_not_answer.ToString());

        Dictionary<string, int> pitchNot = new Dictionary<string, int>();
        pitchNot.Add("a5#", 61);
        pitchNot.Add("a5", 61);
        pitchNot.Add("a6#", 73);
        pitchNot.Add("a6", 73);
        pitchNot.Add("b5", 63);
        pitchNot.Add("b6", 75);
        pitchNot.Add("c5#", 52);
        pitchNot.Add("c5", 52);
        pitchNot.Add("c6#", 64);
        pitchNot.Add("c6", 64);
        pitchNot.Add("c7", 76);
        pitchNot.Add("d5#", 54);
        pitchNot.Add("d6#", 66);
        pitchNot.Add("e5", 56);
        pitchNot.Add("e6", 68);
        pitchNot.Add("f5#", 57);
        pitchNot.Add("f5", 57);
        pitchNot.Add("f6#", 69);
        pitchNot.Add("f6", 69);
        pitchNot.Add("g5#", 59);
        pitchNot.Add("g5", 59);
        pitchNot.Add("g6#", 71);
        pitchNot.Add("g6", 71);


        pitchAnswer = pitchNot[aus[index_not].name] + (index_interval + 1);
        Debug.Log(pitchAnswer.ToString());






    }

    // Update is called once per frame
    void Update()
    {
        pi_mic = AnalyzeSound(aus[25]);
        if (pi_mic==pitchAnswer)
        {
            txt.text = "Answer Correct";
        }
    }

    float AnalyzeSound(AudioSource x)
    {
        x.GetOutputData(_samples, 0); // fill array with samples
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
        x.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
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
        return Pitch;
    }

    float FrequencytoPitchConverter(float freq)
    {
        return (12 * Mathf.Log(freq / 440, 2) + 49);
    }
}
