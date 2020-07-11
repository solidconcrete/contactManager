using contactManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace contactManager
{
    class Logic
    {
        public static bool contactAlreadyExists(Contact contactToInsert)
        {
            string contactListJSON = fileOperations.readFile();
            List<Contact> contactList = JsonConvert.DeserializeObject<List<Contact>>(contactListJSON);

            foreach (Contact c in contactList)
            {
                if (c.phoneNumber == contactToInsert.phoneNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public static void addNewContact()
        {
            Contact contactToInsert = UI.collectNewUserData();
            if (contactToInsert == null)
            {
                Console.WriteLine("Contact not inserted");
                return;
            }


            bool isNumberTaken = Logic.contactAlreadyExists(contactToInsert);
            if (!isNumberTaken)
            {
                Contact.add(contactToInsert);
                Console.WriteLine ("\n New contact added successfully");
                return;
            }
            Console.WriteLine("Contact with such phone number already exists");
        }

        public static void removeConctact()
        {
            string phone = UI.getPhoneFromKeyboard();
            if (phone != null)
            {
                Contact contactToRemove = Contact.findByPhone(phone);
                Contact.remove(contactToRemove);
                Console.WriteLine("Contact removed");
                return;
            }
        }

        public static void updateContact()
        {
            string phone = UI.getPhoneFromKeyboard();
            Contact contactToUpdate = Contact.findByPhone(phone);
            if (contactToUpdate == null)
            {
                Console.WriteLine("Contact not found");
                return;
            }

            Console.WriteLine("Enter updated data");

            Contact updatedInfo = UI.collectNewUserData();
            if(updatedInfo == null)
            {
                return;
            }

            if (updatedInfo.phoneNumber != contactToUpdate.phoneNumber)
            {
                if (contactAlreadyExists(updatedInfo) == true)
                {
                    Console.WriteLine("This number is already occupied");
                    return;
                }
            }
            Contact.remove(contactToUpdate);
            Contact.add(updatedInfo);
        }
    }
}
