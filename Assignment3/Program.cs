using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/* Name: Taha Mohyuddin
 * Program: Assignment 3
 * Purpose: This pogram Sorts Crew Members last names based on a specific criterion, which is counting he number of occurreces of each letter in the last names. This program Uses QuickSort. For more description go below the page
 * Date: 2023-05-17 to 2023-05-24
*/
namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpVal = "input.txt";  // Declaring a variable called inpVal of type string and assigning it the value "input.txt". This line specifies the path of the input file that will be read by the program.
            StreamReader reader = new StreamReader(inpVal); //creating a StreamReader object to read from the input file
            int Numofship = int.Parse(reader.ReadLine()); // In this line it will read the first line to check the number of ships hence Extracting it.


            for (int ship = 1; ship <= Numofship; ship++) //Made a loop so it processoes every single ship, This line uses a for loop that initializes a variable ship to 1, excutes the loop as long as ship is less than the number of ships entered by user on the file input.txt
            {
                int Numofpeople = int.Parse(reader.ReadLine());  //In this line, I am extracting the number of people in the current ship from the lines array. lineIndex is used as the index to access the appropriate line in the array.The int.Parse() method is called to convert the string value at lines[lineIndex] to an integer, as number of people is an int value.
                string[] crew = new string[Numofpeople];  // In this line I Created an array to store the crew members' last names.

                for (int person = 0; person < Numofpeople; person++)  // Here I am using a for loop that iterates over each person in a ship, where Numofpeople represents the total number of people in the current ship.
                {
                    crew[person] = reader.ReadLine(); //During each iteration, the code reads a line from the StreamReader object reader using the ReadLine() method, which corresponds to the last name of a crew member. The retrieved last name is then assigned to the crew array at the index specified by the person variable, effectively capturing and storing the last name of each crew member in the array.
                }

                Console.WriteLine("Ship #" + ship + " Crews:"); // This will display the Ship Number 

                QuickSort(crew, 0, Numofpeople - 1); // calling the QuickSort method to sort the crew members last names using QuickSort             

                PrintArray(crew);// Here I called the method, that will print the sorted order of crew members last names

                Console.WriteLine(); // I added this line to add a line break between ships
            }
            reader.Close();// It closes the Input file
            Console.ReadKey();
        }


        static void PrintArray(string[] crew) //In ths line I declare a method named PrintArray that takes an array of strings (string[] crew) as a parameter and does not return a value. The method is responsible for printing the elements of the array.
        {
            for (int person = 0; person < crew.Length; person++) // This line uses a for loop that initializes a variable person to 0, executes the loop as long as person is less than the length of the crew array, and increments person by 1 in each iteration.This loop iterates over each element in the array.
            {
                Console.WriteLine(crew[person]); //This line Prints the current element on a new line
            }
        }


        static void QuickSort(string[] crew, int left, int right) //In this line I declare a method named QuickSort that takes an array of strings (string[] crew), and two integers left and right, as parameters. The method is responsible for performing the QuickSort algorithm to sort the array.
        {
            if (left < right) // This line checks if there are more than one element to sort in the subarray. If the condition is true, it proceeds with the sorting process. Otherwise, it means the subarray has zero or one element, and no sorting is required.
            {
                int pivotIndex = Partition(crew, left, right);  // This line determines the pivot index by calling the Partition method, passing the array crew, and the indices left and right. The Partition method is responsible for rearranging the elements and returning the pivot index.

                QuickSort(crew, left, pivotIndex - 1);  //This line recursively calls the QuickSort method to sort the left subarray. The left subarray consists of elements from index left to pivotIndex - 1.
                QuickSort(crew, pivotIndex + 1, right); // This line recursively calls the QuickSort method to sort the right subarray. The right subarray consists of elements from index pivotIndex + 1 to right.
            }
        }

        static int Partition(string[] crew, int left, int right) //This line declares a method named Partition that takes an array of strings (string[] crew), and two integers left and right, as parameters. The method is responsible for partitioning the array to determine the pivot position during the QuickSort algorithm.
        {
            string pivot = crew[right]; // This line selects the pivot element as the rightmost element in the subarray. The pivot element is used as a reference for comparing and rearranging the other elements during partitioning.
            int i = left - 1; // This line initializes the index i to the position before the leftmost element in the subarray. It represents the index of the smaller element.

            for (int j = left; j < right; j++) // This line starts a loop that iterates over the subarray from left to right-1. It considers each element for comparison with the pivot. 
            {
                if (CompareNames(crew[j], pivot) < 0) // This line compares the current element with the pivot using the CompareNames method. It checks if the current element should be placed before the pivot based on the comparison result.
                {
                    i++; // This line increments the index i when an element smaller than the pivot is found, indicating that a smaller element is properly positioned.
                    Swap(crew, i, j); // This line swaps the elements at positions i and j, moving the smaller element to its correct position.
                }
            }

            Swap(crew, i + 1, right); //This line swaps the pivot element with the element at position i + 1, placing the pivot in its final sorted position. 
            return i + 1;  //This line returns the updated pivot index, indicating the position of the pivot after partitioning.
        }

        static void Swap(string[] crew, int i, int j)  //This line declares a method named Swap that takes an array of strings (string[] crew), and two integers i and j, the method is responsible to swap two elements in an array
        {
            string temp = crew[i];  // Store the value of element at position i in a temporary variable
            crew[i] = crew[j];  //Assign the value of element at position j to position i
            crew[j] = temp;  // Assign the value stored in the temporary variable to position j
        }


        static int CompareNames(string name1, string name2) // This line declares a method named CompareNames that takes two strings name1 and name2, as parameteres. This method is responsible for comparing names.
        {
            int[] letterCountsName1 = CountLetters(name1); // This line calls the CountLetters method to count the occurrences of each letter in name21 and stores the results in the letterCountsName1 array.
            int[] letterCountsName2 = CountLetters(name2); // This line calls the CountLetters method to count the occurrences of each letter in name2 and stores the results in the letterCountsName2 array.

            for (int letter = 'A'; letter <= 'Z'; letter++)  // This line starts a loop that iterates over each letter in the alphabet.
            {
                int countName1 = letterCountsName1[letter - 'A'];  // This line retrieves the count of the current letter in name1 by accessing the corresponding element in the letterCountsName1 array using the index calculated as letter - 'A'.
                int countName2 = letterCountsName2[letter - 'A'];  // This line retrieves the count of the current letter in name2 by accessing the corresponding element in the letterCountsName2 array using the index calculated as letter - 'A'.

                if (countName1 != countName2)  // This line compares the counts of the current letter in name1 and name2 to check if they are different.
                    return countName2 - countName1;  // This line returns the difference between countName2 and countName1. The return value represents the comparison result based on the count of the current letter.
            }

            for (int i = 0; i < name1.Length && i < name2.Length; i++)  // This line starts a loop that iterates over the characters in name1 and name2 up to the length of the shorter name.
            {
                if (name1[i] != name2[i])  // This line compares the characters at position i in name1 and name2 to check if they are different.
                    return name1[i] - name2[i];  // This line returns the difference between the character values at position i in name1 and name2. The return value represents the comparison result based on the character values.
            }

            return name1.Length - name2.Length; // This line returns the difference between the lengths of name1 and name2. The return value represents the comparison result based on the lengths of the names.

        }
        static int[] CountLetters(string name) // Define a method to count the occurrences of each letter in a name
        {
            int[] letterCounts = new int['Z' - 'A' + 1]; // This line creates an integer array called letterCounts with a length equal to the number of capital letters in the English alphabet. It calculates the length by subtracting the character code of 'A' from the character code of 'Z' and adding 1.

            for (int i = 0; i < name.Length; i++)  // This line starts a loop that iterates over each character in the name string. The loop variable i represents the current position in the string.
            {
                char letter = name[i];  // This line retrieves the character at position i from the name string and assigns it to the variable letter.

                if (letter >= 'A' && letter <= 'Z') // This line checks if the current character letter is a capital letter by comparing it to the character range from 'A' to 'Z'. It ensures that only capital letters are counted.
                {
                    letterCounts[letter - 'A']++;  // This line increments the count for the corresponding letter in the letterCounts array. It calculates the index of the letter by subtracting the character code of 'A' from the character code of the current letter letter.
                }
            }

            return letterCounts; // This line returns the letterCounts array, which contains the counts of each letter in the name.
        }
    }
}       
   

/*Description of the Program:
 * This program reads input from a file (input.txt) that contains information about multiple ships and their crew members. 
 * It sorts the crew members' last names based on a specific criterion, which is counting the number of occurrences of each letter in the last names. 
 * If there is a tie in letter counts, it resorts to lexicographical comparison. The program uses the QuickSort algorithm to efficiently sort the crew members' last names. Finally, 
 * it outputs the sorted order of crew members for each ship. The program utilizes StreamReader to read the input file and provides a user-friendly interface for interacting with the data.
*/

