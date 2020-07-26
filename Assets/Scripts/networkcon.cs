using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;

public class networkcon : MonoBehaviour
{
    public GameObject car;
    Thread mThread;
    public string connectionIP = "127.0.0.1";
    public int connectionPort = 25001;//25001
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    Vector3 pos = Vector3.zero;

    bool running;
    string dataReceived;

    private void Update()
    {
        
        if (dataReceived!=null)
        {
            AnalyseData(dataReceived);
        }
        //transform.position = pos;
    }

    private void Start()
    {
        ThreadStart ts = new ThreadStart(GetInfo);
        mThread = new Thread(ts);
        mThread.Start();
        
    }

    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                print(ip.ToString());
                return ip.ToString();
                
            }
        }
        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }
    void GetInfo()
    {
        print("getting info");
        localAdd = IPAddress.Parse(connectionIP);
        listener = new TcpListener(IPAddress.Any, connectionPort);
        while (true)
        {
            listener.Start();

            client = listener.AcceptTcpClient();


            running = true;
            while (running)
            {
              //  print("searching for");
                Connection();
                
            }
            listener.Stop();
        }
    }

    void Connection()
    {
        //print("connection");
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];

        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
        dataReceived = null;
        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        if (dataReceived != null)
        {
            if (dataReceived == "stop")
            {
                running = false;
            }
            else
            {
                
                
              //  print("data: "+ dataReceived);
                nwStream.Write(buffer, 0, bytesRead);
            }
        }
    }
    public void AnalyseData(string data) {
        string[] dataItems = data.Split(',');
        if (dataItems != null)
        {
            foreach (string dataItem in dataItems)
            {
                if(dataItem.Trim()!= "")
                {
                    string[] strings = dataItem.Split(':');
                    if(strings[0].Trim() != "")
                    {
                        string command = strings[0];
                        string value = strings[1];
                        print("command: " + command);
                        print("value: " + value);

                        SimpleCarController SCController;

                        switch (command)
                        {
                            case "accelerate":
                                SCController = car.GetComponent<SimpleCarController>();
                                SCController.accelerationValue = float.Parse(value);
                                // print("accelerating: " + value);
                                break;
                            case "direction":
                                SCController = car.GetComponent<SimpleCarController>();
                                SCController.direction = float.Parse(value);
                                // print("direction" + value);
                                break;

                            default:
                                print("default case");
                                SCController = car.GetComponent<SimpleCarController>();
                                SCController.accelerationValue = 0;
                                SCController.direction = 0;
                                break;
                        }
                    }
                   
                }
                    
            }
        }
    }
    public static Vector3 StringToVector3(string sVector) //"accelerate:1,direction:1 " 
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }
}