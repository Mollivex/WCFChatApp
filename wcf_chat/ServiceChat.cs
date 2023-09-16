using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

// Implementation of WCFChatApp user functionality (UI)

namespace wcf_chat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<ServerUser> users = new List<ServerUser>();
        int nextID = 1;

        /// <summary>
        /// User connection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns> 
        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextID,
                Name = name,
                operationContext = OperationContext.Current
            };
            nextID++;

            SendMsg(": " + user.Name + " has connected to the chat!", 0);
            users.Add(user);
            return user.ID; 
        }
         
        /// <summary>
        /// User disconnection
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMsg(": " + user.Name + " has left the chat", 0);
            }
        }

        /// <summary>
        /// User send message
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="id"></param>
        public void SendMsg(string msg, int id)
        {
            foreach(var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }
                answer += msg;

                item.operationContext.GetCallbackChannel<IServiceChatCallback>().MsgCallback(answer);
            }
        }
    }
}
