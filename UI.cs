using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace contactManager
{
    class UI
    {
        public void start()
        {
            help();
            while(true)
            {
                Console.WriteLine("\n Waiting for a command");
                String command = Console.ReadLine();
                Console.WriteLine();
                switch (command)
                {
                    

                    case "1":
                    case "insert":
                    case "Insert":
                        Logic.addNewContact();
                        break;

                    case "update":
                    case "Update":
                    case "2":
                        Logic.updateContact();
                        break;

                    case "Delete":
                    case "delete":
                    case "3":
                        Logic.removeConctact();
                        break;

                    case "List":
                    case "list":
                    case "4":
                        printContactList();
                        break;

                    case "5":
                    case "Help":
                    case "help":
                        help();
                        break;

                    case "close":
                    case "Close":
                        return;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
        public void help()
        {
            Console.WriteLine("Nice to see you, human \n List of available commands:" +
               "\n Insert (1). Add a new contact to the list" +
               "\n Update (2). Update an already existing contact" +
               "\n Delete (3). Delete an existing contact" +
               "\n List (4). Shows the whole list of contacts" +
               "\n Help (5). Displays available commands");
        }

        public static Contact collectNewUserData()
        {
            
            Console.WriteLine("Enter contact name");
            string name = Console.ReadLine();
            if (name.Length == 0)
            {
                Console.WriteLine("Contact name can not be empty");
                return null;
            }
            Console.WriteLine();
            
            Console.WriteLine("Enter contact surname");
            string surname = Console.ReadLine();
            if (surname.Length == 0)
            {
                Console.WriteLine("Contact surname can not be empty");
                return null;
            }
            Console.WriteLine();

            string number = getPhoneFromKeyboard();

            if (number == null)
            {
                return null;
            }

            Console.WriteLine("Enter contact address (Skippable by just pressing ENTER)");
            string address = Console.ReadLine();

            return new Contact
            {
                name = name,
                surname = surname,
                phoneNumber = number,
                address = address
            };
        }

        public void printContactList()
        {
            String contactListJSON = fileOperations.readFile();
            List<Contact> contactList = JsonConvert.DeserializeObject<List<Contact>>(contactListJSON);

            foreach (Contact c in contactList)
            {
                Console.Write(c.name + " " + c.surname + ", Phone: " + c.phoneNumber);
                if (c.address != "")
                {
                    Console.WriteLine(", Address: " + c.address + ";");
                }
                else Console.WriteLine(";");
            }

        }

        public static string getPhoneFromKeyboard()
        {
            string number;
            Console.WriteLine("Enter contact phone number");
            number = Console.ReadLine();
            Console.WriteLine();

            if (!Regex.IsMatch(number, @"^\d+$"))
            {
                Console.WriteLine("phone can contain only digits");
                return null;
            }
            return number;
        }
    }

}
