using CustomerAppBLL;
using CustomerAppEntity;
using System;
using System.Collections.Generic;

namespace CustomerAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
       
        static void Main(string[] args)
        {
            var cust1 = new Customer
            {
                FistName = "Bob",
                LastName = "Dylan",
                Address = "BongoStreet 232"
            };
            //this is one kingd to write as methot
            //bllFacade.GetCustumerService().Create(cust1);
            bllFacade.CustumerService.Create(cust1);

            //this is other kingd to write as properties
            bllFacade.CustumerService.Create(new Customer()
            {
                FistName = "Edi",
                LastName = "Lamar",
                Address = "Sp Kirkevej 129"

            });

            //Show the first customer saved internally
            //Console.WriteLine($"Name:{cust1.FistName} {cust1.LastName}");
            string[] menuItems =
            {
                "List All Customers",
                "Add customer",
                "Delete Customer",
                "Edit Customner",
                "Exit"
            };

            //Show Menu
            //Wait for Selection
            // - Show selection or
            // - Warning and go back to menu

            var selection = ShowMenu(menuItems);

            /*if (selection==1)
            {
                Console.WriteLine("List Customers");
            }
            else if (selection==2)
            {
                Console.WriteLine("Add Customers");
            }
            else if (selection == 3)
            {
                Console.WriteLine("Delete Customers");
            }
            else if (selection == 4)
            {
                Console.WriteLine("Edit Customers");
            }
            else
            {
                Console.WriteLine("Bye Bye!");
            }

            */
            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListCustomers();
                        break;
                    case 2:
                        AddCustomers();
                        break;
                    case 3:
                        DeleteCustomer();
                        break;
                    case 4:
                        EditCustomer();
                        break;

                    default:

                        break;
                }

                selection = ShowMenu(menuItems);

            }

            Console.WriteLine("Bye Bye!");
            Console.ReadLine();

        }

        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            if (customer != null)
            {
                Console.WriteLine("First Name: ");
                customer.FistName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                customer.Address = Console.ReadLine();
            }
            else
            {
                Console.WriteLine(  "Customer not found!");     
            }
        }

        private static Customer FindCustomerById()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return bllFacade.CustumerService.Get(id);
        }

        private static void DeleteCustomer()
        {

            var customerFound = FindCustomerById();
            if (customerFound != null )
            {
                bllFacade.CustumerService.Delete(customerFound.Id);
            }
            var response = customerFound == null ? "Customer not Found!" : "Customer was Deleted";
            Console.WriteLine(response);
        }

        private static void AddCustomers()
        {
            Console.WriteLine("Fisrt Name: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Last Name: ");
            var lasttName = Console.ReadLine();
            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            bllFacade.CustumerService.Create(new Customer()
            {
                FistName = firstName,
                LastName = lasttName,
                Address = address
            });

        }

        private static void ListCustomers()
        {
            Console.WriteLine("\nList of Customers");

            foreach (var customer in bllFacade.CustumerService.GetAll())
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FistName} {customer.LastName} Address: {customer.Address}");
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n ");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }


            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 5)
            {
                Console.WriteLine("You need to select number between 1-5");
            }

            Console.WriteLine("Selection: " + selection);
            return selection;
        }

    }
}
