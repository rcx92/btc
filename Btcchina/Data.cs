using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Btcchina
{
    [DataContract]
    public class RequestData
    {
        [DataContract]
        public class Auth
        {
            [DataContract]
            public class PasswordCredentials
            {
                public PasswordCredentials(string username, string password)
                {
                    this.username = username;
                    this.password = password;
                }
                [DataMember]
                public string username, password;
            }
            [DataMember]
            public PasswordCredentials passwordCredentials;
            [DataMember]
            public string tenantName;
            public Auth(string username, string password, string tenantName)
            {
                passwordCredentials = new PasswordCredentials(username, password);
                this.tenantName = tenantName;
            }
        }
        [DataMember]
        public Auth auth;
        public RequestData(string username, string password, string tenantName)
        {
            auth = new Auth(username, password, tenantName);
        }
    }


    [DataContract]
    public class ResponseData
    {
        [DataContract]
        public class Ticker
        {
            [DataMember]
            public double high;
            [DataMember]
            public double low;
            [DataMember]
            public double buy;
            [DataMember]
            public double sell;
            [DataMember]
            public double last;
            [DataMember]
            public double vol;

        }
        [DataMember]
        public Ticker ticker;
    }

    [DataContract]
    public class ObjectContainer
    {
        [DataMember]
        public string name;
        [DataMember]
        public int count;
        [DataMember]
        public long bytes;
    }

    [DataContract]
    public class ObjectData
    {
        [DataMember]
        public string name;
        [DataMember]
        public string hash;
        [DataMember]
        public long bytes;
        [DataMember]
        public string content_type;
        [DataMember]
        public string last_modified;
    }



    public static class JSON
    {

        public static T parse<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);
            }
        }

        public static string stringify(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
