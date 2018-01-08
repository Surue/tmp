using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

public class TwitchChat : MonoBehaviour {

    TcpClient twitchClient;
    StreamReader reader;
    StreamWriter writer;

    public string username, password, channelName;

	// Use this for initialization
	void Start () {
        Connect();
	}
	
	// Update is called once per frame
	void Update () {
        if(!twitchClient.Connected)
        {
            Connect();
        }

        ReadChat();

        if(Input.GetButtonDown("Jump"))
        {
            WriteChat("Message to twitch");
        }
	}

    private void Connect()
    {
        twitchClient = new TcpClient("irc.chat.twitch.tv",6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 0 * :" + username);
        writer.WriteLine("JOIN #" + channelName);
        writer.Flush();
    }

    void ReadChat()
    {
        if(twitchClient.Available > 0)
        {
            string message = reader.ReadLine();

            if(message.Contains("PRIVMSG"))
            {
                int splitPoint = message.IndexOf("!", 1);
                string chatName = message.Substring(0, splitPoint);
                chatName = chatName.Substring(1);

                splitPoint = message.IndexOf(":",1);
                message = message.Substring(splitPoint + 1);
                print(string.Format("{0}: {1}",chatName,message));
            }
        }
    }

    void WriteChat(string str)
    {
        writer.WriteLine("PRIVMSG #" + channelName + " :" + str);
        writer.Flush();
    }

    IEnumerator Vote()
    {
        //Choos thing to vote about

        while(true)
        {
            //Get all input from viewers

            //Count 
        }
    }
}
