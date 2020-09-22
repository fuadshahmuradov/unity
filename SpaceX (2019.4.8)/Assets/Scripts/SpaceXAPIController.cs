using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceXAPIController : MonoBehaviour
{
    private readonly string baseUrl = "https://api.spacexdata.com/v3/";

    [SerializeField] GameObject LauncherSelectButton;
    [SerializeField] GameObject ParentObject;
    [SerializeField] Text InfoText;
    [SerializeField] Slider LoadingSlider;
    [SerializeField] Texture Upcoming;
    [SerializeField] Texture Done;

    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        LoadingSlider.value = timer;
        //print(timer);
        if (timer >= 5)
        {
            LoadingSlider.gameObject.SetActive(false);
        }
    }

    IEnumerator Start()
    {
        for (int i = 1; i < 115; i++)
        {
        Start:
            string launchUrl = baseUrl + "launches/" + i;
            UnityWebRequest launchInfoRequest = UnityWebRequest.Get(launchUrl);
            yield return launchInfoRequest.SendWebRequest();

            // flight 112 and 113 were null
            if (launchInfoRequest.isNetworkError || launchInfoRequest.isHttpError)
            {
                i++;
                goto Start;
            }

            GameObject k = Instantiate(LauncherSelectButton) as GameObject;
            k.transform.SetParent(ParentObject.transform);

            JSONNode launchInfo = JSON.Parse(launchInfoRequest.downloadHandler.text);

            if (launchInfo["upcoming"])
            {
                k.GetComponentInChildren<RawImage>().texture = Upcoming;
            }
            else
            {
                k.GetComponentInChildren<RawImage>().texture = Done;
            }

            string missionsUrl = baseUrl + "missions/" + launchInfo["mission_id"][0];
            UnityWebRequest missionInfoRequest = UnityWebRequest.Get(missionsUrl);
            yield return missionInfoRequest.SendWebRequest();
            JSONNode missionInfo = JSON.Parse(missionInfoRequest.downloadHandler.text);

            string rocketsUrl = baseUrl + "rockets/" + launchInfo["rocket"]["rocket_id"];
            UnityWebRequest rocketInfoRequest = UnityWebRequest.Get(rocketsUrl);
            yield return rocketInfoRequest.SendWebRequest();
            JSONNode rocketInfo = JSON.Parse(rocketInfoRequest.downloadHandler.text);

            string country = rocketInfo["country"];
            string numOfPayloads = missionInfo["payload_ids"].Count.ToString();
            string missionName = launchInfo["mission_name"];
            string rocketName = launchInfo["rocket"]["rocket_name"];

            k.GetComponent<Launches>().id = i;
            k.GetComponentInChildren<Text>().text = missionName + " mission, " + rocketName + " rocket, " + numOfPayloads + " payloads. " + country;
            if (i == 114)
            {
                print("Finished at " + timer);
            }
        }
    }

    public void GetId()
    {
        print(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Launches>().id);
    }

    public void DisplayPopUp()
    {
        StartCoroutine(CalculatePopUpInfo());
    }

    public IEnumerator CalculatePopUpInfo()
    {
        int id = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Launches>().id;
        string launchUrl = baseUrl + "launches/" + id;
        UnityWebRequest launchInfoRequest = UnityWebRequest.Get(launchUrl);
        yield return launchInfoRequest.SendWebRequest();
        JSONNode launchInfo = JSON.Parse(launchInfoRequest.downloadHandler.text);

        int i = 0;

        while (true)
        {
            if (launchInfo["ships"][i] == null && i == 0)
            {
                InfoText.text = "There are no elements to display.";
                break;
            }
            else if (launchInfo["ships"][i] == null)
            {
                break;
            }
            else
            {
                InfoText.text = "Loading...";

                string shipUrl = baseUrl + "ships/" + launchInfo["ships"][i];
                UnityWebRequest shipInfoRequest = UnityWebRequest.Get(shipUrl);
                yield return shipInfoRequest.SendWebRequest();
                JSONNode shipInfo = JSON.Parse(shipInfoRequest.downloadHandler.text);

                InfoText.text = "Ship name: " + shipInfo["ship_name"] + "\nShip type: " + shipInfo["ship_type"] +
                    "\nHome port: " + shipInfo["home_port"] + "\nNumber of missions it was used in: " + shipInfo["missions"].Count;
                i++;
            }
        }
    }
}
