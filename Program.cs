using System;
using TaskManager.Models;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initializing the task list.
            var Chore_List = new List<Chore>();

            //Brief welcome message and first menu posting.
            Console.WriteLine("Welcome to the task management application...");
            Console.WriteLine("Please select from the following options:");
            Print_Menu();

            //Getting the input variable for the first time.
            //(No input validation as this will turn into a UI menu)
            var User_Input = int.Parse(Console.ReadLine());

            //The while loop starting here is the menu for the task manager.
            while (User_Input != 7)
            {
                //Initializing the new task object.
                var New_Chore = new Chore();

                //Menu option to create a new task.
                if (User_Input == 1)
                {

                    Console.WriteLine("\nPlease enter the name of the new task:");
                    New_Chore.Name = Console.ReadLine();
                    Console.WriteLine("Please enter a description of the new task:");
                    New_Chore.Description = Console.ReadLine();
                    Console.WriteLine("Please enter the deadline of the new task (MM/DD/YYYY):");
                    New_Chore.Deadline = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the completion status of the new task (Y/N):");
                    New_Chore.IsCompleted = Comp_Stat();

                    Chore_List.Add(New_Chore);

                }
                //Menu option to delete a task.
                else if (User_Input == 2)
                {
                    Console.WriteLine("\nCaution: You are deleting a task!");
                    var index = Get_Index(Chore_List);
                    Chore_List.RemoveAt(index - 1);
                    Console.WriteLine($"\nThe task at index {index} has been deleted.");

                }
                //Menu option to edit a task.
                else if (User_Input == 3)
                {
                    Console.WriteLine("\nYou have chosen to edit a task...");
                    Console.WriteLine("The index will not change...");
                    var index = (Get_Index(Chore_List)-1);
                    Console.WriteLine($"What would you like to edit on the task at index {index + 1}");
                    Edit_Menu();
                    var edit_choice = int.Parse(Console.ReadLine());
                    while(edit_choice != 5)
                    {
                        if(edit_choice == 1)
                        {
                            Console.WriteLine("\nPlease enter the new name of the task:");
                            Chore_List[index].Name = Console.ReadLine();
                        }else if(edit_choice == 2)
                        {
                            Console.WriteLine("Please enter the new description of the task:");
                            Chore_List[index].Description = Console.ReadLine();
                        }
                        else if(edit_choice == 3)
                        {
                            Console.WriteLine("Please enter the new deadline of the task (MM/DD/YYYY):");
                            Chore_List[index].Deadline = DateTime.Parse(Console.ReadLine());
                        }
                        else if(edit_choice == 4)
                        {
                            Console.WriteLine("Please enter the new completion status of the task (Y/N):");
                            Chore_List[index].IsCompleted = Comp_Stat();
                        }
                        else
                        {
                            Console.WriteLine("\nPlease Enter a valid input...");
                        }

                        Edit_Menu();
                        edit_choice = int.Parse(Console.ReadLine());

                    }

                    Console.WriteLine("\nThe task has been updated...\n");


                }
                //Menu option to complete a task.
                else if (User_Input == 4)
                {
                    Console.WriteLine("\nYou have chosen to complete a task...");
                    Console.WriteLine("The index will not change...");
                    var index = (Get_Index(Chore_List) - 1);
                    Chore_List[index].IsCompleted = true;
                    Console.WriteLine("\nThe completion status of the task has been updated...\n");

                }
                //Menu option to list non-completed tasks.
                else if (User_Input == 5)
                {
                    bool shown = false;
                    int i = 1;
                    Console.WriteLine("\n");
                    foreach (Chore temp_chore in Chore_List)
                    {
                        if (temp_chore.IsCompleted == false)
                        {
                            Console.WriteLine($"Index: {i}");
                            Console.WriteLine($"Name: {temp_chore.Name}");
                            Console.WriteLine($"Description: {temp_chore.Description}");
                            string temp_date = String.Format("{0:MM/dd/yyyy}", temp_chore.Deadline);
                            Console.WriteLine($"Deadline: {temp_date}");
                            Console.WriteLine($"Completed: {temp_chore.IsCompleted}\n");
                            shown = true;
                        }

                        i++;
                    }
                    if (!shown) { Console.WriteLine("There are no tasks to display!"); }


                }
                //Menu option to list all tasks.
                else if (User_Input == 6)
                {
                    if (Chore_List.Count == 0) { Console.WriteLine("There are no tasks to display!"); }
                    int i = 1;
                    Console.WriteLine("\n");
                    foreach (Chore temp_chore in Chore_List)
                    {
                        Console.WriteLine($"\nIndex: {i}");
                        Console.WriteLine($"Name: {temp_chore.Name}");
                        Console.WriteLine($"Description: {temp_chore.Description}");
                        string temp_date = String.Format("{0:MM/dd/yyyy}", temp_chore.Deadline);
                        Console.WriteLine($"Deadline: {temp_date}");
                        Console.WriteLine($"Completed: {temp_chore.IsCompleted}\n");

                        i++;
                    }

                }
                else
                {
                    Console.WriteLine("\nPlease enter an integer with a coresponding menu option...");
                }

                Print_Menu();
                User_Input = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nThank you for using the Task Manager.");
            Console.WriteLine("The program will now quit...\n");

        }

        public static void Print_Menu()
        {
            Console.WriteLine("\n1.) Create A New Task");
            Console.WriteLine("2.) Delete An Existing Task");
            Console.WriteLine("3.) Edit An Existing Task");
            Console.WriteLine("4.) Complete A Task");
            Console.WriteLine("5.) List All Outstanding (Not Completed) Tasks");
            Console.WriteLine("6.) List All Tasks");
            Console.WriteLine("7.) Quit Task Manager\n");
        }

        public static bool Comp_Stat()
        {
            while (true)
            {
                var temp_bool = Console.ReadLine();
                if (temp_bool == "Y" || temp_bool == "y")
                {
                    return true;
                }
                else if (temp_bool == "N" || temp_bool == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter a Y for yes or a N for no...");
                }
            }
            
        }

        public static int Get_Index(List<Chore> CList)
        {
            while (true)
            {
                Console.WriteLine("\nPlease enter the index of the task.");
                Console.WriteLine("If the index value is not known you can use menu choice 6 to find it.\n");
                var returner = int.Parse(Console.ReadLine());
                if(returner <= 0)
                {
                    Console.WriteLine("An invalid index was provided.");
                }else if (CList.Count >= returner)
                {
                    return returner;
                }
                else
                {
                    Console.WriteLine("An invalid index was provided.");
                }
            }
            
        }

        public static void Edit_Menu()
        {
            Console.WriteLine("\n1.) Name");
            Console.WriteLine("2.) Description");
            Console.WriteLine("3.) Deadline");
            Console.WriteLine("4.) Completion Status");
            Console.WriteLine("5.) CANCEL\n");
        }

    }
}