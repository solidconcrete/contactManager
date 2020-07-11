using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace contactManager
{
    public class Contact
    {
        public string name
        {
            get;
            set;
        }
        public string surname
        {
            get;
            set;
        }
        public string phoneNumber
        {
            set;
            get;
        }
        public string address
        {
            set;
            get;
        }

        public static Contact findByPhone(string phone)
        {
            string contactListJSON = fileOperations.readFile();
            List<Contact> contactList = JsonConvert.DeserializeObject<List<Contact>>(contactListJSON);

            foreach (Contact c in contactList)
            {
                if (c.phoneNumber == phone)
                {
                    return c;
                }
            }
            return null;
        }

        public static void remove(Contact contactToRemove)
        {
            if (contactToRemove != null)
            {
                string contactListJSON = fileOperations.readFile();

                List<Contact> contactList = JsonConvert.DeserializeObject<List<Contact>>(contactListJSON);
                foreach(Contact c in contactList)
                {
                    if (c.phoneNumber == contactToRemove.phoneNumber)
                    {
                        contactList.Remove(c);
                        contactListJSON = JsonConvert.SerializeObject(contactList);
                        fileOperations.writeToFile(contactListJSON);
                        return;
                    }
                }
            }
        }

        public static void add(Contact contactToAdd)
        {
            string contactListJSON = fileOperations.readFile();
            List<Contact> contactList = JsonConvert.DeserializeObject<List<Contact>>(contactListJSON);
            contactList.Add(contactToAdd);
            contactListJSON = JsonConvert.SerializeObject(contactList);
            fileOperations.writeToFile(contactListJSON);
        }

    }
}
