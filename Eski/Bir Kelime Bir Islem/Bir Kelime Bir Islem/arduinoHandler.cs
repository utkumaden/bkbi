using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bir_Kelime_Bir_Islem
{
    class ArduinoHandler
    {
        /*
            Protocol for arduino connection in the game:

            [] : Parameter
            () : Optianal
            < : From Here Only
            > : From Arduino Only

            ping [msg] : send a message (msg) and try to recieve the message;
            <light [1/2/3/a] [true/false] ([miliseconds]):
                1/2/3/a : Which player's button (or all's) should light up?
                true/false : Should the arduino turn on the light or off?
                miliseconds : (Optional) How long should the light stay in that state before returning to the default state?
            <forceDetect ([miliseconds])  : Command arduino to ignore every incoming command, until someone presses a button, in that (miliseconds) timeframe.
            <detect ([miliseconds]) : Detect any button presses, in that (miliseconds) timeframe;
            <vote ([miliseconds]) : Detect untill everyone presses the button in that (miliseconds) timeframe
            <quit : Stop all detecting, if any
            >press [1/2/3] : Tells the which one of the players (1/2/3) has pressed the button
            >voteDone : Tells when everyone has pressed the button
            >timeout : time has ran out.
            >cmdRecieved : command has been succesfullty recieved.

        */
        public string port = "COM1";
        public int baudRate = 9600;
        public int timeOut = 10;
        SerialPort serialCon = new SerialPort("COM1", 9600);
        
        public bool started = false;
        public bool enabled = true;

        public void startCom()
        {

        }

        public void stopCom()
        {

        }

        public void update()
        {
            bool b = started;
            stopCom();
            serialCon.BaudRate = baudRate;
            serialCon.PortName = port;
            serialCon.ReadTimeout = timeOut;
            if (b) startCom();
        }      

        public bool ping(string msg)
        {
            serialCon.WriteLine(msg);
            string recieved = serialCon.ReadLine();
            if (recieved != msg) return false;
            else return true;
        }

       
    }

}
